using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace TestHarvester
{
    public enum РежимПриемаБайт
    {
        Стандарт = 0,         //ReceiveNByte() запусается стандартным образом - значение по умолчанию
        ПредварительнаяОчисткаБуфера = 1,  //сперва очистить буфер приема
    }

    public class COM
    {

        //НИЖНИЙ СЛОЙ
        private byte[] _receiveBuff;
        int _iReceiveByte;
        private SerialPort _serialPort;
        private const int WAIT_ANSWER_TIMEOUT = 500;
        //private log logfile;
        ///public string COM = "";
        public string errtxt = "";

        MainForm _mainForm;
        public void COMInit(ref MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        // очистить приемный буфер
        private void RxReset()
        {
            _iReceiveByte = 0;
            _receiveBuff[0] = 0;
        }

        //Конструктор
        public COM()
        {
            _serialPort = new SerialPort();
            //logfile = new log(this.GetType().ToString());
            _receiveBuff = new byte[256];
        }


        //обработчик события приема байт в порт
        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            SerialPort sp = (SerialPort)sender;
            try
            {
                //пока есть байты в приемном буфере, забираем их по одному в пользовательский буфер
                while (0 != sp.BytesToRead)
                {
                    //если пользовательский буфер не заполнен - забираем в него очередной байт. иначе, читаем буфер порта в пустоту для его очистки
                    if (_iReceiveByte < _receiveBuff.Length - 2)// -2 потому что 1 на то что индекс, 1 на то что хотябы на один больше чем в пользовательском буфере
                    {
                        _receiveBuff[_iReceiveByte] = (byte)sp.ReadByte();//прочитать один байт из приемного буфера
                        _iReceiveByte++;
                        //_rxdata[_rxidx] = 0xE4;//в последнем всегда будет ноль
                    }
                    else
                        sp.ReadByte();
                }
            }
            catch (Exception ex)
            {
                errtxt = ex.Message;
            }
        }


        public void SetComPort(string namePort)
        {
            try
            {
                _serialPort.PortName = namePort;
            }
            catch (Exception)
            {
                _mainForm.AddErrorsAndWarinigs("ошибка при выборе Com порта");
            }
        }
        
        public void SetPortSpeed(string сomPortSpeed)
        {
            try
            {
                _serialPort.BaudRate = Convert.ToInt32(сomPortSpeed);
            }
            catch (Exception)
            {
                _mainForm.AddErrorsAndWarinigs("ошибка при выборе Com порта");
            }
        }

        public void SetPortParity(byte comPortParity)
        {
            try
            {
                _serialPort.Parity = (Parity)comPortParity;
            }
            catch (Exception)
            {
                _mainForm.AddErrorsAndWarinigs("ошибка при выборе Com порта");
            }
        }

        public string GetCurrComPortName()
        {
            return _serialPort.PortName;
        }

        public void OpenPort()
        {
            //открываем com порт
            try
            {
                _serialPort.Open();
            }
            catch (Exception)
            {
                _mainForm.AddErrorsAndWarinigs("не получилось открыть Com порт");
            }
        }

        public void InitCOMStartVals()
        {
            _serialPort.BaudRate = 115200;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
            // Создание обработчика события для приема данных:
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.WriteTimeout = 50;
        }

        private void Close()
        {
            _serialPort.Close();
        }

        private String Received()
        {
            return Encoding.GetEncoding(1251).GetString(_receiveBuff);
        }

        //пишет последовательность байт (char[]) в порт
        public bool Write(ref List<byte> bytes)
        {
            bool result = false;

            char[] resultChars = Encoding.ASCII.GetChars(bytes.ToArray());
            try
            {
                //в норме чистится приемный буфер при каждой отправке
                RxReset();
                _rxBufCleaned = true;

                _serialPort.Write(resultChars, 0, resultChars.Length);
                result = true;
            }
            catch (Exception ex)
            {
                //logfile.write(ex.Message);
                errtxt = ex.Message;
            }
            return result;
        }


        //ВЕРХНИЙ СЛОЙ
        public enum ResRcvNBytes
        {
            Undef,
            NBytesIsSmall,
            TimeOut,
            Succes
        }

        public enum ConfigReсeiveNByte
        {
            Normal = 0,         //ReceiveNByte() обычный запуск
            WaitEquSimb = 1     //при работе искать в принятом хотябы одно свопадение указанного символа
        }


        //ждать приема N байт из порта. true - нужное число байт получено. false - время истекло, а нужного числа байт нет
        bool _rxBufCleaned;//приемный буфер в норме чистится в начале приема, если не произошло очистки при предыдущей посылке
        private ResRcvNBytes ReceiveNByte(ref List<byte> list,   //полученые байты
                                        Int16 nByte,            //количество байт которое требуется получить
                                    float timeoutS,             //таймаут на получение этого количества байт [s]
                                    List<byte> compVals,           //значения для сравнений
                                    bool clearOrNoBuf = false,  //1 - чистить в самом начале выхова данной функции пользовательский приемный буфер
                                    ConfigReсeiveNByte confRcv = ConfigReсeiveNByte.Normal)
        {                           
            UInt16 timeout100ms = (UInt16)(timeoutS * 10f);
            _cntTickWaitReceive = 0;
            UInt16 iGotByte = 0;//? счетчик полученых байт с начала захода в  ReceiveNByte()
            ResRcvNBytes result = ResRcvNBytes.Undef;

            //в норме если по какой то причине не было очищен приемный буфер нужно почистить в начале запуска приема
            if (clearOrNoBuf == true && _rxBufCleaned == false)
                RxReset();
            _rxBufCleaned = false;

            while (true)
            {
                //если нужно, проверяем постоянно на наличие определенного символа в принятом
                if(confRcv == ConfigReсeiveNByte.WaitEquSimb)
                {
                    if (_receiveBuff.Contains(compVals[0]))
                    {
                        result = ResRcvNBytes.Succes;
                        break;
                    }
                }

                //мотаем свой счетчик и по нему выходим если он досчитался. iGotByte
                if (iGotByte < _iReceiveByte)
                    iGotByte++;
                if (iGotByte >= nByte)
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        
                    }
                    
                    result = ResRcvNBytes.Succes;
                    break;
                }
                if (_cntTickWaitReceive > timeout100ms)
                {
                    result = ResRcvNBytes.TimeOut;
                    break;
                }
            }
            for (int i = 0; i < nByte; i++)
            {
                list.Add(_receiveBuff[i]);
            }
            return result;
        }


        public ResWaitBytesFoo WaitReceiveThisBytes(
            ref List<byte> bytesOfPattern,                  //ждем таких байт
            float sec,                                      //не менее такого времени
            РежимПриемаБайт conf = РежимПриемаБайт.Стандарт,//
            short nBytesWait = 0)//произвольное минимальное количество байт которое нужно подождать. пока такое количество не примется не выходим
        {
            
            List<byte> bytesOfPort = new List<byte>();
            
            ResWaitBytes detailedResult = ResWaitBytes.Непонятен_неизвестен;
            SimplResult simplResult = SimplResult.Wrong;

            //если не указиваем число ожидаемых байт явно, это число берем из длины массива
            short nBytesWaitIn;
            if (nBytesWait > 0)
                nBytesWaitIn = nBytesWait;
            else
                nBytesWaitIn = (short)(bytesOfPattern.Count);


            //byte []bytes = Encoding.ASCII.GetBytes(chars);
            //List<byte> bytesOfPattern = bytes.ToList();

            if (detailedResult != ResWaitBytes.Неверный_формат_последовательнсти_байт)
            {
                COM.ResRcvNBytes resultRcv;
                if (bytesOfPattern.Count == 1)
                    resultRcv = ReceiveNByte(ref bytesOfPort, nBytesWaitIn, sec, bytesOfPattern, false, ConfigReсeiveNByte.WaitEquSimb);
                else
                    resultRcv = ReceiveNByte(ref bytesOfPort, nBytesWaitIn, sec, bytesOfPattern);
                if (resultRcv == COM.ResRcvNBytes.TimeOut)
                    detailedResult = ResWaitBytes.Не_уложилась_в_заданное_время;
                else if (resultRcv == COM.ResRcvNBytes.NBytesIsSmall)
                    detailedResult = ResWaitBytes.Байтов_слишком_мало;
                    
                else if (resultRcv == COM.ResRcvNBytes.Succes)
                {
                    if (bytesOfPort.SequenceEqual(bytesOfPattern) || confRcv == ConfigReсeiveNByte.WaitEquSimb)
                    {
                        detailedResult = ResWaitBytes.Успешный;
                        simplResult = SimplResult.OK;
                    }
                }



            }

            

            ResWaitBytesFoo res = new ResWaitBytesFoo();
            res.Simple = simplResult;
            res.Detailed = detailedResult;
            return res;
        }





        //тикаем в ожидании завершения приема
        UInt16 _cntTickWaitReceive;

        public void OneTickWaitReceive()
        {
            _cntTickWaitReceive++;
        }


        public enum TypConversion
        {
            Hex2Hex = 0,         //
            Str2ASCI = 1  //
        }

        //строку с hex числами конвертим в массив байт
        public bool GetHexFromString(string stringBytes, ref List<byte> resultBytes)
        {
            //List<byte> bytesOfPattern = new List<byte>();
            bool result = false;
            try
            {
                string[] splitedBytesOfStr = stringBytes.Split(' ');
                List<string> bytesStr = splitedBytesOfStr.ToList();
                foreach (string item in bytesStr)
                {
                    resultBytes.Add(Convert.ToByte(item, 16));
                }
                //byte[] bytes = bytesOfPattern.ToArray();
                //resultChars = Encoding.ASCII.GetChars(bytes);// Unicode.GetChars(bytes, 0 , 2);
                //byte[] bytes = Encoding.ASCII.GetBytes(resultChars);
                //List<byte> resultBytes = bytes.ToList();

                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }


        //строку с текстом конвертим в массив байт в кодировке ASCII
        public bool GetASCIBytesFromString(string stringBytes, ref List<byte> lResult)
        {
            List<byte> bytesOfPattern = new List<byte>();
            bool result = false;
            try
            {
                char[] splitedBytesOfStr = stringBytes.ToCharArray();
                byte[] bytes = Encoding.ASCII.GetBytes(splitedBytesOfStr);
                lResult = bytes.ToList();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

    }
}
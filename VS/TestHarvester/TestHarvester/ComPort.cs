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
        Стандарт = 0,                       //ReceiveNByte() запусается стандартным образом - значение по умолчанию, не ясно что это значит..
        ПредварительнаяОчисткаБуфера = 1,   //сперва очистить буфер приема от того что могло насыпаться ранее
    }
    
    public class COM
    {
        const int SIZE_ARR_RCV = 256;
        //НИЖНИЙ СЛОЙ
        private byte[] _receiveBuff;
        private List<byte> _rcvBuff4LogWindow;
        int _iReceiveByte;
        int _iReceiveBuff4Monitoring;
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

        bool _hexOrASCIIViewDataStreem = true;
        //забрать послерюю порцию данных прошедших через порт
        public string GetLastDataStreemLog()
        {
            string result = "";
            if (_rcvBuff4LogWindow.Count > 0)
            {
                if (_hexOrASCIIViewDataStreem)
                {
                    //char[] arrCompVals = Encoding.ASCII.GetString(_rcvBuff4LogWindow.ToArray());//символы
                    //result = string.Join(" ", arrCompVals);
                    result = Encoding.ASCII.GetString(_rcvBuff4LogWindow.ToArray());
                    //string t = Encoding.ASCII.GetString(_rcvBuff4LogWindow.ToArray());

                    //char t = Convert.ToChar(_rcvBuff4LogWindow[0]);
                    //char t2 = Convert.ToChar(_rcvBuff4LogWindow[1]);

                    //char[] arrCompVals = Encoding.ASCII.GetChars(_rcvBuff4LogWindow.ToArray());
                    //string tmp;
                    //int i = 0;
                    //foreach (char item in arrCompVals)
                    //{
                    //    tmp = arrCompVals[i].ToString();
                    //    i++;
                    //}
                    //string tmp = _rcvBuff4LogWindow[0].ToString();
                    //result = string.Join(,("", arrCompVals);
                }
                else
                {
                    byte[] arrCompVals = _rcvBuff4LogWindow.ToArray();//HEX числа
                    result = string.Join(" ", arrCompVals);
                }
                    
                
                _rcvBuff4LogWindow.Clear();
            }
            return result;
        }

        // очистить приемный буфер
        private void RxReset()
        {
            _iReceiveByte = 0;
            _receiveBuff[0] = 0;
        }

        private void RxClearFull()
        {
            _iReceiveByte = 0;
            Array.Clear(_receiveBuff, 0, SIZE_ARR_RCV);
        }


        const UInt16 SIZE_LOG_WIDOW = 1000;
        //Конструктор
        public COM()
        {
            _serialPort = new SerialPort();
            //logfile = new log(this.GetType().ToString());
            _receiveBuff = new byte[SIZE_ARR_RCV];
            _rcvBuff4LogWindow = new List<byte>();


        }



        //обработчик события приема байт в порт
        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte bRcv;
            SerialPort sp = (SerialPort)sender;
            try
            {
                //пока есть байты в приемном буфере, забираем их по одному в пользовательский буфер
                while (0 != sp.BytesToRead)
                {
                    //если пользовательский буфер не заполнен - забираем в него очередной байт. иначе, читаем буфер порта в пустоту для его очистки
                    if (_iReceiveByte < _receiveBuff.Length - 2)// -2 потому что 1 на то что индекс, 1 на то что хотябы на один больше чем в пользовательском буфере
                    {
                        bRcv = (byte)sp.ReadByte();//прочитать один байт из приемного буфера
                        _receiveBuff[_iReceiveByte] = bRcv;
                        _rcvBuff4LogWindow.Add(bRcv);

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
                _mainForm.AddMsgCommon("\tERR: ошибка при выборе Com порта");
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
                _mainForm.AddMsgCommon("\tERR: ошибка при выборе Com порта");
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
                _mainForm.AddMsgCommon("\tERR: ошибка при выборе Com порта");
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
                _mainForm.AddMsgCommon("Com порт открыт");
            }
            catch (Exception)
            {
                _mainForm.AddMsgCommon("\tERR: не получилось открыть Com порт");
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
            NBytesRcvAchieved,        //получено требуемое количество байт
            TimeOut,
            Succes
        }

        public enum ConfigReсeiveNByte
        {
            Normal = 0,         //ReceiveNByte() обычный запуск
            DuringWorkEquSequence = 1     //при работе искать в принятом заданную последовательность
        }


        //ждать приема N байт из порта. true - нужное число байт получено. false - время истекло, а нужного числа байт нет
        bool _rxBufCleaned;//приемный буфер в норме чистится в начале приема, если не произошло очистки при предыдущей посылке
        private ResRcvNBytes ReceiveNByte(ref List<byte> list,   //полученые байты
                                        Int16 nByte,            //количество байт которое требуется получить
                                    float timeoutS,             //таймаут на получение этого количества байт [s]
                                    List<byte> compVals,           //значения для сравнений
                                    bool clearOrNoBuf = true,  //в норме 1 - чистить в самом начале вызова данной функции пользовательский приемный буфер
                                                                    //обратное может понадобиться если мы эмулируем слейва где реакция системы идет следом за входящими сообщениями
                                    ConfigReсeiveNByte confRcv = ConfigReсeiveNByte.Normal)
        {                           
            UInt16 timeout100ms = (UInt16)(timeoutS * 10f);
            _cntTickWaitReceive = 0;
            UInt16 iGotByte = 0;//? счетчик полученых байт с начала захода в  ReceiveNByte()
            ResRcvNBytes result = ResRcvNBytes.Undef;

            //в норме если по какой то причине не было очищен приемный буфер нужно почистить в начале запуска приема
            //if (clearOrNoBuf == true && _rxBufCleaned == false)
                RxClearFull();
            //_rxBufCleaned = false;

            while (true)
            {
                //если нужно, проверяем постоянно на наличие определенного символа в принятом, при совпадении считаем 
                if (confRcv == ConfigReсeiveNByte.DuringWorkEquSequence)
                {
                    if (compVals.Count == 1)
                    {
                        if (_receiveBuff.Contains(compVals[0]))
                        {
                            result = ResRcvNBytes.Succes;
                            break;
                        }
                    }
                    else
                    {
                        //если получено столько байт сколько в строке для сравнения или больше
                        if (iGotByte >= compVals.Count)
                        {
                            //compVals.Contains()
                            //получаем строчку проверочного шаблона
                            char [] arrCompVals = Encoding.ASCII.GetChars(compVals.ToArray());
                            string strPattern = string.Join("", arrCompVals);
                            //получаем строчку полученого из порта
                            char[] arrChar = Encoding.ASCII.GetChars(_receiveBuff.ToArray());
                            string strRcvData = string.Join("", arrChar);
                            if(strRcvData.Contains(strPattern) == true)
                            {
                                result = ResRcvNBytes.Succes;
                                break;
                            }

                        }
                    }
                }

                //мотаем свой счетчик и по нему выходим если он досчитался. iGotByte
                if (iGotByte < _iReceiveByte)
                    iGotByte++;
                if (iGotByte >= nByte)
                {
                    Thread.Sleep(1000);
                    result = ResRcvNBytes.NBytesRcvAchieved;
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
            RxClearFull();
            return result;
        }

        enum ModeReceive
        {
            Undef = 0,              //когда не смогли определить режимработы
            StrictEquality = 1,     //строгое соответствие. режим приема при котором успешный прием, это прием ровно такого количества и качества (содержимого) байт которое было обозначено в начале
            OneByteEquIsSucces = 2,  //прием считается успешным когда среди в принятой последовательности содержиться один байт bytesOfPattern и при этом просили тоже только один 
            SequencEquIsSucces = 3      //нестрогое соответствие. в принятой последовательности должен быть заданный кусок
        }


        //принять байты из порта. обертка над ReceiveNByte() обеспечивающая проверку на совпадение принятого с заданной последовательностью
        public ResWaitBytesFoo WaitReceiveThisBytes(
            ref List<byte> bytesOfPattern,                  //ждем таких байт
            float timeOut,                                  //максимальное время ожидания приема байт
            short nMaxBytesWait = 0)//не менее стольки байт ждем прежде чем завершить ожидание. если ранее досчитается таймаут выходим по нему
        {
            
            List<byte> bytesOfPort = new List<byte>();
            ModeReceive modeReceive = ModeReceive.Undef;//надеемся на авто определение режима приема
            ResWaitBytes detailedResult = ResWaitBytes.Непонятен_неизвестен;
            SimplResult simplResult = SimplResult.Wrong;

            //определяемся с режимом работы
            if (bytesOfPattern.Count == 1)
                modeReceive = ModeReceive.OneByteEquIsSucces;
            else if (bytesOfPattern.Count > 1 && nMaxBytesWait == 0)
                modeReceive = ModeReceive.StrictEquality;
            else if (bytesOfPattern.Count > 1 && nMaxBytesWait > bytesOfPattern.Count)//навырост нечеткое соответствие последовательности
                modeReceive = ModeReceive.SequencEquIsSucces;


            //если не указиваем число ожидаемых байт явно, это число берем из длины массива. тогда успешное завершение будет только в случае строго совпадения
            short nBytesWaitIn;
            if (nMaxBytesWait > 0)
                nBytesWaitIn = nMaxBytesWait;
            else
                nBytesWaitIn = (short)(bytesOfPattern.Count);


            //byte []bytes = Encoding.ASCII.GetBytes(chars);
            //List<byte> bytesOfPattern = bytes.ToList();


            //подождем
            COM.ResRcvNBytes resultRcv = ResRcvNBytes.Undef;
            if (modeReceive == ModeReceive.OneByteEquIsSucces || modeReceive == ModeReceive.SequencEquIsSucces)
                resultRcv = ReceiveNByte(ref bytesOfPort, nBytesWaitIn, timeOut, bytesOfPattern, true, ConfigReсeiveNByte.DuringWorkEquSequence);
            else if(modeReceive == ModeReceive.StrictEquality)
                resultRcv = ReceiveNByte(ref bytesOfPort, nBytesWaitIn, timeOut, bytesOfPattern);

            //посмотрим результат после ожидания
            if (resultRcv == COM.ResRcvNBytes.TimeOut)
                detailedResult = ResWaitBytes.Не_уложилась_в_заданное_время;
            else if (resultRcv == COM.ResRcvNBytes.NBytesIsSmall)
                detailedResult = ResWaitBytes.Байтов_слишком_мало;
            else if(resultRcv == COM.ResRcvNBytes.NBytesRcvAchieved)
                detailedResult = ResWaitBytes.Заданное_число_байт_принято;

            else if (resultRcv == COM.ResRcvNBytes.Succes)
            {
                    detailedResult = ResWaitBytes.Успешный;
                    simplResult = SimplResult.OK;
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
                resultBytes.Clear();
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
                lResult.Clear();
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
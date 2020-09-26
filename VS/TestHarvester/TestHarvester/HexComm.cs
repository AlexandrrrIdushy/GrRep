using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarvester
{

    public enum ResWaitBytes
    {
        //название как продолжение фразы результат работы функции _______
        Непонятен_неизвестен,
        Не_уложилась_в_заданное_время,
        Неверный_формат_последовательнсти_байт,
        Байтов_слишком_мало,
        Успешный
    }

    public enum SimplResult
    {
        //простой результат
        OK,
        Wrong
    }

    public class ResWaitBytesFoo
    {
        public ResWaitBytes Detailed;
        public SimplResult Simple;
    }


        //пользовательские основные команды применяемые для тестирования обмена
    public class SimpleComm
    {
        COM _com;
        MainForm _oMainForm;
        public void SimpleCommInit(ref COM com, ref MainForm oMainForm)
        {
            _com = com;
            _oMainForm = oMainForm;
        }

        public enum РежимПриемаБайт
        {
            Стандарт = 0,         //ReceiveNByte() запусается стандартным образом - значение по умолчанию
            ПредварительнаяОчисткаБуфера = 1  //сперва очистить буфер приема
        }


        public ResWaitBytesFoo Ждать_приема_таких_байт(string needBytes, float sec, РежимПриемаБайт conf = РежимПриемаБайт.Стандарт)
        {
            _oMainForm.WriteLogMessage("запускается Ждать_приема_таких_байт(" + needBytes + ")");
            List<byte> bytesOfPort = new List<byte>();
            List<byte> bytesOfPattern = new List<byte>();
            ResWaitBytes detailedResult = ResWaitBytes.Непонятен_неизвестен;
            SimplResult simplResult = SimplResult.Wrong;
            string []  bytesOfPatternArr = needBytes.Split(' ');
            try
            {
                foreach (string item in bytesOfPatternArr)
                {
                    bytesOfPattern.Add(Convert.ToByte(item, 16));
                }
            }
            catch (Exception)
            {
                detailedResult = ResWaitBytes.Неверный_формат_последовательнсти_байт;
                throw;
            }

            if (detailedResult != ResWaitBytes.Неверный_формат_последовательнсти_байт) 
            {
                COM.ResRcvNBytes resultRcv = _com.ReceiveNByte(ref bytesOfPort, (short)(bytesOfPattern.Count), sec, (COM.ConfigReseiveNByte) conf);
                if (resultRcv == COM.ResRcvNBytes.TimeOut)
                    detailedResult = ResWaitBytes.Не_уложилась_в_заданное_время;
                else if (resultRcv == COM.ResRcvNBytes.NBytesIsSmall)
                    detailedResult = ResWaitBytes.Байтов_слишком_мало;
                else if (resultRcv == COM.ResRcvNBytes.Succes)
                {
                    if (bytesOfPort.SequenceEqual(bytesOfPattern))
                    {
                        detailedResult = ResWaitBytes.Успешный;
                        simplResult = SimplResult.OK;
                    }
                }

            }

            _oMainForm.WriteLogMessage("завершение. результат функции " + detailedResult.ToString());

            ResWaitBytesFoo res = new ResWaitBytesFoo();
            res.Simple = simplResult;
            res.Detailed = detailedResult;
            return res;
        }

        public void Отправить_такие_байты(string stringBytes)
        {
            _oMainForm.WriteLogMessage("отработала Отправить_такие_байты(" + stringBytes + ")");
            List<byte> bytesOfPattern = new List<byte>();
            char[] resultChars;
            try
            {
                string[] splitedBytesOfStr = stringBytes.Split(' ');
                foreach (string item in splitedBytesOfStr)
                {
                    bytesOfPattern.Add(Convert.ToByte(item, 16));
                }
                byte[] bytes = bytesOfPattern.ToArray();
                resultChars = Encoding.ASCII.GetChars(bytes);// Unicode.GetChars(bytes, 0 , 2);
                _com.Write(ref resultChars);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Тест_просто_вывести_сообщение(string str)
        {
            System.Windows.Forms.MessageBox.Show("Сообщение из класса SimpleComm - '" + str + "'");
        }
    }
}

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
        Logging _logging;
        public void SimpleCommInit(ref COM com, ref Logging logging)
        {
            _com = com;
            _logging = logging;
        }





        public ResWaitBytesFoo Ждать_приема_таких_байт(string needBytes, float sec)
        {
            _logging.WriteMessage("запускается Ждать_приема_таких_байт()");
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
                COM.ResRcvNBytes resultRcv = _com.ReceiveNByte(ref bytesOfPort, (short)(bytesOfPattern.Count), sec);
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

            _logging.WriteMessage("завершилась Ждать_приема_таких_байт()");
            _logging.WriteMessage("результат функции" + detailedResult.ToString());

            ResWaitBytesFoo res = new ResWaitBytesFoo();
            res.Simple = simplResult;
            res.Detailed = detailedResult;
            return res;
        }

        public void Отправить_такие_байты(string bytes)
        {
            _com.SendBytes(bytes);
        }

        public void Тест_просто_вывести_сообщение(string str)
        {
            System.Windows.Forms.MessageBox.Show("Сообщение из класса SimpleComm");
        }
    }
}

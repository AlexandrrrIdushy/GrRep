using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarvester
{
    //пользовательские основные команды применяемые для тестирования обмена
    public class SimpleComm
    {
        COM _com;
        public void SetCOM(ref COM com)
        {
            _com = com;
        }

        public enum ResWaitBytes
        {
            Undef,
            Timeout,
            PatternIsWrong,
            ByteIsSmall,
            Succes
        }

        public ResWaitBytes Ждать_приема_таких_байт(string needBytes, float sec)
        {
            List<byte> bytesOfPort = new List<byte>();
            List<byte> bytesOfPattern = new List<byte>();
            ResWaitBytes result = ResWaitBytes.Undef;
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
                return ResWaitBytes.PatternIsWrong;
                throw;
            }


            COM.ResRcvNBytes resultRcv = _com.ReceiveNByte(ref bytesOfPort, (short)(bytesOfPattern.Count), sec);
            if (resultRcv == COM.ResRcvNBytes.TimeOut)
                return ResWaitBytes.Timeout;
            else if(resultRcv == COM.ResRcvNBytes.NBytesIsSmall)
                return ResWaitBytes.ByteIsSmall;
            else if(resultRcv == COM.ResRcvNBytes.Succes)
            {
                if(bytesOfPort.SequenceEqual(bytesOfPattern))
                    return ResWaitBytes.Succes;
            }
                

            return ResWaitBytes.Undef;
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

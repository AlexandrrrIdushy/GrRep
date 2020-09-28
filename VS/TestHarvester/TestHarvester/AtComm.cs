using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarvester
{
    public class AtComm
    {
        COM _com;
        MainForm _oMainForm;
        public void AtCommInit(ref COM com, ref MainForm oMainForm)
        {
            _com = com;
            _oMainForm = oMainForm;
        }

        public void Отправить_SMS(string textSendSMS)
        {
            _oMainForm.WriteLogMessage("Отправить_SMS(" + textSendSMS + ")");

            //конвертим текст SMS в массив char
            List<byte> bytesOfPattern = new List<byte>();
            char[] resultChars;
            try
            {
                char[] splitedBytesOfStr = textSendSMS.ToCharArray();
                foreach (char item in splitedBytesOfStr)
                {
                    bytesOfPattern.Add(Convert.ToByte(item));
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
    }
}

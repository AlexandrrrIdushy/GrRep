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
            char[] resultChars = new char[textSendSMS.Length];
            _com.GetASCIBytesFromString(textSendSMS, ref resultChars);
            _com.Write(ref resultChars);
        }
    }
}

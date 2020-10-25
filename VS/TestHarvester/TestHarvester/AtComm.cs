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
        SimpleComm _simpleComm;
        public void AtCommInit(ref COM com, ref MainForm oMainForm, ref SimpleComm simpleComm)
        {
            _com = com;
            _oMainForm = oMainForm;
            _simpleComm = simpleComm;
        }

        public void Отправить_SMS(string textSendSMS)
        {
            _oMainForm.WriteLogMessage("Отправить_SMS(" + textSendSMS + ")");

            //просим у GSM сети соизволения отправить SMS
            string comandSendSMSStart = "AT+CMGS=\"+79053222209\"";
            char[] resultChars = new char[comandSendSMSStart.Length];
            _com.GetASCIBytesFromString(comandSendSMSStart, ref resultChars);
            _com.Write(ref resultChars);

            ////ждем приглашение на ввод текста SMS
            //ResWaitBytesFoo result = _simpleComm.Ждать_приема_таких_байт(">", 10);
            //if (result.Detailed == ResWaitBytes.Успешный)
            //{
            //    char[] resultChars2 = new char[textSendSMS.Length];
            //    _com.GetASCIBytesFromString(textSendSMS, ref resultChars);
            //    _com.Write(ref resultChars);
            //}

            //
        }
    }
}

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
            string comandSendSMSStart = "AT+CMGS=\"+79053222209\"\r\n";
            char[] resultChars = new char[comandSendSMSStart.Length];
            _com.GetASCIBytesFromString(comandSendSMSStart, ref resultChars);
            _com.Write(ref resultChars);

            //ждем приглашение на ввод текста SMS
            string waitSimb = ">";
            char[] waitChars = new char[1];
            _com.GetASCIBytesFromString(waitSimb, ref resultChars);
            ResWaitBytesFoo result = _com.WaitReceiveThisBytes(ref resultChars, 10, РежимПриемаБайт.Стандарт, 30);
            _oMainForm.WriteLogMessage("результат " + result.Detailed.ToString());

            if (result.Detailed == ResWaitBytes.Байтов_мало_но_один_совпал)
            {
                string simbEndSMSText = Convert.ToChar(26).ToString();
                textSendSMS += simbEndSMSText;
                char[] resultChars2 = new char[textSendSMS.Length];
                _com.GetASCIBytesFromString(textSendSMS, ref resultChars);
                
                _com.Write(ref resultChars);
            }

            //
        }
    }
}

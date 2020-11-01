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
            List<byte> bytes4Write = new List<byte>();
            _com.GetASCIBytesFromString(comandSendSMSStart, ref bytes4Write);
            _com.Write(ref bytes4Write);

            //ждем приглашение на ввод текста SMS
            string waitSimb = ">";
            List<byte> waitByte = new List<byte>();
            _com.GetASCIBytesFromString(waitSimb, ref waitByte);

            //byte []bytes = Encoding.ASCII.GetBytes(resultChars);
            //List<byte> bytesOfPattern = bytes.ToList();

            ResWaitBytesFoo result = _com.WaitReceiveThisBytes(ref waitByte, 10, 30);
            _oMainForm.WriteLogMessage("результат " + result.Detailed.ToString());

            if (result.Detailed == ResWaitBytes.Успешный)
            {
                string simbEndSMSText = Convert.ToChar(26).ToString();
                textSendSMS += simbEndSMSText;
                char[] resultChars2 = new char[textSendSMS.Length];
                _com.GetASCIBytesFromString(textSendSMS, ref bytes4Write);
                
                _com.Write(ref bytes4Write);
            }

            //
        }
    }
}

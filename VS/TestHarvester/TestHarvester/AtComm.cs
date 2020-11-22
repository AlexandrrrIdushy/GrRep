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
        List<byte> _bytes4Write;
        List<byte> _waitByte;
        public void AtCommInit(ref COM com, ref MainForm oMainForm, ref SimpleComm simpleComm)
        {
            _com = com;
            _oMainForm = oMainForm;
            _simpleComm = simpleComm;
            _bytes4Write = new List<byte>();
            _waitByte = new List<byte>();
        }

        public bool Подготовить_модуль_SIM5300E_к_работе_c_SMS()
        {
            _oMainForm.WriteLogMessage("Подготовить_модуль_SIM5300E_к_работе_c_SMS()");
            string comandSendSMSStart = "AT+CMGF=1\r\n";
            _bytes4Write.Clear();
            _com.GetASCIBytesFromString(comandSendSMSStart, ref _bytes4Write);
            _com.Write(ref _bytes4Write);


            //ждем приглашение на ввод текста SMS
            string waitSimb = "OK";
            _waitByte.Clear();
            _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
            ResWaitBytesFoo result = _com.WaitReceiveThisBytes(ref _waitByte, 10, 30);
            _oMainForm.WriteLogMessage("результат " + result.Detailed.ToString());

            return true;
        }

        public void Отправить_SMS(string textSendSMS)
        {
            _oMainForm.WriteLogMessage("Отправить_SMS(" + textSendSMS + ")");

            //просим у GSM сети соизволения отправить SMS
            string comandSendSMSStart = "AT+CMGS=\"+79053222209\"\r\n";
            _bytes4Write.Clear();
            _com.GetASCIBytesFromString(comandSendSMSStart, ref _bytes4Write);
            _com.Write(ref _bytes4Write);

            //ждем приглашение на ввод текста SMS
            string waitSimb = ">";
            _waitByte.Clear();
            _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
            ResWaitBytesFoo result = _com.WaitReceiveThisBytes(ref _waitByte, 10, 30);
            _oMainForm.WriteLogMessage("результат " + result.Detailed.ToString());

            if (result.Detailed == ResWaitBytes.Успешный)
            {
                string simbEndSMSText = Convert.ToChar(26).ToString();
                textSendSMS += simbEndSMSText;
                char[] resultChars2 = new char[textSendSMS.Length];
                _com.GetASCIBytesFromString(textSendSMS, ref _bytes4Write);
                
                _com.Write(ref _bytes4Write);
            }

            //
        }


        public void Ожидать_SMS(string textSendSMS, float second)
        {
            _oMainForm.WriteLogMessage("Ожидать_SMS(" + textSendSMS + ")");
            ResWaitBytesFoo result;

            //после прихода SMS, SIM800L генерирует незапрашиваемое уведомление вида +CMTI: "SM",4
            string waitSimb = "+CMTI: \"SM\"";
            _waitByte.Clear();
            _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
            result = _com.WaitReceiveThisBytes(ref _waitByte, 10, 30);

            //После прихода такого уведомления, можно программно инициировать процедуру чтения полученного сообщения 
            string comandSendSMSStart = "AT+CMGR=1,0\r\n";
            _bytes4Write.Clear();
            _com.GetASCIBytesFromString(comandSendSMSStart, ref _bytes4Write);
            _com.Write(ref _bytes4Write);

            //ждем требуемый текст
            waitSimb = textSendSMS;// "+CMGR:";
            _waitByte.Clear();
            _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
            result = _com.WaitReceiveThisBytes(ref _waitByte, 10, Convert.ToByte(textSendSMS.Length + 60 + 10));

            //после получения и обработки пришедшего сообщения, все сообщения удаляются
            comandSendSMSStart = "AT+CMGD=1,4\r\n";
            _bytes4Write.Clear();
            _com.GetASCIBytesFromString(comandSendSMSStart, ref _bytes4Write);
            _com.Write(ref _bytes4Write);

            if (result.Detailed.ToString() == "Успешный")
                _oMainForm.WriteLogMessage("     Ok");
            else
                _oMainForm.WriteLogMessage("результат " + result.Detailed.ToString());

        }
    }
}

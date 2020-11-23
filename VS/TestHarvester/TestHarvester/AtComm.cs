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
            _com.GetASCIBytesFromString(comandSendSMSStart, ref _bytes4Write);
            _com.Write(ref _bytes4Write);


            //ждем приглашение на ввод текста SMS
            string waitSimb = "OK";
            _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
            ResWaitBytesFoo result = _com.WaitReceiveThisBytes(ref _waitByte, 10, 30/*Convert.ToByte(waitSimb.Length + 5)*/);
            _oMainForm.WriteLogMessage("результат " + result.Detailed.ToString());

            return true;
        }

        public void Отправить_SMS(string textSendSMS)
        {
            _oMainForm.WriteLogMessage("Отправить_SMS(" + textSendSMS + ")");

            //просим у GSM сети соизволения отправить SMS
            string comandSendSMSStart = "AT+CMGS=\"+79053222209\"\r\n";
            _com.GetASCIBytesFromString(comandSendSMSStart, ref _bytes4Write);
            _com.Write(ref _bytes4Write);

            //ждем приглашение на ввод текста SMS
            string waitSimb = ">";
            _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
            ResWaitBytesFoo result = _com.WaitReceiveThisBytes(ref _waitByte, 10, 30/*Convert.ToByte(waitSimb.Length + 20)*/);

            if (result.Detailed == ResWaitBytes.Успешный)
            {
                string simbEndSMSText = Convert.ToChar(26).ToString();
                textSendSMS += simbEndSMSText;
                char[] resultChars2 = new char[textSendSMS.Length];
                _com.GetASCIBytesFromString(textSendSMS, ref _bytes4Write);
                
                _com.Write(ref _bytes4Write);
            }


            waitSimb = "OK";
            _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
            result = _com.WaitReceiveThisBytes(ref _waitByte, 10, 60);

            if (result.Detailed.ToString() == "Успешный")
                _oMainForm.WriteLogMessage("     Ok");
            else
                _oMainForm.WriteLogMessage("результат " + result.Detailed.ToString());
        }


        public void Ожидать_SMS(string textSendSMS, float second)
        {
            _oMainForm.WriteLogMessage("Ожидать_SMS(" + textSendSMS + ")");
            ResWaitBytesFoo result;

            //после прихода SMS, SIM800L генерирует незапрашиваемое уведомление вида +CMTI: "SM",4
            string waitSimb = "+CMTI: \"SM\"";
            _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
            result = _com.WaitReceiveThisBytes(ref _waitByte, 20, 30);

            if (result.Simple == SimplResult.OK)
            {
                //После прихода такого уведомления, можно программно инициировать процедуру чтения полученного сообщения 
                string comandSendSMSStart = "AT+CMGR=1,0\r\n";
                _com.GetASCIBytesFromString(comandSendSMSStart, ref _bytes4Write);
                _com.Write(ref _bytes4Write);

                //ждем требуемый текст
                waitSimb = textSendSMS;// "+CMGR:";
                _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
                result = _com.WaitReceiveThisBytes(ref _waitByte, 20, Convert.ToByte(textSendSMS.Length + 60 + 20));

                //после получения и обработки пришедшего сообщения, все сообщения удаляются
                comandSendSMSStart = "AT+CMGD=1,4\r\n";
                _com.GetASCIBytesFromString(comandSendSMSStart, ref _bytes4Write);
                _com.Write(ref _bytes4Write);

                if (result.Detailed.ToString() == "Успешный")
                    _oMainForm.WriteLogMessage("     Ok");
                else
                    _oMainForm.WriteLogMessage("результат " + result.Detailed.ToString());
            }
            else
                _oMainForm.WriteLogMessage("GSM сеть молчит (сообщения CMTI нет)");



        }
    }
}

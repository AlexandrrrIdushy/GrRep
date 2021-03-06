﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestHarvester
{
    public class AtComm
    {
        COM _com;
        MainForm _oMainForm;
        SimpleComm _simpleComm;
        List<byte> _bytes4Write;
        List<byte> _waitByte;
        string _phoneNumber;
        public void SetPhoneNumber(string phoneNumber)
        {
            _oMainForm.AddMsgCommon("целевой телефон = " + phoneNumber);
            _phoneNumber = phoneNumber;
        }
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
            bool resBool = false;
            string phasesWork = "ничего не выполнено";//успешно пройденные фазы отправки
            _oMainForm.WriteLogMessage("Отправить_SMS(" + textSendSMS + ")");

            //просим у GSM сети соизволения отправить SMS
            string comandSendSMSStart = "AT+CMGS=\"+" + _phoneNumber + "\"\r\n";
            _com.GetASCIBytesFromString(comandSendSMSStart, ref _bytes4Write);
            resBool = false;
            resBool = _com.Write(ref _bytes4Write);
            ResWaitBytesFoo result = new ResWaitBytesFoo();
            result.Detailed = ResWaitBytes.Непонятен_неизвестен;
            result.Simple = SimplResult.Wrong;
            if (resBool)
            {
                phasesWork = "#1:AT+CMGS - Ok";
                //ждем приглашение на ввод текста SMS
                string waitSimb = ">";
                _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
                result = _com.WaitReceiveThisBytes(ref _waitByte, 10, 30/*Convert.ToByte(waitSimb.Length + 20)*/);
                if (result.Simple == SimplResult.OK)
                {
                    phasesWork += ", #2:получение > - Ok";
                    //если дождались приглашения, то вводим текст SMS
                    string simbEndSMSText = Convert.ToChar(26).ToString();
                    textSendSMS += simbEndSMSText;
                    char[] resultChars2 = new char[textSendSMS.Length];
                    _com.GetASCIBytesFromString(textSendSMS, ref _bytes4Write);
                    resBool = false;
                    resBool = _com.Write(ref _bytes4Write);
                    if (resBool)
                    { 
                        phasesWork += ", #3:Ввод текста SMS - Ok";
                        //осталось дождаться завершающего окея                           
                        waitSimb = "OK";
                        _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
                        result = _com.WaitReceiveThisBytes(ref _waitByte, 10, 60);
                        if (result.Detailed == ResWaitBytes.Успешный)
                            phasesWork += ", #4:получение \"OK\"> - Ok";
                    }
                }
            }

            Thread.Sleep(5000);
            if (result.Detailed == ResWaitBytes.Успешный)
                _oMainForm.WriteLogMessage("     Ok");
            else
                _oMainForm.WriteLogMessage("результат " + result.Detailed.ToString() + "/r/nТрассы: " + phasesWork);
        }


        public void Ожидать_SMS(string textSendSMS, float second)
        {
            _oMainForm.WriteLogMessage("Ожидать_SMS(" + textSendSMS + ")");
            ResWaitBytesFoo result = new ResWaitBytesFoo();
            bool resBool = false;
            result.Detailed = ResWaitBytes.Непонятен_неизвестен;
            result.Simple = SimplResult.Wrong;
            string phasesWork = "ничего не выполнено";//успешно пройденные фазы отправки
            string comandSendSMSStart;

            //после прихода SMS, SIM800L генерирует незапрашиваемое уведомление вида +CMTI: "SM",4
            string waitSimb = "+CMTI: \"SM\"";
            _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
            result = _com.WaitReceiveThisBytes(ref _waitByte, 20, 30);
            
            if (result.Simple == SimplResult.OK)
            {
                phasesWork = "#1:пришло уведамление о приходе SMS (+CMTI:\"SM\")";
                //После прихода такого уведомления, можно программно инициировать процедуру чтения полученного сообщения 
                resBool = false;
                comandSendSMSStart = "AT+CMGR=1,0\r\n";
                _com.GetASCIBytesFromString(comandSendSMSStart, ref _bytes4Write);
                resBool = _com.Write(ref _bytes4Write);

                if (resBool)
                {
                    phasesWork = " ,#2:отправили запрос на чтение текста SMS (AT+CMGR)";
                    //ждем требуемый текст
                    waitSimb = textSendSMS;// "+CMGR:";
                    _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
                    result = _com.WaitReceiveThisBytes(ref _waitByte, 20, Convert.ToByte(textSendSMS.Length + 60 + 20));
                    if (result.Simple == SimplResult.OK)
                        phasesWork = "#3:пришел текст и он совпадает с шаблоном";

                }


            }

            //независимо от результатов предыдущих операция требуется выполнить очистку, все сообщения удаляются. 
            //при переполнении SIM начинает глючить - перестают приходить сообщения типа +CMTI: "SM",N
            resBool = false;
            comandSendSMSStart = "AT+CMGD=1,4\r\n";
            _com.GetASCIBytesFromString(comandSendSMSStart, ref _bytes4Write);
            resBool = _com.Write(ref _bytes4Write);
            if (resBool)
            {
                phasesWork += ", #4:чистим память от SMS (AT+CMGD)";
                //осталось дождаться завершающего окея                           
                waitSimb = "OK";
                _com.GetASCIBytesFromString(waitSimb, ref _waitByte);
                result = _com.WaitReceiveThisBytes(ref _waitByte, 10, 60);
                if (result.Detailed == ResWaitBytes.Успешный)
                    phasesWork += ", #5:получение \"OK\"> - Ok";
            }


            Thread.Sleep(5000);
            if (result.Detailed == ResWaitBytes.Успешный)
                _oMainForm.WriteLogMessage("     Ok");
            else
                _oMainForm.WriteLogMessage("результат " + result.Detailed.ToString());

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace TestHarvester
{
    public class COM
    {

        //НИЖНИЙ СЛОЙ
        private byte[] _rxdata;
        int _rxidx;
        private SerialPort _serialPort;
        private const int WAIT_ANSWER_TIMEOUT = 500;
        //private log logfile;
        ///public string COM = "";
        public string errtxt = "";

        MainForm _mainForm;
        public void SetObjForm(ref MainForm mainForm)
        {
            _mainForm = mainForm;
        }



        private void RxReset()
        {
            _rxidx = 0;
            _rxdata[0] = 0;
        }

        //Конструктор
        public COM()
        {
            _serialPort = new SerialPort();
            //logfile = new log(this.GetType().ToString());
            _rxdata = new byte[256];
        }
        public int Ctn = 0;
        public int Tmp = 0;
        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            SerialPort sp = (SerialPort)sender;
            try
            {
                while (0 != sp.BytesToRead)
                {
                    if (_rxidx < _rxdata.Length - 2)// если есть что то не взятое из приемного буфера - забираем. -2 потому что 1 на то что индекс, 1 на то что хотябы на один больше чем в пользовательском буфере
                    {
                        _rxdata[_rxidx++] = (byte)sp.ReadByte();//прочитать один байт из приемного буфера
                        _rxdata[_rxidx] = 0;//в последнем всегда будет ноль
                    }
                    else
                        sp.ReadByte();
                }
            }
            catch (Exception ex)
            {
                //logfile.write(ex.Message);
                errtxt = ex.Message;
            }
            Ctn++;
            Tmp = _rxidx;
        }


        public void SetComPort(string namePort)
        {
            try
            {
                _serialPort.PortName = namePort;
            }
            catch (Exception)
            {
                _mainForm.AddErrorsAndWarinigs("ошибка при выборе Com порта");
            }
        }
        
        public void SetPortSpeed(string сomPortSpeed)
        {
            try
            {
                _serialPort.BaudRate = Convert.ToInt32(сomPortSpeed);
            }
            catch (Exception)
            {
                _mainForm.AddErrorsAndWarinigs("ошибка при выборе Com порта");
            }
        }

        public void SetPortParity(byte comPortParity)
        {
            try
            {
                _serialPort.Parity = (Parity)comPortParity;
            }
            catch (Exception)
            {
                _mainForm.AddErrorsAndWarinigs("ошибка при выборе Com порта");
            }
        }

        public string GetCurrComPortName()
        {
            return _serialPort.PortName;
        }

        public void OpenPort()
        {
            //открываем com порт
            try
            {
                _serialPort.Open();
            }
            catch (Exception)
            {
                _mainForm.AddErrorsAndWarinigs("не получилось открыть Com порт");
            }
        }

        public void InitCOMStartVals()
        {
            _serialPort.BaudRate = 115200;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
            // Создание обработчика события для приема данных:
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.WriteTimeout = 50;
        }

        private void Close()
        {
            _serialPort.Close();
        }

        private String Received()
        {
            return Encoding.GetEncoding(1251).GetString(_rxdata);
        }

        private bool Write(ref List<byte> list)
        {
            bool result;
            int cnt = senddata.Length;
            int i = 0;
            int tumeoutcnt = 0;

            errtxt = "";
            try
            {
                RxReset();
                for (i = 0; i < cnt; i++)
                {
                    char sym = senddata[i];
                    _serialPort.Write(sym.ToString());
                    tumeoutcnt = 50;
                    while (!Received().Contains(senddata.Substring(0, i + 1))
                           && (0 != tumeoutcnt))
                    {
                        //Thread.Sleep(10);
                        tumeoutcnt--;
                    }
                }
            }
            catch (Exception ex)
            {
                //logfile.write(ex.Message);
                errtxt = ex.Message;
            }
            result = (i == cnt) && (0 != tumeoutcnt);
            return result;
        }


        //ВЕРХНИЙ СЛОЙ
        public enum ResRcvNBytes
        {
            Undef,
            NBytesIsSmall,
            TimeOut,
            Byte,
            Succes
        }


        //ждать приема N байт из порта. true - нужное число байт получено. false - время истекло, а нужного числа байт нет
        public ResRcvNBytes ReceiveNByte(ref List<byte> list,   //полученые байты
                                        Int16 nByte,            //количество байт которое требуется получить
                                    float timeoutS)             //таймаут на получение этого количества байт [s]
        {
            //RxReset();
            UInt16 timeout100ms = (UInt16)(timeoutS * 10f);
            _cntTickWaitReceive = 0;
            UInt16 iGotByte = 0;
            ResRcvNBytes result;
            while (true)
            {
                if (iGotByte < _rxidx)
                { 
                    
                    iGotByte++;
                    
                }
                if (iGotByte >= nByte)
                {
                    result = ResRcvNBytes.Succes;
                    break;
                }
                if (_cntTickWaitReceive > timeout100ms)
                {
                    result = ResRcvNBytes.TimeOut;
                    break;
                }

            }
            for (int i = 0; i < nByte; i++)
            {
                list.Add(_rxdata[i]);
            }
            
            return ResRcvNBytes.Succes;
        }

        //отправить последовательность байт в порт
        public void SendBytes(ref List<byte> list)
        {
            Write(ref list);
        }

        //тикаем в ожидании завершения приема
        UInt16 _cntTickWaitReceive;

        public void OneTickWaitReceive()
        {
            _cntTickWaitReceive++;
        }

    }
}
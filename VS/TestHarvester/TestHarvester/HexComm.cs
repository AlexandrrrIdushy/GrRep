﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarvester
{

    public enum ResWaitBytes
    {
        //название как продолжение фразы результат работы функции _______
        Непонятен_неизвестен,
        Не_уложилась_в_заданное_время,
        Неверный_формат_последовательнсти_байт,
        Заданное_число_байт_принято,
        Байтов_мало_но_один_совпал,
        Байтов_слишком_мало,
        Успешный
    }

    public enum SimplResult
    {
        //простой результат
        OK,
        Wrong
    }

    public class ResWaitBytesFoo
    {
        public ResWaitBytes Detailed;
        public SimplResult Simple;
    }


        //пользовательские основные команды применяемые для тестирования обмена
    public class SimpleComm
    {
        COM _com;
        MainForm _oMainForm;
        public void SimpleCommInit(ref COM com, ref MainForm oMainForm)
        {
            _com = com;
            _oMainForm = oMainForm;
        }


        public ResWaitBytesFoo Ждать_приема_таких_байт(string needBytes, float sec, РежимПриемаБайт conf = РежимПриемаБайт.Стандарт)
        {
            _oMainForm.WriteLogMessage("Ждать_приема_таких_байт(" + needBytes + ")");
            char[] resultChars = new char[needBytes.Length];
            List<byte> resultByte = new List<byte>();
            _com.GetHexFromString(needBytes, ref resultByte);
            ResWaitBytesFoo result = _com.WaitReceiveThisBytes(ref resultByte, sec);
            _oMainForm.WriteLogMessage("результат " + result.Detailed.ToString());
            return result;
        }



        public void Отправить_такие_байты(string stringBytes)
        {
            _oMainForm.WriteLogMessage("отработала Отправить_такие_байты(" + stringBytes + ")");
            List<byte> bytes = new List<byte>();
            _com.GetHexFromString(stringBytes, ref bytes);
            _com.Write(ref bytes);
        }

        public void Записать_сообщение(string str)
        {
            _oMainForm.WriteLogMessage(str);
        }

        public void Тест_просто_вывести_сообщение(string str)
        {
            System.Windows.Forms.MessageBox.Show("Сообщение из класса SimpleComm - '" + str + "'");
        }
    }
}

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






        public void Отправить_такие_байты(string stringBytes)
        {
            _oMainForm.WriteLogMessage("отработала Отправить_такие_байты(" + stringBytes + ")");
            char[] resultChars = new char[stringBytes.Length];
            _com.GetHexFromString(stringBytes, ref resultChars);
            _com.Write(ref resultChars);
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

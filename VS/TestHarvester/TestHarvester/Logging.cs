using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestHarvester
{
    public class Logging
    {
        DateTime _date;
        string _path4LogFile;

        //назначить путь и имя файла лога. проинициализировать дополнительные параметры
        public void PointPath(string path, string name)
        {
            _path4LogFile = path + name;
            _date = new DateTime();
        }

        //записать сообщение содержащее информацию, время
        public void WriteLogMessage(string message)
        {
            string strDate = _date.TimeOfDay.ToString();
            string resStr = message + strDate + "\r\n";

            using (FileStream stream = new FileStream(_path4LogFile, FileMode.OpenOrCreate))
            {
                byte[] arrayBytes = Encoding.Default.GetBytes(resStr);
                stream.Write(arrayBytes, 0, arrayBytes.Length);
            }
        }
    }
}

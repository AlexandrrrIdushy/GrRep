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
        public void SimpleCommInit(ref COM com, ref MainForm oMainForm)
        {
            _com = com;
            _oMainForm = oMainForm;
        }

        public void Отправить_такие_байты(string stringBytes)
        {
            _oMainForm.WriteLogMessage("отработала Отправить_такие_байты(" + stringBytes + ")");
            List<byte> bytesOfPattern = new List<byte>();
            char[] resultChars;
            try
            {
                string[] splitedBytesOfStr = stringBytes.Split(' ');
                foreach (string item in splitedBytesOfStr)
                {
                    bytesOfPattern.Add(Convert.ToByte(item, 16));
                }
                byte[] bytes = bytesOfPattern.ToArray();
                resultChars = Encoding.ASCII.GetChars(bytes);// Unicode.GetChars(bytes, 0 , 2);
                _com.Write(ref resultChars);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

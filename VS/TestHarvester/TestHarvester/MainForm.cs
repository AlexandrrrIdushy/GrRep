using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using GrLib;
using System.IO.Ports;

namespace TestHarvester
{

    public partial class MainForm : Form, ISavable
    {
        public MainForm()
        {
            InitializeComponent();
        }
        COM _com1;
        List<byte> _list;
        static public SimpleComm ObjSimpleComm;//
        static public AtComm ObjAtComm;
        Scripting _scripting;//
        Logging _logging;
        MainForm _pMainForm;
        List<string> _messagesCommon;//трех видов информационные , предупрежения ("ALARM: .."), ошибки ("ERR: ..")
        string _pathOfScriptFiles;
        string _selectedComPortName;
        string _selectedComPortSpeed;
        byte _selectedParityIndex;
        //Scripting _scripting;

        static public AccessDBSettings AdbSett;
        static public System.IO.DirectoryInfo PathExeFile;
        byte _version;
        private void Form1_Load(object sender, EventArgs e)
        {
            //выделяем место объектам
            _pMainForm = this;//ссылка на эту форму. для всевозможных обращений
            ObjSimpleComm = new SimpleComm();
            ObjAtComm = new AtComm();
            _scripting = new Scripting();
            _logging = new Logging();//должно выполнятся ранее SimpleCommInit()
            _messagesCommon = new List<string>();
            _com1 = new COM();

            //com порт




            //передаем их ссылки в дочерние классы
            ObjSimpleComm.SimpleCommInit(ref _com1, ref _pMainForm);
            ObjAtComm.AtCommInit(ref _com1, ref _pMainForm, ref ObjSimpleComm);




            _version = 2;
            
            this.Text = "Test Harvester. Ver:" + _version.ToString();
            _pathOfScriptFiles = "";
            
            _messagesCommon.Add("Запуск TestHarvester Ver: " + _version);

            //четность
            foreach (string item in Enum.GetNames(typeof(Parity)))
            {
                this.cbxComPortParity.Items.Add(item.ToString());
            }
            this.cbxComPortParity.SelectedIndex = _selectedParityIndex;



            //работа с сохранением восстановлением настроек приложения
            PathExeFile = new System.IO.DirectoryInfo(".");//получаем полный путь в папку с екзешником программы
            AdbSett = new AccessDBSettings(PathExeFile.FullName);
            Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);//событие закрытия формы создаем вручную

            //список телефонных номеров для отправки
            StreamReader sr = new StreamReader(PathExeFile.FullName + "\\phones.txt");
            while (!sr.EndOfStream)
            {
                //line = sr.ReadLine();
                lbxPhones.Items.Add(sr.ReadLine());
                //бла-бла-бла
            }
            sr.Close();

            //загрузка настроек приложения
            LoadSettings();


            
            
            Init();


           
            


            //выпадающие списки запоняем
            //ком порты
            string[] comPorts = SerialPort.GetPortNames();
            byte iComPort = 0;
            if(comPorts.Length > 0)
            {
                //есть какието порты. проверяем тот что был выбран есть ли среди них. да - выбираем его, нет - сбрасываем
                bool foundLastPort = false;
                foreach (string item in comPorts)
                {
                    this.cbxComPortNumber.Items.Add(item);//добавляем элементы в любом случае
                    if (item == _selectedComPortName)
                    {
                        this.cbxComPortNumber.SelectedIndex = iComPort;
                        foundLastPort = true;
                    }
                    iComPort++;
                }

                //если выбраного в прошлый заход порта нет, сбрасываем значение
                if(!foundLastPort)
                    _selectedComPortName = "";
            }
            else
                //нет портов - опустошить сохряняемое имя порта
                _selectedComPortName = "";




            //скорость порта иниц. комбо бокса
            this.cbxComPortSpeed.Items.Add("1200");
            this.cbxComPortSpeed.Items.Add("2400");
            this.cbxComPortSpeed.Items.Add("4800");
            this.cbxComPortSpeed.Items.Add("9600");
            this.cbxComPortSpeed.Items.Add("14400");
            this.cbxComPortSpeed.Items.Add("19200");
            this.cbxComPortSpeed.Items.Add("38400");
            this.cbxComPortSpeed.Items.Add("56000");
            this.cbxComPortSpeed.Items.Add("57600");
            this.cbxComPortSpeed.Items.Add("115200");
            this.cbxComPortSpeed.Items.Add("128000");
            this.cbxComPortSpeed.Items.Add("230400");
            this.cbxComPortSpeed.Items.Add("256000");
            int iItemSpeed = 0;
            foreach (string item in this.cbxComPortSpeed.Items)
            {
                if (item == _selectedComPortSpeed)
                    this.cbxComPortSpeed.SelectedIndex = iItemSpeed;
                iItemSpeed++;
            }

            _com1.COMInit(ref _pMainForm);
            _com1.SetComPort(_selectedComPortName);
            _com1.InitCOMStartVals();
            _com1.OpenPort();


            FillListFilesScript();//наполняем окно со списком файлов скриптов





            UpdateErrTbx();

            //инициализация лигирование
            _logging.PointPath(_pathOfScriptFiles, "log.txt");
            btnRunLogResult.Text = "РЕЗУЛЬТАТ ЗАПУСКА СКРИПТА";
            btnRunLogResult.Enabled = false;

            //ObjAtComm.Отправить_SMS("First sms from scripter");
            _syncroContext1 = SynchronizationContext.Current;
            _th1 = new Thread(ThrdWrk1);
            _th1.Start(_syncroContext1);

            _phaseWork = PhaseWork.Idle;
            _syncroContext2 = SynchronizationContext.Current;
            _th2 = new Thread(ThrdWrk2);
            _th2.Start(_syncroContext2);
        }



        //ПОТОКИ---
        static Thread _th1;
        static Thread _th2;
        SynchronizationContext _syncroContext1;
        SynchronizationContext _syncroContext2;
        private void ThrdWrk1(object state)
        {
            // вытащим контекст синхронизации из state'а
            SynchronizationContext uiContext = state as SynchronizationContext;
            // говорим что в UI потоке нужно выполнить метод UpdateUI 
            // и передать ему в качестве аргумента строку
            //uiContext.Post(UpdateUI, "stub");
            while (true)
            {
                uiContext.Post(UpdateUI, "stub");
                Thread.Sleep(1000);
            }
        }

        private void ThrdWrk2(object state)
        {
            // вытащим контекст синхронизации из state'а
            SynchronizationContext uiContext = state as SynchronizationContext;
            while (true)
            {
                uiContext.Post(UpdateUI2, "stub2");
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Этот метод исполняется в основном UI потоке
        /// </summary>
        string _str4DSLog = "";
        private void UpdateUI(object state)
        {
            _str4DSLog = _com1.GetLastDataStreemLog();
            if (_str4DSLog != "" && _str4DSLog != null)
                tbxLogsWin.Text = tbxLogsWin.Text + _str4DSLog;//_str4DSLog;
            //tbxLogsWin.Invalidate();
            //this.Refresh();
        }

        enum PhaseWork
        {
            Idle,
            StartScript
        }
        PhaseWork _phaseWork;
        private void UpdateUI2(object state)
        {
            switch (_phaseWork)
            {
                case PhaseWork.Idle:   break;
                case PhaseWork.StartScript:
                    string[] tmp = tbxTextOfCurrScript.Lines;//забираем скрипт из текст бокса
                    _scripting.SetTextOfScript(ref tmp);//передаем его скриптовой машине
                    _scripting.DoCompile(true);//запускаем выполнения скрипта
                    _phaseWork = PhaseWork.Idle;
                    break;
                default:break;
            }


        }
        //---ПОТОКИ


        public void AddMsgCommon(string nextErrMessage)
        {
            _messagesCommon.Add(nextErrMessage);
        }

        void FillListFilesScript()
        {
            lbxFilesWhisScripts.Items.Clear();
            //что с путем к файлам скриптов?
            if (_pathOfScriptFiles == null || _pathOfScriptFiles == "")
                _messagesCommon.Add("\tERR: нет пути к папке со скриптами");
            else
            {
                try
                {
                    string[] allPath = Directory.GetFiles(_pathOfScriptFiles, "*.ths");//test harvester script
                    if(allPath.Length == 0)
                        _messagesCommon.Add("\tERR: не нашли ниодного скрипта в указанной папке");
                    else
                    {
                        foreach (string item in allPath)
                        {
                            lbxFilesWhisScripts.Items.Add(Path.GetFileName(item));
                        }

}
                        
                    
                }
                catch (Exception)
                {
                    _messagesCommon.Add("\tERR: проблеммы при поиске файлов скриптов в указанной папке");
                }
            }
            lblPath.Text = "Путь к скриптам: " + _pathOfScriptFiles;
        }

        void UpdateErrTbx()
        {
            foreach (var item in _messagesCommon)
            {
                tbxErrorInfo.Text += item;
                tbxErrorInfo.Text += Environment.NewLine;
            }
                
        }

        protected void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
        }


        private void btnCompileScript_Click(object sender, EventArgs e)
        {
            string[] tmp = tbxTextOfCurrScript.Lines;
            _scripting.SetTextOfScript(ref tmp);
            _scripting.DoCompile(false);
            tbxErrorInfo.Text = _scripting.GetResultCompile();
        }

        //запустить скрипт на выполение
        private void btnStartScript_Click(object sender, EventArgs e)
        {
            _phaseWork = PhaseWork.StartScript;
            //string[] tmp = tbxTextOfCurrScript.Lines;//забираем скрипт из текст бокса
            //_scripting.SetTextOfScript(ref tmp);//передаем его скриптовой машине
            //_scripting.DoCompile(true);//запускаем выполнения скрипта
            //tbxErrorInfo.Text = _scripting.GetResultCompile();//выводим в тексбокс сообщения об ошибках


            //tbxTextOfCurrScript.Text = File.ReadAllText(pathSelectedScript, Encoding.Default);
        }

        // устанавливаем метод обратного вызова
        TimerCallback _tmr4RxClbck;
        // создаем таймер
        System.Threading.Timer _tmr4Rx;


        void Init()
        {
            int num = 0;
            // устанавливаем метод обратного вызова
            _tmr4RxClbck = new TimerCallback(TicksWaitReceive);
            // создаем таймер. тикает раз в 0.1 s
            _tmr4Rx = new System.Threading.Timer(_tmr4RxClbck, num, 0, 100);

        }

        public void TicksWaitReceive(object obj)
        {
            if(_com1 != null)
            _com1.OneTickWaitReceive();
        }



        //обязательства по контракту ISavable
        public void SaveSettings()
        {
            //AdbSett.WriteOneValueSetting("", );
            AdbSett.WriteOneValueSetting("formTopSETT", this.Top.ToString());
            AdbSett.WriteOneValueSetting("pathOfScriptFilesSETT", _pathOfScriptFiles);
            AdbSett.WriteOneValueSetting("tabControl1SelTabSETT", tabControl1.SelectedIndex.ToString());
            AdbSett.WriteOneValueSetting("cbxComPort1NameSETT", _selectedComPortName);
            AdbSett.WriteOneValueSetting("cbxComPortSpeedSETT", _selectedComPortSpeed);
            AdbSett.WriteOneValueSetting("cbxComPortParitySETT", _selectedParityIndex.ToString());
            AdbSett.WriteOneValueSetting("lbxPhonesSETT", lbxPhones.SelectedIndex.ToString());


            //..еще настройки
            AdbSett.DSSettingsWriteToFile();//пишем из дата сета в файл

        }

        public void LoadSettings()
        {
            AdbSett.DSSettingsReadFromFile();
            // = Convert.ToInt16(AdbSett.ReadOneValueSetting());
            this.Top = Convert.ToInt16(AdbSett.ReadOneValueSetting("formTopSETT"));
            _pathOfScriptFiles = AdbSett.ReadOneValueSetting("pathOfScriptFilesSETT");
            tabControl1.SelectedIndex = Convert.ToInt16(AdbSett.ReadOneValueSetting("tabControl1SelTabSETT"));
            _selectedComPortName = AdbSett.ReadOneValueSetting("cbxComPort1NameSETT");
            _selectedComPortSpeed = AdbSett.ReadOneValueSetting("cbxComPortSpeedSETT");
            _selectedParityIndex = Convert.ToByte(AdbSett.ReadOneValueSetting("cbxComPortParitySETT"));
            lbxPhones.SelectedIndex = Convert.ToInt16(AdbSett.ReadOneValueSetting("lbxPhonesSETT"));

            //логируем
            _messagesCommon.Add("Загружаются следущие настройки:");
            _messagesCommon.Add("Путь к скриптам: \"" + _pathOfScriptFiles.ToString() + "\"");
            _messagesCommon.Add("Порт: " + _selectedComPortName);
            _messagesCommon.Add("Скорость: " + _selectedComPortSpeed);
            _messagesCommon.Add("Четность: " + cbxComPortParity.Text.ToString());
            //..еще настройки
        }

        private void btnSenPath2Script_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "test harvester's script (*.ths)|*.ths|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _pathOfScriptFiles = (openFileDialog.FileName).Substring(0, (openFileDialog.FileName.Length -  openFileDialog.SafeFileName.Length));
                    lblPath.Text = "Путь к скриптам: " + _pathOfScriptFiles;
                }
            }
            catch (Exception)
            {
                _messagesCommon.Add("\tERR: проблемы при попытке указать путь к файлам скриптов");
            }

            FillListFilesScript();
        }

        public void WriteLogMessage(string message)
        {
            tbxRunLog.Text += (message + "\r\n");
            //_logging.WriteLogMessage(tbxRunLog.Text);
            this.Refresh();
        }

        private void lbxFilesWhisScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pathSelectedScript = _pathOfScriptFiles + lbxFilesWhisScripts.SelectedItem.ToString();
            tbxTextOfCurrScript.Text = File.ReadAllText(pathSelectedScript, Encoding.Default);
            //tbxTextOfCurrScript = 
        }

        private void btnRunLogResult_Click(object sender, EventArgs e)
        {

        }

        private void lblCom1Info_Click(object sender, EventArgs e)
        {

        }



        private void cbxComPortSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedComPortSpeed = cbxComPortSpeed.SelectedItem.ToString();
            _com1.SetPortSpeed(_selectedComPortSpeed);
        }

        private void cbxComPortParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedParityIndex = (byte)cbxComPortParity.SelectedIndex;
            _com1.SetPortParity(_selectedParityIndex);
        }

        private void btnStopScript_Click(object sender, EventArgs e)
        {

        }

        private void lbxPhones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjAtComm.SetPhoneNumber(lbxPhones.Text);
        }

        private void cbxComPortNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedComPortName = cbxComPortNumber.SelectedItem.ToString();
            _com1.SetComPort(_selectedComPortName);
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            _com1.OpenPort();
        }
    }

}




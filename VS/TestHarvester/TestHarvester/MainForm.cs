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
        Scripting _scripting;//
        Logging _logging;
        MainForm _pMainForm;
        List<string> _errorsAndWarinigs;
        string _pathOfScriptFiles;
        string _selectedComPortName;
        //Scripting _scripting;

        static public AccessDBSettings AdbSett;
        static public System.IO.DirectoryInfo PathExeFile;
        byte _version;
        private void Form1_Load(object sender, EventArgs e)
        {
            _version = 1;
            _pMainForm = this;//ссылка на эту форму. для всевозможных обращений
            this.Text = "Test Harvester. Ver: " + _version.ToString();
            _pathOfScriptFiles = "";

            //работа с сохранением восстановлением настроек приложения
            PathExeFile = new System.IO.DirectoryInfo(".");//получаем полный путь в папку с екзешником программы
            AdbSett = new AccessDBSettings(PathExeFile.FullName);
            Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);//событие закрытия формы создаем вручную
            LoadSettings();


            _errorsAndWarinigs = new List<string>();
            
            Init();

            //com порт
            
            _com1 = new COM();
            _com1.SetObjForm(ref _pMainForm);
            _com1.SetComPort(_selectedComPortName);
            _com1.OpenPort();
            cbxComPort1.SelectedText = _selectedComPortName;
            //lblCom1Info.Text = "Порт не выбран";






            FillListFilesScript();//наполняем окно со списком файлов скриптов


            //выделяем место основным объектам
            ObjSimpleComm = new SimpleComm();
            _scripting = new Scripting();
            _logging = new Logging();//должно выполнятся ранее SimpleCommInit()
            
            ObjSimpleComm.SimpleCommInit(ref _com1, ref _pMainForm);
            
            UpdateErrTbx();

            //инициализация лигирование
            _logging.PointPath(_pathOfScriptFiles, "log.txt");
            btnRunLogResult.Text = "РЕЗУЛЬТАТ ЗАПУСКА СКРИПТА";
            btnRunLogResult.Enabled = false;

            //ком порты
            string [] comPorts =  SerialPort.GetPortNames();
            cbxComPort1.Items.AddRange(comPorts);
        }


        public void AddErrorsAndWarinigs(string nextErrMessage)
        {
            _errorsAndWarinigs.Add(nextErrMessage);
        }

        void FillListFilesScript()
        {
            lbxFilesWhisScripts.Items.Clear();
            //что с путем к файлам скриптов?
            if (_pathOfScriptFiles == null || _pathOfScriptFiles == "")
                _errorsAndWarinigs.Add("нет пути к папке со скриптами");
            else
            {
                try
                {
                    string[] allPath = Directory.GetFiles(_pathOfScriptFiles, "*.ths");//test harvester script
                    if(allPath.Length == 0)
                        _errorsAndWarinigs.Add("не нашли ниодного скрипта в указанной папке");
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
                    _errorsAndWarinigs.Add("проблеммы при поиске файлов скриптов в указанной папке");
                }
            }
            lblPath.Text = "Путь к скриптам: " + _pathOfScriptFiles;
        }

        void UpdateErrTbx()
        {
            foreach (var item in _errorsAndWarinigs)
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
            string[] tmp = tbxTextOfCurrScript.Lines;//забираем скрипт из текст бокса
            _scripting.SetTextOfScript(ref tmp);//передаем его скриптовой машине
            _scripting.DoCompile(true);//запускаем выполнения скрипта
            tbxErrorInfo.Text = _scripting.GetResultCompile();//выводим в тексбокс сообщения об ошибках


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
                _errorsAndWarinigs.Add("проблемы при попытке указать путь к файлам скриптов");
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

        private void cbxComPort1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedComPortName = cbxComPort1.SelectedItem.ToString();
            _com1.SetComPort(_selectedComPortName);
            _com1.OpenPort();
            //lblCom1Info.Text = _com1.GetCurrComPortName();
        }


    }

}




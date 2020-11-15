namespace TestHarvester
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpgMain = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbxFilesWhisScripts = new System.Windows.Forms.ListBox();
            this.lblTitleListFilesScripts = new System.Windows.Forms.Label();
            this.lblTitleTextSelectFile = new System.Windows.Forms.Label();
            this.tbxErrorInfo = new System.Windows.Forms.TextBox();
            this.lblTitleRunResult = new System.Windows.Forms.Label();
            this.lblTitleCompilResult = new System.Windows.Forms.Label();
            this.tlpTextScriptMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbxTextOfCurrScript = new System.Windows.Forms.TextBox();
            this.tlpTextScriptButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnCompileScript = new System.Windows.Forms.Button();
            this.btnStartScript = new System.Windows.Forms.Button();
            this.btnStopScript = new System.Windows.Forms.Button();
            this.tlpRunLogMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbxRunLog = new System.Windows.Forms.TextBox();
            this.btnRunLogResult = new System.Windows.Forms.Button();
            this.tbpgComm = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxLogsWin = new System.Windows.Forms.TextBox();
            this.tbpgSettings = new System.Windows.Forms.TabPage();
            this.tlpSettingsMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSettings1ScriptPath = new System.Windows.Forms.TableLayoutPanel();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnSenPath2Script = new System.Windows.Forms.Button();
            this.tlpSettings2ComPort = new System.Windows.Forms.TableLayoutPanel();
            this.cbxComPortNumber = new System.Windows.Forms.ComboBox();
            this.cbxComPortSpeed = new System.Windows.Forms.ComboBox();
            this.lblComPortNumber = new System.Windows.Forms.Label();
            this.lblComPortSpeed = new System.Windows.Forms.Label();
            this.cbxComPortParity = new System.Windows.Forms.ComboBox();
            this.lblComPortParity = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tbpgMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpTextScriptMain.SuspendLayout();
            this.tlpTextScriptButton.SuspendLayout();
            this.tlpRunLogMain.SuspendLayout();
            this.tbpgComm.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tbpgSettings.SuspendLayout();
            this.tlpSettingsMain.SuspendLayout();
            this.tlpSettings1ScriptPath.SuspendLayout();
            this.tlpSettings2ComPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpgMain);
            this.tabControl1.Controls.Add(this.tbpgComm);
            this.tabControl1.Controls.Add(this.tbpgSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1813, 698);
            this.tabControl1.TabIndex = 5;
            // 
            // tbpgMain
            // 
            this.tbpgMain.Controls.Add(this.tableLayoutPanel1);
            this.tbpgMain.Location = new System.Drawing.Point(4, 25);
            this.tbpgMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpgMain.Name = "tbpgMain";
            this.tbpgMain.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpgMain.Size = new System.Drawing.Size(1805, 669);
            this.tbpgMain.TabIndex = 0;
            this.tbpgMain.Text = "Скрипты";
            this.tbpgMain.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbxFilesWhisScripts, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTitleListFilesScripts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTitleTextSelectFile, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbxErrorInfo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTitleRunResult, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTitleCompilResult, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlpTextScriptMain, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tlpRunLogMain, 1, 3);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.99123F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.00877F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1799, 665);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lbxFilesWhisScripts
            // 
            this.lbxFilesWhisScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxFilesWhisScripts.FormattingEnabled = true;
            this.lbxFilesWhisScripts.ItemHeight = 16;
            this.lbxFilesWhisScripts.Location = new System.Drawing.Point(3, 22);
            this.lbxFilesWhisScripts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxFilesWhisScripts.Name = "lbxFilesWhisScripts";
            this.lbxFilesWhisScripts.ScrollAlwaysVisible = true;
            this.lbxFilesWhisScripts.Size = new System.Drawing.Size(893, 208);
            this.lbxFilesWhisScripts.TabIndex = 10;
            this.lbxFilesWhisScripts.SelectedIndexChanged += new System.EventHandler(this.lbxFilesWhisScripts_SelectedIndexChanged);
            // 
            // lblTitleListFilesScripts
            // 
            this.lblTitleListFilesScripts.AutoSize = true;
            this.lblTitleListFilesScripts.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitleListFilesScripts.Location = new System.Drawing.Point(3, 0);
            this.lblTitleListFilesScripts.Name = "lblTitleListFilesScripts";
            this.lblTitleListFilesScripts.Size = new System.Drawing.Size(173, 17);
            this.lblTitleListFilesScripts.TabIndex = 14;
            this.lblTitleListFilesScripts.Text = "Список файлов скриптов";
            // 
            // lblTitleTextSelectFile
            // 
            this.lblTitleTextSelectFile.AutoSize = true;
            this.lblTitleTextSelectFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitleTextSelectFile.Location = new System.Drawing.Point(3, 232);
            this.lblTitleTextSelectFile.Name = "lblTitleTextSelectFile";
            this.lblTitleTextSelectFile.Size = new System.Drawing.Size(175, 17);
            this.lblTitleTextSelectFile.TabIndex = 15;
            this.lblTitleTextSelectFile.Text = "Текст выбранного файла";
            // 
            // tbxErrorInfo
            // 
            this.tbxErrorInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbxErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxErrorInfo.Location = new System.Drawing.Point(902, 22);
            this.tbxErrorInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxErrorInfo.Multiline = true;
            this.tbxErrorInfo.Name = "tbxErrorInfo";
            this.tbxErrorInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxErrorInfo.Size = new System.Drawing.Size(894, 208);
            this.tbxErrorInfo.TabIndex = 17;
            // 
            // lblTitleRunResult
            // 
            this.lblTitleRunResult.AutoSize = true;
            this.lblTitleRunResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitleRunResult.Location = new System.Drawing.Point(902, 232);
            this.lblTitleRunResult.Name = "lblTitleRunResult";
            this.lblTitleRunResult.Size = new System.Drawing.Size(314, 17);
            this.lblTitleRunResult.TabIndex = 13;
            this.lblTitleRunResult.Text = "Результаты последнего запуска скрипта (лог)";
            // 
            // lblTitleCompilResult
            // 
            this.lblTitleCompilResult.AutoSize = true;
            this.lblTitleCompilResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitleCompilResult.Location = new System.Drawing.Point(902, 0);
            this.lblTitleCompilResult.Name = "lblTitleCompilResult";
            this.lblTitleCompilResult.Size = new System.Drawing.Size(241, 17);
            this.lblTitleCompilResult.TabIndex = 16;
            this.lblTitleCompilResult.Text = "Ошибки, предупреждения, прочее.";
            // 
            // tlpTextScriptMain
            // 
            this.tlpTextScriptMain.ColumnCount = 1;
            this.tlpTextScriptMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTextScriptMain.Controls.Add(this.tbxTextOfCurrScript, 0, 0);
            this.tlpTextScriptMain.Controls.Add(this.tlpTextScriptButton, 0, 1);
            this.tlpTextScriptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTextScriptMain.Location = new System.Drawing.Point(3, 254);
            this.tlpTextScriptMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpTextScriptMain.Name = "tlpTextScriptMain";
            this.tlpTextScriptMain.RowCount = 2;
            this.tlpTextScriptMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTextScriptMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpTextScriptMain.Size = new System.Drawing.Size(893, 409);
            this.tlpTextScriptMain.TabIndex = 19;
            // 
            // tbxTextOfCurrScript
            // 
            this.tbxTextOfCurrScript.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbxTextOfCurrScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxTextOfCurrScript.Location = new System.Drawing.Point(3, 2);
            this.tbxTextOfCurrScript.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxTextOfCurrScript.Multiline = true;
            this.tbxTextOfCurrScript.Name = "tbxTextOfCurrScript";
            this.tbxTextOfCurrScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxTextOfCurrScript.Size = new System.Drawing.Size(887, 366);
            this.tbxTextOfCurrScript.TabIndex = 11;
            // 
            // tlpTextScriptButton
            // 
            this.tlpTextScriptButton.ColumnCount = 3;
            this.tlpTextScriptButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.93877F));
            this.tlpTextScriptButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.06123F));
            this.tlpTextScriptButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 361F));
            this.tlpTextScriptButton.Controls.Add(this.btnCompileScript, 0, 0);
            this.tlpTextScriptButton.Controls.Add(this.btnStartScript, 1, 0);
            this.tlpTextScriptButton.Controls.Add(this.btnStopScript, 2, 0);
            this.tlpTextScriptButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTextScriptButton.Location = new System.Drawing.Point(3, 372);
            this.tlpTextScriptButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpTextScriptButton.Name = "tlpTextScriptButton";
            this.tlpTextScriptButton.RowCount = 1;
            this.tlpTextScriptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTextScriptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTextScriptButton.Size = new System.Drawing.Size(887, 35);
            this.tlpTextScriptButton.TabIndex = 12;
            // 
            // btnCompileScript
            // 
            this.btnCompileScript.Location = new System.Drawing.Point(3, 2);
            this.btnCompileScript.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCompileScript.Name = "btnCompileScript";
            this.btnCompileScript.Size = new System.Drawing.Size(196, 28);
            this.btnCompileScript.TabIndex = 18;
            this.btnCompileScript.Text = "СКОМПИЛИРОВАТЬ СКРИПТ";
            this.btnCompileScript.UseVisualStyleBackColor = true;
            this.btnCompileScript.Click += new System.EventHandler(this.btnCompileScript_Click);
            // 
            // btnStartScript
            // 
            this.btnStartScript.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStartScript.Location = new System.Drawing.Point(249, 2);
            this.btnStartScript.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartScript.Name = "btnStartScript";
            this.btnStartScript.Size = new System.Drawing.Size(197, 28);
            this.btnStartScript.TabIndex = 11;
            this.btnStartScript.Text = "ЗАПУСТИТЬ СКРИПТ";
            this.btnStartScript.UseVisualStyleBackColor = true;
            this.btnStartScript.Click += new System.EventHandler(this.btnStartScript_Click);
            // 
            // btnStopScript
            // 
            this.btnStopScript.Location = new System.Drawing.Point(528, 3);
            this.btnStopScript.Name = "btnStopScript";
            this.btnStopScript.Size = new System.Drawing.Size(220, 29);
            this.btnStopScript.TabIndex = 19;
            this.btnStopScript.Text = "ОСТАНОВИТЬ СКРИПТ";
            this.btnStopScript.UseVisualStyleBackColor = true;
            this.btnStopScript.Click += new System.EventHandler(this.btnStopScript_Click);
            // 
            // tlpRunLogMain
            // 
            this.tlpRunLogMain.ColumnCount = 1;
            this.tlpRunLogMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRunLogMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRunLogMain.Controls.Add(this.tbxRunLog, 0, 0);
            this.tlpRunLogMain.Controls.Add(this.btnRunLogResult, 0, 1);
            this.tlpRunLogMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRunLogMain.Location = new System.Drawing.Point(903, 256);
            this.tlpRunLogMain.Margin = new System.Windows.Forms.Padding(4);
            this.tlpRunLogMain.Name = "tlpRunLogMain";
            this.tlpRunLogMain.RowCount = 2;
            this.tlpRunLogMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.54878F));
            this.tlpRunLogMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.45122F));
            this.tlpRunLogMain.Size = new System.Drawing.Size(892, 405);
            this.tlpRunLogMain.TabIndex = 20;
            // 
            // tbxRunLog
            // 
            this.tbxRunLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxRunLog.Location = new System.Drawing.Point(4, 4);
            this.tbxRunLog.Margin = new System.Windows.Forms.Padding(4);
            this.tbxRunLog.Multiline = true;
            this.tbxRunLog.Name = "tbxRunLog";
            this.tbxRunLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxRunLog.Size = new System.Drawing.Size(884, 358);
            this.tbxRunLog.TabIndex = 0;
            // 
            // btnRunLogResult
            // 
            this.btnRunLogResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRunLogResult.Location = new System.Drawing.Point(4, 370);
            this.btnRunLogResult.Margin = new System.Windows.Forms.Padding(4);
            this.btnRunLogResult.Name = "btnRunLogResult";
            this.btnRunLogResult.Size = new System.Drawing.Size(884, 31);
            this.btnRunLogResult.TabIndex = 1;
            this.btnRunLogResult.Text = "button1";
            this.btnRunLogResult.UseVisualStyleBackColor = true;
            this.btnRunLogResult.Click += new System.EventHandler(this.btnRunLogResult_Click);
            // 
            // tbpgComm
            // 
            this.tbpgComm.Controls.Add(this.tableLayoutPanel2);
            this.tbpgComm.Location = new System.Drawing.Point(4, 25);
            this.tbpgComm.Name = "tbpgComm";
            this.tbpgComm.Size = new System.Drawing.Size(1805, 669);
            this.tbpgComm.TabIndex = 2;
            this.tbpgComm.Text = "Обмен";
            this.tbpgComm.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tbxLogsWin, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1805, 669);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tbxLogsWin
            // 
            this.tbxLogsWin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxLogsWin.Location = new System.Drawing.Point(3, 36);
            this.tbxLogsWin.Multiline = true;
            this.tbxLogsWin.Name = "tbxLogsWin";
            this.tbxLogsWin.Size = new System.Drawing.Size(1799, 295);
            this.tbxLogsWin.TabIndex = 0;
            // 
            // tbpgSettings
            // 
            this.tbpgSettings.Controls.Add(this.tlpSettingsMain);
            this.tbpgSettings.Location = new System.Drawing.Point(4, 25);
            this.tbpgSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpgSettings.Name = "tbpgSettings";
            this.tbpgSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpgSettings.Size = new System.Drawing.Size(1805, 669);
            this.tbpgSettings.TabIndex = 1;
            this.tbpgSettings.Text = "Настройки";
            this.tbpgSettings.UseVisualStyleBackColor = true;
            // 
            // tlpSettingsMain
            // 
            this.tlpSettingsMain.ColumnCount = 1;
            this.tlpSettingsMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.69925F));
            this.tlpSettingsMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.30075F));
            this.tlpSettingsMain.Controls.Add(this.tlpSettings1ScriptPath, 0, 0);
            this.tlpSettingsMain.Controls.Add(this.tlpSettings2ComPort, 0, 1);
            this.tlpSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSettingsMain.Location = new System.Drawing.Point(3, 2);
            this.tlpSettingsMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpSettingsMain.Name = "tlpSettingsMain";
            this.tlpSettingsMain.RowCount = 5;
            this.tlpSettingsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettingsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettingsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tlpSettingsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tlpSettingsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tlpSettingsMain.Size = new System.Drawing.Size(1799, 665);
            this.tlpSettingsMain.TabIndex = 0;
            // 
            // tlpSettings1ScriptPath
            // 
            this.tlpSettings1ScriptPath.ColumnCount = 2;
            this.tlpSettings1ScriptPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings1ScriptPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings1ScriptPath.Controls.Add(this.lblPath, 0, 0);
            this.tlpSettings1ScriptPath.Controls.Add(this.btnSenPath2Script, 1, 0);
            this.tlpSettings1ScriptPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSettings1ScriptPath.Location = new System.Drawing.Point(4, 4);
            this.tlpSettings1ScriptPath.Margin = new System.Windows.Forms.Padding(4);
            this.tlpSettings1ScriptPath.Name = "tlpSettings1ScriptPath";
            this.tlpSettings1ScriptPath.RowCount = 1;
            this.tlpSettings1ScriptPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings1ScriptPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings1ScriptPath.Size = new System.Drawing.Size(1791, 160);
            this.tlpSettings1ScriptPath.TabIndex = 2;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(3, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(124, 17);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Путь к скриптам: ";
            // 
            // btnSenPath2Script
            // 
            this.btnSenPath2Script.Location = new System.Drawing.Point(898, 2);
            this.btnSenPath2Script.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSenPath2Script.Name = "btnSenPath2Script";
            this.btnSenPath2Script.Size = new System.Drawing.Size(275, 39);
            this.btnSenPath2Script.TabIndex = 1;
            this.btnSenPath2Script.Text = "ЗАДАТЬ ПУТЬ К СКРИПТАМ";
            this.btnSenPath2Script.UseVisualStyleBackColor = true;
            this.btnSenPath2Script.Click += new System.EventHandler(this.btnSenPath2Script_Click);
            // 
            // tlpSettings2ComPort
            // 
            this.tlpSettings2ComPort.ColumnCount = 3;
            this.tlpSettings2ComPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSettings2ComPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSettings2ComPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSettings2ComPort.Controls.Add(this.cbxComPortNumber, 0, 1);
            this.tlpSettings2ComPort.Controls.Add(this.cbxComPortSpeed, 1, 1);
            this.tlpSettings2ComPort.Controls.Add(this.lblComPortNumber, 0, 0);
            this.tlpSettings2ComPort.Controls.Add(this.lblComPortSpeed, 1, 0);
            this.tlpSettings2ComPort.Controls.Add(this.cbxComPortParity, 2, 1);
            this.tlpSettings2ComPort.Controls.Add(this.lblComPortParity, 2, 0);
            this.tlpSettings2ComPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSettings2ComPort.Location = new System.Drawing.Point(4, 172);
            this.tlpSettings2ComPort.Margin = new System.Windows.Forms.Padding(4);
            this.tlpSettings2ComPort.Name = "tlpSettings2ComPort";
            this.tlpSettings2ComPort.RowCount = 2;
            this.tlpSettings2ComPort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpSettings2ComPort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlpSettings2ComPort.Size = new System.Drawing.Size(1791, 160);
            this.tlpSettings2ComPort.TabIndex = 3;
            // 
            // cbxComPortNumber
            // 
            this.cbxComPortNumber.FormattingEnabled = true;
            this.cbxComPortNumber.Location = new System.Drawing.Point(4, 80);
            this.cbxComPortNumber.Margin = new System.Windows.Forms.Padding(4);
            this.cbxComPortNumber.Name = "cbxComPortNumber";
            this.cbxComPortNumber.Size = new System.Drawing.Size(160, 24);
            this.cbxComPortNumber.TabIndex = 0;
            this.cbxComPortNumber.SelectedIndexChanged += new System.EventHandler(this.cbxComPort1_SelectedIndexChanged);
            // 
            // cbxComPortSpeed
            // 
            this.cbxComPortSpeed.FormattingEnabled = true;
            this.cbxComPortSpeed.Location = new System.Drawing.Point(600, 79);
            this.cbxComPortSpeed.Name = "cbxComPortSpeed";
            this.cbxComPortSpeed.Size = new System.Drawing.Size(165, 24);
            this.cbxComPortSpeed.TabIndex = 1;
            this.cbxComPortSpeed.SelectedIndexChanged += new System.EventHandler(this.cbxComPortSpeed_SelectedIndexChanged);
            // 
            // lblComPortNumber
            // 
            this.lblComPortNumber.AutoSize = true;
            this.lblComPortNumber.Location = new System.Drawing.Point(3, 0);
            this.lblComPortNumber.Name = "lblComPortNumber";
            this.lblComPortNumber.Size = new System.Drawing.Size(74, 17);
            this.lblComPortNumber.TabIndex = 2;
            this.lblComPortNumber.Text = "COM порт";
            // 
            // lblComPortSpeed
            // 
            this.lblComPortSpeed.AutoSize = true;
            this.lblComPortSpeed.Location = new System.Drawing.Point(600, 0);
            this.lblComPortSpeed.Name = "lblComPortSpeed";
            this.lblComPortSpeed.Size = new System.Drawing.Size(69, 17);
            this.lblComPortSpeed.TabIndex = 3;
            this.lblComPortSpeed.Text = "Скорость";
            // 
            // cbxComPortParity
            // 
            this.cbxComPortParity.FormattingEnabled = true;
            this.cbxComPortParity.Location = new System.Drawing.Point(1197, 79);
            this.cbxComPortParity.Name = "cbxComPortParity";
            this.cbxComPortParity.Size = new System.Drawing.Size(153, 24);
            this.cbxComPortParity.TabIndex = 4;
            this.cbxComPortParity.SelectedIndexChanged += new System.EventHandler(this.cbxComPortParity_SelectedIndexChanged);
            // 
            // lblComPortParity
            // 
            this.lblComPortParity.AutoSize = true;
            this.lblComPortParity.Location = new System.Drawing.Point(1197, 0);
            this.lblComPortParity.Name = "lblComPortParity";
            this.lblComPortParity.Size = new System.Drawing.Size(70, 17);
            this.lblComPortParity.TabIndex = 5;
            this.lblComPortParity.Text = "Четность";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1813, 698);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Test Harvester.";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbpgMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpTextScriptMain.ResumeLayout(false);
            this.tlpTextScriptMain.PerformLayout();
            this.tlpTextScriptButton.ResumeLayout(false);
            this.tlpRunLogMain.ResumeLayout(false);
            this.tlpRunLogMain.PerformLayout();
            this.tbpgComm.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tbpgSettings.ResumeLayout(false);
            this.tlpSettingsMain.ResumeLayout(false);
            this.tlpSettings1ScriptPath.ResumeLayout(false);
            this.tlpSettings1ScriptPath.PerformLayout();
            this.tlpSettings2ComPort.ResumeLayout(false);
            this.tlpSettings2ComPort.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpgMain;
        private System.Windows.Forms.TabPage tbpgSettings;
        private System.Windows.Forms.TableLayoutPanel tlpSettingsMain;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnSenPath2Script;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lbxFilesWhisScripts;
        private System.Windows.Forms.Label lblTitleListFilesScripts;
        private System.Windows.Forms.Label lblTitleTextSelectFile;
        private System.Windows.Forms.TextBox tbxErrorInfo;
        private System.Windows.Forms.Label lblTitleRunResult;
        private System.Windows.Forms.Label lblTitleCompilResult;
        private System.Windows.Forms.TableLayoutPanel tlpTextScriptMain;
        private System.Windows.Forms.TextBox tbxTextOfCurrScript;
        private System.Windows.Forms.TableLayoutPanel tlpTextScriptButton;
        private System.Windows.Forms.Button btnCompileScript;
        private System.Windows.Forms.Button btnStartScript;
        private System.Windows.Forms.TableLayoutPanel tlpRunLogMain;
        private System.Windows.Forms.TextBox tbxRunLog;
        private System.Windows.Forms.Button btnRunLogResult;
        private System.Windows.Forms.TableLayoutPanel tlpSettings1ScriptPath;
        private System.Windows.Forms.TableLayoutPanel tlpSettings2ComPort;
        private System.Windows.Forms.ComboBox cbxComPortNumber;
        private System.Windows.Forms.ComboBox cbxComPortSpeed;
        private System.Windows.Forms.Label lblComPortNumber;
        private System.Windows.Forms.Label lblComPortSpeed;
        private System.Windows.Forms.ComboBox cbxComPortParity;
        private System.Windows.Forms.Label lblComPortParity;
        private System.Windows.Forms.Button btnStopScript;
        private System.Windows.Forms.TabPage tbpgComm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbxLogsWin;
    }
}


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
            this.tlpRunLogMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbxRunLog = new System.Windows.Forms.TextBox();
            this.btnRunLogResult = new System.Windows.Forms.Button();
            this.tbpgSettings = new System.Windows.Forms.TabPage();
            this.tlpSettingsMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnSenPath2Script = new System.Windows.Forms.Button();
            this.tlpSettings1ScriptPath = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSettings2ComPort = new System.Windows.Forms.TableLayoutPanel();
            this.cbxComPort1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblCom1Info = new System.Windows.Forms.Label();
            this.lblCom2Info = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tbpgMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpTextScriptMain.SuspendLayout();
            this.tlpTextScriptButton.SuspendLayout();
            this.tlpRunLogMain.SuspendLayout();
            this.tbpgSettings.SuspendLayout();
            this.tlpSettingsMain.SuspendLayout();
            this.tlpSettings1ScriptPath.SuspendLayout();
            this.tlpSettings2ComPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpgMain);
            this.tabControl1.Controls.Add(this.tbpgSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1360, 567);
            this.tabControl1.TabIndex = 5;
            // 
            // tbpgMain
            // 
            this.tbpgMain.Controls.Add(this.tableLayoutPanel1);
            this.tbpgMain.Location = new System.Drawing.Point(4, 22);
            this.tbpgMain.Margin = new System.Windows.Forms.Padding(2);
            this.tbpgMain.Name = "tbpgMain";
            this.tbpgMain.Padding = new System.Windows.Forms.Padding(2);
            this.tbpgMain.Size = new System.Drawing.Size(1352, 541);
            this.tbpgMain.TabIndex = 0;
            this.tbpgMain.Text = "Главная";
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.99123F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.00877F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1348, 537);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lbxFilesWhisScripts
            // 
            this.lbxFilesWhisScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxFilesWhisScripts.FormattingEnabled = true;
            this.lbxFilesWhisScripts.Location = new System.Drawing.Point(2, 18);
            this.lbxFilesWhisScripts.Margin = new System.Windows.Forms.Padding(2);
            this.lbxFilesWhisScripts.Name = "lbxFilesWhisScripts";
            this.lbxFilesWhisScripts.ScrollAlwaysVisible = true;
            this.lbxFilesWhisScripts.Size = new System.Drawing.Size(670, 167);
            this.lbxFilesWhisScripts.TabIndex = 10;
            this.lbxFilesWhisScripts.SelectedIndexChanged += new System.EventHandler(this.lbxFilesWhisScripts_SelectedIndexChanged);
            // 
            // lblTitleListFilesScripts
            // 
            this.lblTitleListFilesScripts.AutoSize = true;
            this.lblTitleListFilesScripts.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitleListFilesScripts.Location = new System.Drawing.Point(2, 0);
            this.lblTitleListFilesScripts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitleListFilesScripts.Name = "lblTitleListFilesScripts";
            this.lblTitleListFilesScripts.Size = new System.Drawing.Size(154, 15);
            this.lblTitleListFilesScripts.TabIndex = 14;
            this.lblTitleListFilesScripts.Text = "Список файлов скриптов";
            // 
            // lblTitleTextSelectFile
            // 
            this.lblTitleTextSelectFile.AutoSize = true;
            this.lblTitleTextSelectFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitleTextSelectFile.Location = new System.Drawing.Point(2, 187);
            this.lblTitleTextSelectFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitleTextSelectFile.Name = "lblTitleTextSelectFile";
            this.lblTitleTextSelectFile.Size = new System.Drawing.Size(155, 15);
            this.lblTitleTextSelectFile.TabIndex = 15;
            this.lblTitleTextSelectFile.Text = "Текст выбранного файла";
            // 
            // tbxErrorInfo
            // 
            this.tbxErrorInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbxErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxErrorInfo.Location = new System.Drawing.Point(676, 18);
            this.tbxErrorInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tbxErrorInfo.Multiline = true;
            this.tbxErrorInfo.Name = "tbxErrorInfo";
            this.tbxErrorInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxErrorInfo.Size = new System.Drawing.Size(670, 167);
            this.tbxErrorInfo.TabIndex = 17;
            // 
            // lblTitleRunResult
            // 
            this.lblTitleRunResult.AutoSize = true;
            this.lblTitleRunResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitleRunResult.Location = new System.Drawing.Point(676, 187);
            this.lblTitleRunResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitleRunResult.Name = "lblTitleRunResult";
            this.lblTitleRunResult.Size = new System.Drawing.Size(274, 15);
            this.lblTitleRunResult.TabIndex = 13;
            this.lblTitleRunResult.Text = "Результаты последнего запуска скрипта (лог)";
            // 
            // lblTitleCompilResult
            // 
            this.lblTitleCompilResult.AutoSize = true;
            this.lblTitleCompilResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitleCompilResult.Location = new System.Drawing.Point(676, 0);
            this.lblTitleCompilResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitleCompilResult.Name = "lblTitleCompilResult";
            this.lblTitleCompilResult.Size = new System.Drawing.Size(206, 15);
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
            this.tlpTextScriptMain.Location = new System.Drawing.Point(2, 205);
            this.tlpTextScriptMain.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTextScriptMain.Name = "tlpTextScriptMain";
            this.tlpTextScriptMain.RowCount = 2;
            this.tlpTextScriptMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTextScriptMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpTextScriptMain.Size = new System.Drawing.Size(670, 330);
            this.tlpTextScriptMain.TabIndex = 19;
            // 
            // tbxTextOfCurrScript
            // 
            this.tbxTextOfCurrScript.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbxTextOfCurrScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxTextOfCurrScript.Location = new System.Drawing.Point(2, 2);
            this.tbxTextOfCurrScript.Margin = new System.Windows.Forms.Padding(2);
            this.tbxTextOfCurrScript.Multiline = true;
            this.tbxTextOfCurrScript.Name = "tbxTextOfCurrScript";
            this.tbxTextOfCurrScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxTextOfCurrScript.Size = new System.Drawing.Size(666, 294);
            this.tbxTextOfCurrScript.TabIndex = 11;
            // 
            // tlpTextScriptButton
            // 
            this.tlpTextScriptButton.ColumnCount = 3;
            this.tlpTextScriptButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.93877F));
            this.tlpTextScriptButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.06123F));
            this.tlpTextScriptButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tlpTextScriptButton.Controls.Add(this.btnCompileScript, 1, 0);
            this.tlpTextScriptButton.Controls.Add(this.btnStartScript, 2, 0);
            this.tlpTextScriptButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTextScriptButton.Location = new System.Drawing.Point(2, 300);
            this.tlpTextScriptButton.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTextScriptButton.Name = "tlpTextScriptButton";
            this.tlpTextScriptButton.RowCount = 1;
            this.tlpTextScriptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTextScriptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTextScriptButton.Size = new System.Drawing.Size(666, 28);
            this.tlpTextScriptButton.TabIndex = 12;
            // 
            // btnCompileScript
            // 
            this.btnCompileScript.Location = new System.Drawing.Point(240, 2);
            this.btnCompileScript.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompileScript.Name = "btnCompileScript";
            this.btnCompileScript.Size = new System.Drawing.Size(147, 23);
            this.btnCompileScript.TabIndex = 18;
            this.btnCompileScript.Text = "СКОМПИЛИРОВАТЬ СКРИПТ";
            this.btnCompileScript.UseVisualStyleBackColor = true;
            this.btnCompileScript.Click += new System.EventHandler(this.btnCompileScript_Click);
            // 
            // btnStartScript
            // 
            this.btnStartScript.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStartScript.Location = new System.Drawing.Point(510, 2);
            this.btnStartScript.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartScript.Name = "btnStartScript";
            this.btnStartScript.Size = new System.Drawing.Size(148, 23);
            this.btnStartScript.TabIndex = 11;
            this.btnStartScript.Text = "ЗАПУСТИТЬ СКРИПТ";
            this.btnStartScript.UseVisualStyleBackColor = true;
            this.btnStartScript.Click += new System.EventHandler(this.btnStartScript_Click);
            // 
            // tlpRunLogMain
            // 
            this.tlpRunLogMain.ColumnCount = 1;
            this.tlpRunLogMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRunLogMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRunLogMain.Controls.Add(this.tbxRunLog, 0, 0);
            this.tlpRunLogMain.Controls.Add(this.btnRunLogResult, 0, 1);
            this.tlpRunLogMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRunLogMain.Location = new System.Drawing.Point(677, 206);
            this.tlpRunLogMain.Name = "tlpRunLogMain";
            this.tlpRunLogMain.RowCount = 2;
            this.tlpRunLogMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.54878F));
            this.tlpRunLogMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.45122F));
            this.tlpRunLogMain.Size = new System.Drawing.Size(668, 328);
            this.tlpRunLogMain.TabIndex = 20;
            // 
            // tbxRunLog
            // 
            this.tbxRunLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxRunLog.Location = new System.Drawing.Point(3, 3);
            this.tbxRunLog.Multiline = true;
            this.tbxRunLog.Name = "tbxRunLog";
            this.tbxRunLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxRunLog.Size = new System.Drawing.Size(662, 291);
            this.tbxRunLog.TabIndex = 0;
            // 
            // btnRunLogResult
            // 
            this.btnRunLogResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRunLogResult.Location = new System.Drawing.Point(3, 300);
            this.btnRunLogResult.Name = "btnRunLogResult";
            this.btnRunLogResult.Size = new System.Drawing.Size(662, 25);
            this.btnRunLogResult.TabIndex = 1;
            this.btnRunLogResult.Text = "button1";
            this.btnRunLogResult.UseVisualStyleBackColor = true;
            this.btnRunLogResult.Click += new System.EventHandler(this.btnRunLogResult_Click);
            // 
            // tbpgSettings
            // 
            this.tbpgSettings.Controls.Add(this.tlpSettingsMain);
            this.tbpgSettings.Location = new System.Drawing.Point(4, 22);
            this.tbpgSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tbpgSettings.Name = "tbpgSettings";
            this.tbpgSettings.Padding = new System.Windows.Forms.Padding(2);
            this.tbpgSettings.Size = new System.Drawing.Size(1352, 541);
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
            this.tlpSettingsMain.Location = new System.Drawing.Point(2, 2);
            this.tlpSettingsMain.Margin = new System.Windows.Forms.Padding(2);
            this.tlpSettingsMain.Name = "tlpSettingsMain";
            this.tlpSettingsMain.RowCount = 5;
            this.tlpSettingsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettingsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettingsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tlpSettingsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tlpSettingsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpSettingsMain.Size = new System.Drawing.Size(1348, 537);
            this.tlpSettingsMain.TabIndex = 0;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(2, 0);
            this.lblPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(109, 15);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Путь к скриптам: ";
            // 
            // btnSenPath2Script
            // 
            this.btnSenPath2Script.Location = new System.Drawing.Point(673, 2);
            this.btnSenPath2Script.Margin = new System.Windows.Forms.Padding(2);
            this.btnSenPath2Script.Name = "btnSenPath2Script";
            this.btnSenPath2Script.Size = new System.Drawing.Size(206, 32);
            this.btnSenPath2Script.TabIndex = 1;
            this.btnSenPath2Script.Text = "ЗАДАТЬ ПУТЬ К СКРИПТАМ";
            this.btnSenPath2Script.UseVisualStyleBackColor = true;
            this.btnSenPath2Script.Click += new System.EventHandler(this.btnSenPath2Script_Click);
            // 
            // tlpSettings1ScriptPath
            // 
            this.tlpSettings1ScriptPath.ColumnCount = 2;
            this.tlpSettings1ScriptPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings1ScriptPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings1ScriptPath.Controls.Add(this.lblPath, 0, 0);
            this.tlpSettings1ScriptPath.Controls.Add(this.btnSenPath2Script, 1, 0);
            this.tlpSettings1ScriptPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSettings1ScriptPath.Location = new System.Drawing.Point(3, 3);
            this.tlpSettings1ScriptPath.Name = "tlpSettings1ScriptPath";
            this.tlpSettings1ScriptPath.RowCount = 1;
            this.tlpSettings1ScriptPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings1ScriptPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings1ScriptPath.Size = new System.Drawing.Size(1342, 129);
            this.tlpSettings1ScriptPath.TabIndex = 2;
            // 
            // tlpSettings2ComPort
            // 
            this.tlpSettings2ComPort.ColumnCount = 2;
            this.tlpSettings2ComPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.7079F));
            this.tlpSettings2ComPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.2921F));
            this.tlpSettings2ComPort.Controls.Add(this.cbxComPort1, 0, 0);
            this.tlpSettings2ComPort.Controls.Add(this.comboBox2, 0, 1);
            this.tlpSettings2ComPort.Controls.Add(this.lblCom1Info, 1, 0);
            this.tlpSettings2ComPort.Controls.Add(this.lblCom2Info, 1, 1);
            this.tlpSettings2ComPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSettings2ComPort.Location = new System.Drawing.Point(3, 138);
            this.tlpSettings2ComPort.Name = "tlpSettings2ComPort";
            this.tlpSettings2ComPort.RowCount = 2;
            this.tlpSettings2ComPort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings2ComPort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettings2ComPort.Size = new System.Drawing.Size(1342, 129);
            this.tlpSettings2ComPort.TabIndex = 3;
            // 
            // cbxComPort1
            // 
            this.cbxComPort1.FormattingEnabled = true;
            this.cbxComPort1.Location = new System.Drawing.Point(3, 3);
            this.cbxComPort1.Name = "cbxComPort1";
            this.cbxComPort1.Size = new System.Drawing.Size(121, 21);
            this.cbxComPort1.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(3, 67);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // lblCom1Info
            // 
            this.lblCom1Info.AutoSize = true;
            this.lblCom1Info.Location = new System.Drawing.Point(348, 0);
            this.lblCom1Info.Name = "lblCom1Info";
            this.lblCom1Info.Size = new System.Drawing.Size(41, 15);
            this.lblCom1Info.TabIndex = 2;
            this.lblCom1Info.Text = "label1";
            // 
            // lblCom2Info
            // 
            this.lblCom2Info.AutoSize = true;
            this.lblCom2Info.Location = new System.Drawing.Point(348, 64);
            this.lblCom2Info.Name = "lblCom2Info";
            this.lblCom2Info.Size = new System.Drawing.Size(41, 15);
            this.lblCom2Info.TabIndex = 3;
            this.lblCom2Info.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 567);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.ComboBox cbxComPort1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblCom1Info;
        private System.Windows.Forms.Label lblCom2Info;
    }
}


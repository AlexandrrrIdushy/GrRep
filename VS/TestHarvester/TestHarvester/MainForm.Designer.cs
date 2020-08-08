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
            this.lblTitleRunResult = new System.Windows.Forms.Label();
            this.lblTitleCompilResult = new System.Windows.Forms.Label();
            this.tlpTextScriptMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbxTextOfCurrScript = new System.Windows.Forms.TextBox();
            this.tlpTextScriptButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnCompileScript = new System.Windows.Forms.Button();
            this.btnStartScript = new System.Windows.Forms.Button();
            this.tbpgSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnSenPath2Script = new System.Windows.Forms.Button();
            this.tbxErrorInfo = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tbpgMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpTextScriptMain.SuspendLayout();
            this.tlpTextScriptButton.SuspendLayout();
            this.tbpgSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpgMain);
            this.tabControl1.Controls.Add(this.tbpgSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1211, 569);
            this.tabControl1.TabIndex = 5;
            // 
            // tbpgMain
            // 
            this.tbpgMain.Controls.Add(this.tableLayoutPanel1);
            this.tbpgMain.Location = new System.Drawing.Point(4, 25);
            this.tbpgMain.Name = "tbpgMain";
            this.tbpgMain.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgMain.Size = new System.Drawing.Size(1203, 540);
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
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.99123F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.00877F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1197, 534);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lbxFilesWhisScripts
            // 
            this.lbxFilesWhisScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxFilesWhisScripts.FormattingEnabled = true;
            this.lbxFilesWhisScripts.ItemHeight = 16;
            this.lbxFilesWhisScripts.Location = new System.Drawing.Point(3, 23);
            this.lbxFilesWhisScripts.Name = "lbxFilesWhisScripts";
            this.lbxFilesWhisScripts.ScrollAlwaysVisible = true;
            this.lbxFilesWhisScripts.Size = new System.Drawing.Size(592, 161);
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
            this.lblTitleTextSelectFile.Location = new System.Drawing.Point(3, 187);
            this.lblTitleTextSelectFile.Name = "lblTitleTextSelectFile";
            this.lblTitleTextSelectFile.Size = new System.Drawing.Size(175, 17);
            this.lblTitleTextSelectFile.TabIndex = 15;
            this.lblTitleTextSelectFile.Text = "Текст выбранного файла";
            // 
            // lblTitleRunResult
            // 
            this.lblTitleRunResult.AutoSize = true;
            this.lblTitleRunResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitleRunResult.Location = new System.Drawing.Point(601, 187);
            this.lblTitleRunResult.Name = "lblTitleRunResult";
            this.lblTitleRunResult.Size = new System.Drawing.Size(231, 17);
            this.lblTitleRunResult.TabIndex = 13;
            this.lblTitleRunResult.Text = "Результаты работы скрипта (лог)";
            // 
            // lblTitleCompilResult
            // 
            this.lblTitleCompilResult.AutoSize = true;
            this.lblTitleCompilResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitleCompilResult.Location = new System.Drawing.Point(601, 0);
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
            this.tlpTextScriptMain.Location = new System.Drawing.Point(3, 210);
            this.tlpTextScriptMain.Name = "tlpTextScriptMain";
            this.tlpTextScriptMain.RowCount = 2;
            this.tlpTextScriptMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTextScriptMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTextScriptMain.Size = new System.Drawing.Size(592, 321);
            this.tlpTextScriptMain.TabIndex = 19;
            // 
            // tbxTextOfCurrScript
            // 
            this.tbxTextOfCurrScript.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbxTextOfCurrScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxTextOfCurrScript.Location = new System.Drawing.Point(3, 3);
            this.tbxTextOfCurrScript.Multiline = true;
            this.tbxTextOfCurrScript.Name = "tbxTextOfCurrScript";
            this.tbxTextOfCurrScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxTextOfCurrScript.Size = new System.Drawing.Size(586, 271);
            this.tbxTextOfCurrScript.TabIndex = 11;
            // 
            // tlpTextScriptButton
            // 
            this.tlpTextScriptButton.ColumnCount = 3;
            this.tlpTextScriptButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.93877F));
            this.tlpTextScriptButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.06123F));
            this.tlpTextScriptButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tlpTextScriptButton.Controls.Add(this.btnCompileScript, 1, 0);
            this.tlpTextScriptButton.Controls.Add(this.btnStartScript, 2, 0);
            this.tlpTextScriptButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTextScriptButton.Location = new System.Drawing.Point(3, 280);
            this.tlpTextScriptButton.Name = "tlpTextScriptButton";
            this.tlpTextScriptButton.RowCount = 1;
            this.tlpTextScriptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTextScriptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTextScriptButton.Size = new System.Drawing.Size(586, 35);
            this.tlpTextScriptButton.TabIndex = 12;
            // 
            // btnCompileScript
            // 
            this.btnCompileScript.Location = new System.Drawing.Point(181, 3);
            this.btnCompileScript.Name = "btnCompileScript";
            this.btnCompileScript.Size = new System.Drawing.Size(196, 29);
            this.btnCompileScript.TabIndex = 18;
            this.btnCompileScript.Text = "СКОМПИЛИРОВАТЬ СКРИПТ";
            this.btnCompileScript.UseVisualStyleBackColor = true;
            this.btnCompileScript.Click += new System.EventHandler(this.btnCompileScript_Click);
            // 
            // btnStartScript
            // 
            this.btnStartScript.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStartScript.Location = new System.Drawing.Point(383, 3);
            this.btnStartScript.Name = "btnStartScript";
            this.btnStartScript.Size = new System.Drawing.Size(197, 29);
            this.btnStartScript.TabIndex = 11;
            this.btnStartScript.Text = "ЗАПУСТИТЬ СКРИПТ";
            this.btnStartScript.UseVisualStyleBackColor = true;
            this.btnStartScript.Click += new System.EventHandler(this.btnStartScript_Click);
            // 
            // tbpgSettings
            // 
            this.tbpgSettings.Controls.Add(this.tableLayoutPanel2);
            this.tbpgSettings.Location = new System.Drawing.Point(4, 25);
            this.tbpgSettings.Name = "tbpgSettings";
            this.tbpgSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgSettings.Size = new System.Drawing.Size(1203, 540);
            this.tbpgSettings.TabIndex = 1;
            this.tbpgSettings.Text = "Настройки";
            this.tbpgSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.69925F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.30075F));
            this.tableLayoutPanel2.Controls.Add(this.lblPath, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSenPath2Script, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1197, 534);
            this.tableLayoutPanel2.TabIndex = 0;
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
            this.btnSenPath2Script.Location = new System.Drawing.Point(957, 3);
            this.btnSenPath2Script.Name = "btnSenPath2Script";
            this.btnSenPath2Script.Size = new System.Drawing.Size(218, 23);
            this.btnSenPath2Script.TabIndex = 1;
            this.btnSenPath2Script.Text = "ЗАДАТЬ ПУТЬ К СКРИПТАМ";
            this.btnSenPath2Script.UseVisualStyleBackColor = true;
            this.btnSenPath2Script.Click += new System.EventHandler(this.btnSenPath2Script_Click);
            // 
            // tbxErrorInfo
            // 
            this.tbxErrorInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbxErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxErrorInfo.Location = new System.Drawing.Point(601, 23);
            this.tbxErrorInfo.Multiline = true;
            this.tbxErrorInfo.Name = "tbxErrorInfo";
            this.tbxErrorInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxErrorInfo.Size = new System.Drawing.Size(593, 161);
            this.tbxErrorInfo.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 569);
            this.Controls.Add(this.tabControl1);
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
            this.tbpgSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpgMain;
        private System.Windows.Forms.TabPage tbpgSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lbxFilesWhisScripts;
        private System.Windows.Forms.Button btnStartScript;
        private System.Windows.Forms.Label lblTitleListFilesScripts;
        private System.Windows.Forms.Label lblTitleRunResult;
        private System.Windows.Forms.Label lblTitleTextSelectFile;
        private System.Windows.Forms.Label lblTitleCompilResult;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnSenPath2Script;
        private System.Windows.Forms.Button btnCompileScript;
        private System.Windows.Forms.TableLayoutPanel tlpTextScriptMain;
        private System.Windows.Forms.TextBox tbxTextOfCurrScript;
        private System.Windows.Forms.TableLayoutPanel tlpTextScriptButton;
        private System.Windows.Forms.TextBox tbxErrorInfo;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHarvester
{

    public class Scripting
    {
        public Scripting()
        {

        }

        /// <summary>
        /// The uses wants to execute the external script, so we compile first, then execute.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompileAndExecuteButton_Click(object sender, EventArgs e)
        {

            // Compile, and pass a flag in as true (execute)
            DoCompile(true);


        }  // END private void CompileAndExecuteButton_Click(object sender, EventArgs e)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompileButton_Click(object sender, EventArgs e)
        {

            // Compile, and pass a flag in as false (do NOT execute)
            DoCompile(false);


        }  // END private void CompileButton_Click(object sender, EventArgs e)

        public void SetTextOfScript(ref String[] codeLines)
        {
            _codeLines = codeLines;
        }
        public string GetResultCompile()
        {
            return _resultsText;
        }

        public string GetErrorMsg()
        {
            return _textError;
        }

        public CodeDOMProcessor GetCodeDOMProcessorObj()
        {
            return _oDOM;
        }

        String[] _codeLines;
        string _resultsText;
        string _textError;
        CodeDOMProcessor _oDOM = new CodeDOMProcessor();
        //скомпилировать код
        public void DoCompile(Boolean pExecute)
        {

            // Get the code lines to execute. 
            // The user is allowed to edit the code.


            // This class is used to check the code, and contain the code to execute.
            CodeFile DOMChecker = new CodeFile();

            String pFullTypeName = "";
            String pModuleName = "";
            List<String> pConstructors = new List<String>();
            List<String> pMembers = new List<String>();
            List<String> pFields = new List<String>();
            List<String> pMethods = new List<String>();
            List<String> pProperties = new List<String>();

            // Clear the results textbox.
            _resultsText = "";

            // Compile the code and get some results for the UI.
            // The code can be altered to get more useful objects for methods, properties, parameters, etc.
            // for automating the use of the external code.
            //компилирует код получает результаты этого процесса
            //код может изменен для получения большего колва поледных объектов и методов...
            List<String> CheckerResults = DOMChecker.SetAndCompileCSCode(_codeLines,
                                                                        out pFullTypeName,
                                                                        out pModuleName,
                                                                        out pConstructors,
                                                                        out pMembers,
                                                                        out pFields,
                                                                        out pMethods,
                                                                        out pProperties);

            // Build the display text.
            StringBuilder SB = new StringBuilder();

            if (CheckerResults.Count > 0)
            {
                SB.AppendLine("Results of Compile:");

                if (!DOMChecker.CompiledOK)
                {
                    SB.AppendLine("Compile failed. The C# compiler does not count comment lines");
                    SB.AppendLine("or 'using' statement lines when giving line numbers.");
                    SB.AppendLine("");
                }  // END if (!DOMChecker.CompiledOK)

                foreach (String Result in CheckerResults)
                {
                    SB.AppendLine("  " + Result);
                }

            }  // END if (CheckerResults.Count > 0)

            SB.AppendLine("  ");

            if (DOMChecker.CompiledOK)
            {
                // If it compiled OK, then show some info about what we found.
                SB.AppendLine("Full Type Name: " + pFullTypeName);
                SB.AppendLine("In-memory Module Name: " + pModuleName);

                SB.AppendLine("Constructor(s):");
                foreach (String sConstructor in pConstructors)
                {
                    SB.AppendLine("  " + sConstructor);
                }
                SB.AppendLine("  ");

                SB.AppendLine("Member(s):");
                foreach (String sMember in pMembers)
                {
                    SB.AppendLine("  " + sMember);
                }
                SB.AppendLine("  ");

                SB.AppendLine("Fields(s):");
                foreach (String sField in pFields)
                {
                    SB.AppendLine("  " + sField);
                }
                SB.AppendLine("  ");

                SB.AppendLine("Method(s):");
                foreach (String sMethod in pMethods)
                {
                    SB.AppendLine("  " + sMethod);
                }
                SB.AppendLine("  ");

                SB.AppendLine("Properties(s):");
                foreach (String sProperty in pProperties)
                {
                    SB.AppendLine("  " + sProperty);
                }
                SB.AppendLine("  ");

                _resultsText = SB.ToString();

                SB.Clear();

                SB = null;


                String Msg = "";


                if (pExecute)//запускать/не запускать
                {
                    // if we passed in a flag to execute the code, then
                    // if it compiled, we can execute it. For this example, the 
                    // method name and parameters are hardcoded.
                    // In a production setting, the object you get back from compiling can be used to
                    // to allow a user or code to dynamically pick methods and properties to execute
                    // with appropriate parameters.
                    if (DOMChecker.CompiledOK)
                    {
                        
                        //Object[] MethodParams = new Object[] { "Hello World!", "Script Results", new TestObject() };
                        Object[] MethodParams = new Object[] { "Hello World!" };
                        // Method and params are hard-coded for the Test.cs file.
                        //метод и праметры фиксированы для Text.cs файла
                        List<String> RetVal = _oDOM.CompileAndExecute(DOMChecker.Code2Use,
                                                                     DOMChecker.RefAssemblies,
                                                                     DOMChecker.MainClassName,
                                                                     "Start",
                                                                     MethodParams);

                        if (RetVal != null)
                        {
                            if (RetVal.Count > 0)
                            {
                                Msg = "";

                                foreach (String RetMsg in RetVal)
                                {
                                    Msg += RetMsg + Environment.NewLine;
                                }  // END foreach (String RetMsg in RetVal)

                                if (Msg.Length > 0)
                                {
                                    _textError = "Execution Errors: " + Msg;
                                }

                            }  // END if (RetVal.Count > 0)

                        }  // END if (RetVal != null)

                    }
                    else
                    {

                        foreach (String Result in CheckerResults)
                        {
                            Msg += Result;
                        }

                        _textError = "Compile Failure Information - " + Msg;
                    }
                }  // END if (pExecute)

            }  // END if (DOMChecker.CompiledOK)
            else
            {
                SB.AppendLine("");
                SB.AppendLine("Failed to Compile.");

                _resultsText = SB.ToString();

                SB.Clear();

                SB = null;

            }  // END else of [if (DOMChecker.CompiledOK)]

            DOMChecker = null;


        }  // END private void DoCompile(Boolean pExecute)

        /// <summary>
        /// Select the C# file to execute as external, 
        /// uncompiled code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void SelectFileButton_Click(object sender, EventArgs e)
        //{

        //    GetCSDialog.InitialDirectory = Application.ExecutablePath;

        //    DialogResult UserChoice = GetCSDialog.ShowDialog(this);

        //    if (UserChoice == System.Windows.Forms.DialogResult.OK)
        //    {
        //        String CSFileName = GetCSDialog.FileName;

        //        String[] FileLines = File.ReadAllLines(CSFileName);

        //        // read the lines in, and replace tabs with 4 spaces so the 
        //        // column numbers make more sense in the UI. A tab reads as 1 column
        //        // because it is 12 character in the textbox.
        //        StringBuilder SB = new StringBuilder();

        //        foreach (String FileLine in FileLines)
        //        {
        //            String Line2Add = "";

        //            if (FileLine.Contains("\t"))
        //            {
        //                Line2Add = FileLine.Replace("\t", "    ");
        //            }
        //            else
        //            {
        //                Line2Add = FileLine;
        //            }

        //            SB.AppendLine(Line2Add);

        //        }// END foreach (String FileLine in FileLines)

        //        CSTextBox.Text = SB.ToString();

        //        SB.Clear();

        //        SB = null;

        //    }  // END if (UserChoice == System.Windows.Forms.DialogResult.OK)

        //}

        /// <summary>
        /// Start off with no row/col info showing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void MainForm_Shown(object sender, EventArgs e)
        //{
        //    RowColStatus.Items["RowNum"].Text = "";
        //    RowColStatus.Items["ColNum"].Text = "";

        //}  // END private void MainForm_Shown(object sender, EventArgs e)

        /// <summary>
        /// This updates the row and col numbers when:
        /// 1 - The CSTextBox has the focus AND
        /// 2 - there is something in the textbox 
        /// 
        /// The compiler ignores code lines that start with "using" because they 
        /// are for the IDE, not the compiler, and also ignores comment-only lines.
        /// </summary>
        //private void DoStatusBar()
        //{
        //    if (CSTextBox.Focused)
        //    {
        //        if (CSTextBox.Text.Length == 0)
        //        {
        //            RowColStatus.Items["RowNum"].Text = "Row 1";
        //            RowColStatus.Items["ColNum"].Text = "Col 1";
        //        }  // END if (CSTextBox.Text.Length == 0)
        //        else
        //        {
        //            if (CSTextBox.SelectionLength > 1)
        //            {
        //                RowColStatus.Items["RowNum"].Text = "";
        //                RowColStatus.Items["ColNum"].Text = "";
        //            }
        //            else
        //            {
        //                // Courtesy pf http://www.codeproject.com/Tips/292107/TextBox-cursor-position
        //                Int32 CharPos = CSTextBox.SelectionStart;
        //                Int32 LineNum = CSTextBox.GetLineFromCharIndex(CharPos);
        //                Int32 ColNum = CSTextBox.SelectionStart - CSTextBox.GetFirstCharIndexFromLine(LineNum);

        //                RowColStatus.Items["RowNum"].Text = String.Format("Row {0}", (LineNum + 1).ToString());
        //                RowColStatus.Items["ColNum"].Text = String.Format("Col {0}", (ColNum + 1).ToString());
        //            }
        //        }  // END else of [if (CSTextBox.Text.Length == 0)]

        //    }  // END if (CSTextBox.Focused)
        //    else
        //    {
        //        RowColStatus.Items["RowNum"].Text = "";
        //        RowColStatus.Items["ColNum"].Text = "";
        //    }

        //}  // END private void DoStatusBar()

        ///// <summary>
        ///// Update the row/col values from the mouse change
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CSTextBox_MouseUp(object sender, MouseEventArgs e)
        //{
        //    DoStatusBar();
        //}

        ///// <summary>
        ///// Update the row/col values from the cursor change
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CSTextBox_KeyUp(object sender, KeyEventArgs e)
        //{
        //    DoStatusBar();

        //}  // END private void CSTextBox_KeyUp(object sender, KeyEventArgs e)

    }  // END public partial class MainForm : Form
}

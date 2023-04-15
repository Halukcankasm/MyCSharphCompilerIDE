using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCSharphCompilerIDE
{
    public partial class Form1 : Form
    {
        #region Properties
        public string currentPath { get; set; }
        #endregion
        #region Constructer
        public Form1()
        {
            InitializeComponent();
        } 
        #endregion

        #region Methods
        private void ReadToFile()
        {
            StreamReader streamReader = new StreamReader(currentPath);
            textBoxArea.Text = streamReader.ReadToEnd();
            streamReader.Close();
        }

        private void WriteToFile()
        {
            StreamWriter streamWriter = new StreamWriter(currentPath);
            streamWriter.Write(textBoxArea.Text);
            streamWriter.Close();
        }

        private void SaveAsFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "SaveFile";
            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                currentPath = saveFileDialog.FileName;
                WriteToFile();
            }
        } 
        #endregion

        #region Extension
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "File";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                currentPath = openFileDialog.FileName;
                ReadToFile();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteToFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentPath))
            {
                SaveAsFile();
            }
            else
            {
                WriteToFile();
            }
            string psiArguments = $"/out:{Directory.GetParent(currentPath)}"+"\\output.exe"+ $" {currentPath}";
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe";
            psi.Arguments = @"" + psiArguments;
            psi.WorkingDirectory = @"D:\";
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            Process process = Process.Start(psi);
            string outsss = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            string psiExeFilePath = $"{Directory.GetParent(currentPath)}" + "\\output.exe";
            Process.Start(psiExeFilePath);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (DialogResult.OK == colorDialog.ShowDialog())
            {
                textBoxArea.ForeColor = colorDialog.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (DialogResult.OK == fontDialog.ShowDialog())
            {
                textBoxArea.Font = fontDialog.Font;
            }
        }

        #endregion


    }
}

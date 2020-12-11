using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using System.Reflection;
using Paragraph = System.Windows.Documents.Paragraph;
using Office = Microsoft.Office.Core;

namespace Laba_3
{
    public class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }

        public OpenFileDialog openFileDialog = new OpenFileDialog() { ValidateNames = true, Multiselect = false };

        public bool OpenFileDialog()
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|docx files (*.docx)|*.docx";

            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                if (!string.IsNullOrWhiteSpace(FilePath))
                {
                    string originalfilename = Path.GetFullPath(FilePath);
                    if (openFileDialog.CheckFileExists && new[] { ".docx", ".doc" }.Contains(Path.GetExtension(originalfilename).ToLower()))
                    {
      
                        return true;
                    }
                    
                }
               
            }
            return false;
        }

        public void SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|docx files (*.docx)|*.docx";

            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
            }

        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }


}

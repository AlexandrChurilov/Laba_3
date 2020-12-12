using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using Application = Microsoft.Office.Interop.Word.Application;
using Paragraph = System.Windows.Documents.Paragraph;

namespace Laba_3
{
    public class FileReaderWriter
    {
        private readonly IDialogService _dialogService;
        private bool _open;

        public FileReaderWriter(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _open = true;
        }

        private string FileRead(string path)
        {
            
            if (_open && new[] { ".docx" }.Contains(Path.GetExtension(path).ToLower()))
            {

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, true))
                {
                    var text = wordDoc.MainDocumentPart.Document.InnerText;
                    return text;

                }
                 
            }
            else if (new[] { ".txt" }.Contains(Path.GetExtension(path).ToLower()))
            {

                string str = File.ReadAllText(path, Encoding.Default);
                return str;
            }
            return null;
          
        }

        public string FileOpen()

        {
            _open = _dialogService.OpenFileDialog();

            if (!string.IsNullOrWhiteSpace(_dialogService.FilePath))
            {
                string str = FileRead(_dialogService.FilePath);
                return str;
            }
            return null;
        }

        public void FileSave(TextBox texBoxRead)
        {
            _dialogService.SaveFileDialog();

            if (!string.IsNullOrWhiteSpace(_dialogService.FilePath))
            {
                string originalfilename = Path.GetFullPath(_dialogService.FilePath);


                if (new[] { ".docx", ".doc" }.Contains(Path.GetExtension(originalfilename).ToLower()))
                {
                    Application winword = new Application();
                    winword.ShowAnimation = false;
                    winword.Visible = false;

                    object missing = Missing.Value;

                    Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                    document.Content.SetRange(0, 0);
                    document.Content.Text = texBoxRead.Text;
                    object filename = _dialogService.FilePath;
                    document.SaveAs2(ref filename);
                    document.Close(ref missing, ref missing, ref missing);
                    document = null;
                    winword.Quit(ref missing, ref missing, ref missing);
                    winword = null;
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(_dialogService.FilePath, false, Encoding.Default))
                    {
                        sw.Write(texBoxRead.Text);
                    }

                }

            }
        }

    }
}




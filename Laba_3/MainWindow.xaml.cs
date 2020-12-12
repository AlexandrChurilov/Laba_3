using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using System.Reflection;
using Microsoft.Win32;
using Paragraph = System.Windows.Documents.Paragraph;
using System.Text.RegularExpressions;

namespace Laba_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {

        private FileReaderWriter fileReaderWriter;
       
        public MainWindow()
        {
            fileReaderWriter = new FileReaderWriter(new DefaultDialogService());
            InitializeComponent();
           
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(texBoxRead.Text))
            {
                fileReaderWriter.FileSave(texBoxRead);
            }
            else
            {
                MessageBox.Show("Поле не может быть пусым)))");
            }
        }

        private void TexBoxWriter_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
  
            textBoxWrite.Text = fileReaderWriter.FileOpen();

        }

        


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            VigenereCipher vg = new VigenereCipher((bool)radioButtonRus.IsChecked);
           
            if (!string.IsNullOrWhiteSpace(texBoxKey.Text) && (Regex.Match(texBoxKey.Text, vg.regex).Success))
            {
               
                if (!string.IsNullOrWhiteSpace(textBoxWrite.Text))
                    texBoxRead.Text = vg.Decrypt(textBoxWrite.Text, texBoxKey.Text.ToLower());
                else
                    MessageBox.Show("Введите сообщение");
            }
            else
            {            
                MessageBox.Show($"Введите корректный ключ на {vg.message}");
            }
                
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            VigenereCipher vg = new VigenereCipher((bool)radioButtonRus.IsChecked);

            if (!string.IsNullOrWhiteSpace(texBoxKey.Text) && (Regex.Match(texBoxKey.Text, vg.regex).Success))
            {
                             
                if (!string.IsNullOrWhiteSpace(textBoxWrite.Text))
                    texBoxRead.Text = vg.Encrypt(textBoxWrite.Text, texBoxKey.Text.ToLower());
                else
                    MessageBox.Show("Введите сообщение");
            }
            else
            {
                MessageBox.Show($"Введите корректный ключ на {vg.message}");
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {    
            texBoxRead.Clear();
            textBoxWrite.Clear();
        }
    }
}

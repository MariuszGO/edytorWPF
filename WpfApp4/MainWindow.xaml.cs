using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace WpfApp4
{
  
    public partial class MainWindow : Window
    {
        string nazwa;
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog plik = new OpenFileDialog();
            plik.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";  
            if (plik.ShowDialog() == true)
            {
                try
                {
                    
                    string zawartosc = File.ReadAllText(plik.FileName);
                    pole.Text = zawartosc;
                    nazwa = Path.GetFileName(plik.FileName);

                    MenuSave.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas otwierania pliku: " + ex.Message);
                }
            }
        }

        

        /*
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog plik = new OpenFileDialog();
            plik.Filter = "All files (*.txt)|*.txt";  

            if (plik.ShowDialog() == true)
            {
                try
                {
                    
                    nazwa = Path.GetFileName(plik.FileName);
                    pole.Text = "Selected file: " + nazwa;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas pobierania nazwy pliku: " + ex.Message);
                }
            }
        }
        */
        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(nazwa))
            {
                try
                {
             
                    File.WriteAllText(nazwa, pole.Text);
                    MessageBox.Show("Plik zapisany pomyślnie.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas zapisywania pliku: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano pliku do zapisu.");
            }
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
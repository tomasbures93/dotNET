using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;

namespace RegEx___WPF_validierung
{
    public partial class MainWindow : Window
    {
        static bool inputNameOk = false;
        static bool inputEmailOk = false;
        static bool inputTelefonOk = false;
        static bool inputIPOk = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void nameInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (Regex.IsMatch(nameInput.Text, @"^[^@#!$&]+$"))
            {
                validierungName.Foreground = Brushes.Green;
                validierungName.Content = "OK";
                inputNameOk = true;
            } 
            else
            {
                if(nameInput.Text.Length >= 2)
                {
                    validierungName.Foreground = Brushes.Red;
                    validierungName.Content = "@,#,!,$,& sind nicht erlaubt";
                    inputNameOk = false;
                } 
                else
                {
                    validierungName.Content = "";
                    inputNameOk = false;
                }
            }
        }

        private void emailInput_KeyUp(object sender, KeyEventArgs e)
        {
            if(Regex.IsMatch(emailInput.Text, @"[A-Za-z0-9.-]*@[A-Za-z0-9-]*\.[A-Za-z0-9]{2,5}$"))
            {
                validierungEmail.Foreground = Brushes.Green;
                validierungEmail.Content = "OK";
                inputEmailOk = true;
            }
            else
            {
                if (emailInput.Text.Length >= 2)
                {
                    validierungEmail.Foreground = Brushes.Red;
                    validierungEmail.Content = "Email Adresse ist nicht vollstandig";
                    inputEmailOk = false;
                }
                else
                {
                    validierungEmail.Content = "";
                    inputEmailOk = false;
                }
            }
        }

        private void telefonInput_KeyUp(object sender, KeyEventArgs e)
        {
            if(Regex.IsMatch(telefonInput.Text, @"\+[0-9]{2,3}(( |)[0-9]{3,4}( |)[0-9]{4,7}|[0-9]{9})$"))
            {
                validierungTelefon.Foreground = Brushes.Green;
                validierungTelefon.Content = "Ok";
                inputTelefonOk = true;
            } else
            {
                if(telefonInput.Text.Length >= 10 && telefonInput.Text.Length < 17)
                {
                    validierungTelefon.Foreground= Brushes.Red;
                    validierungTelefon.Content = "Falsche Telefon-nummer";
                    inputTelefonOk = false;
                } 
                else
                {
                    validierungTelefon.Content = "";
                    inputTelefonOk = false;
                }
            }
        }

        private void ipInput_KeyUp(object sender, KeyEventArgs e)
        {
            if(Regex.IsMatch(ipInput.Text, @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$"))
            {
                validierungIp.Foreground = Brushes.Green;
                validierungIp.Content = "Ok";
                inputIPOk = true;
            } 
            else
            {
                if (ipInput.Text.Length >= 7 && telefonInput.Text.Length < 16)
                {
                    validierungIp.Foreground = Brushes.Red;
                    validierungIp.Content = "Falsche IPv4 adresse";
                    inputIPOk = false;
                }
                else
                {
                    validierungIp.Content = "";
                    inputIPOk = false;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (inputNameOk == true && inputTelefonOk == true && inputEmailOk == true && inputIPOk == true) {

                // MANUELLE PFAD EINGABE
                //string pfad = @"C:\Users\ITA7-TN01\Desktop\text.txt";
                //FileStream stream = new FileStream(pfad, FileMode.Open, FileAccess.Write);
                //StreamWriter writer = new StreamWriter(stream);
                //writer.Write(text);
                //writer.Close();

                // FENSTER PFAD EINGABE
                string text = $"{nameInput.Text};{emailInput.Text};{telefonInput.Text};{ipInput.Text}";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text file (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, text);
                    MessageBox.Show("Speichern erfolgreich");
                }
            }
            else
            {
                MessageBox.Show("Speichern nicht erlaubt! Falsche eingabe!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            nameInput.Text = ""; 
            validierungName.Content = "";
            emailInput.Text = "";
            validierungEmail.Content = "";
            telefonInput.Text = "";
            validierungTelefon.Content = "";
            ipInput.Text = "";
            validierungIp.Content = "";
        }
    }
}
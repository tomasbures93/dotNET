using Extra___ChecksumCalculator.Models;
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

namespace Extra___ChecksumCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            output.Content = "";
            inputString.Text = "";
            inputString.BorderBrush = Brushes.Black;
        }

        private void Button_Validate(object sender, RoutedEventArgs e)
        {
            ValidateSumme();
        }
        private void Button_Berechne(object sender, RoutedEventArgs e)
        {
            BerechnePruefSumme();
        }

        public void BerechnePruefSumme()
        {
            ValidateInput();
            switch (comboBox.Text)
            {
                case "Kreditkartennummer":
                    if (inputString.Text.Length != 16)
                    {
                        output.Content = "Number has to be 16 digits long";
                        return;
                    } 
                    else
                    {
                        BerechnePruefSummeKreditkarte();
                    }
                    break;
                case "ISBN-10":
                    if (inputString.Text.Length != 9)
                    {
                        output.Content = "Number has to be 9 digits long";
                        return;
                    } else
                    {
                        BerechnePruefSummeISBN10();
                    }
                    break;
                case "ISBN-13":
                    if (inputString.Text.Length != 12)
                    {
                        output.Content = "Number has to be 12 digits long";
                        return;
                    } else
                    {
                        BerechnePruefSummeISBN13();
                    }
                    break;
            }
        }

        public void ValidateInput()
        {
            inputString.BorderBrush = Brushes.Black;
            output.Content = "";
            if (string.IsNullOrEmpty(inputString.Text))
            {
                return;
            }
            if (inputString.Text.Contains("-"))
            {
                inputString.Text = inputString.Text.Replace("-", "");
            }
            if (inputString.Text.Contains(" "))
            {
                inputString.Text = inputString.Text.Replace(" ", "");
            }
        }

        public void ValidateSumme()
        {
            ValidateInput();
            switch (comboBox.Text)
            {
                case "Kreditkartennummer":
                    if (inputString.Text.Length != 17)
                    {
                        output.Content = "Number has to be 17 digits long";
                        return;
                    }
                    else
                    {
                        ValidateKreditKarte();
                    }
                    break;
                case "ISBN-10":
                    if (inputString.Text.Length != 10)
                    {
                        output.Content = "Number has to be 10 digits long";
                        return;
                    }
                    else
                    {
                        ValidateISBN10();
                    }
                    break;
                case "ISBN-13":
                    if (inputString.Text.Length != 13)
                    {
                        output.Content = "Number has to be 13 digits long";
                        return;
                    }
                    else
                    {
                        ValidateISBN13();
                    }
                    break;
            }
        }

        public void BerechnePruefSummeKreditkarte()
        {
            LuhnChecksumCalculator input = new LuhnChecksumCalculator(inputString.Text);
            if (input.IsNumeric(inputString.Text) == true)
            {
                string pruefsumme = input.CalculateCheckDigit(inputString.Text);
                output.Content = $"Your Checksum is {pruefsumme}";
            }
        }
        public void ValidateKreditKarte()
        {
            LuhnChecksumCalculator input = new LuhnChecksumCalculator(inputString.Text);
            if (input.IsNumeric(inputString.Text) == true)
            {
                bool validate = input.Validate(inputString.Text);
                if (validate)
                {
                    output.Content = "Credit Card is valid";
                    inputString.BorderBrush = Brushes.Green;
                }
                else
                {
                    output.Content = "Credit Card is not usable, ITS FAKE";
                    inputString.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                output.Content = "Wrong input!";
            }
        }

        private void BerechnePruefSummeISBN13()
        {
            ISBN13ChecksumCalculator input = new ISBN13ChecksumCalculator(inputString.Text);
            if (input.IsNumeric(inputString.Text) == true)
            {
                string pruefsumme = input.CalculateCheckDigit(inputString.Text);
                output.Content = $"Your Checksum is {pruefsumme}";
            }
        }
        private void ValidateISBN13()
        {
            ISBN13ChecksumCalculator input = new ISBN13ChecksumCalculator(inputString.Text);
            if (input.IsNumeric(inputString.Text))
            {
                bool validate = input.Validate(inputString.Text);
                if (validate)
                {
                    output.Content = "ISBN13 Checksum was succesful!";
                    inputString.BorderBrush = Brushes.Green;
                }
                else
                {
                    output.Content = "ISBN13 Checksum was not succesful!";
                    inputString.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                output.Content = "Wrong input!";
            }
        }
        private void BerechnePruefSummeISBN10()
        {
            ISBN10ChecksumCalculator input = new ISBN10ChecksumCalculator(inputString.Text);
            if (input.IsNumeric(inputString.Text) == true)
            {
                string pruefsumme = input.CalculateCheckDigit(inputString.Text);
                output.Content = $"Your Checksum is {pruefsumme}";
            }
        }

        private void ValidateISBN10()
        {
            ISBN10ChecksumCalculator input = new ISBN10ChecksumCalculator(inputString.Text);
            if (input.IsNumeric(inputString.Text) == true)
            {
                bool validate = input.Validate(inputString.Text);
                if (validate)
                {
                    output.Content = "ISBN10 Checksum was succesful!";
                    inputString.BorderBrush = Brushes.Green;
                } 
                else
                {
                    output.Content = "ISBN10 Checksum was not succesful!";
                    inputString.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                output.Content = "Wrong input!";
            }
        }
    }
}
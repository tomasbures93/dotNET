using JSON___Produkte.Models;
using System.IO;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JSON___Produkte
{
    public partial class MainWindow : Window
    {
        static List<Lager> products;
        static List<Warenkorb> warenkorb = new List<Warenkorb>();
        public MainWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            // path wo das datei liegt
            string load = @"C:\Users\ITA7-TN01\Desktop\dotNet_Desktop\09b - Serialisierung\Aufgabe\Produkte.json";
            using (StreamReader sr = new StreamReader(load))
            {
                string json = sr.ReadToEnd();
                products = JsonSerializer.Deserialize<List<Lager>>(json);
            }
            foreach (var lager in products)
            {
                kategorienCombo.Items.Add(lager.CategoryName);
            }
            kategorienCombo.SelectedIndex = 0;
        }

        private void Kategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Products.Items.Clear();
            if(warenkorb.Count == 0)
            {
                warenkorbButton.Visibility = Visibility.Hidden;
                warenkorbProducts.Visibility = Visibility.Hidden;
                buyButton.Visibility = Visibility.Hidden;
            }

            ProduktPrice.Text = "";
            foreach (var lager in products)
            {
                if(lager.CategoryName == kategorienCombo.SelectedItem.ToString())
                foreach (var product in lager.Products)
                {
                    Products.Items.Add(product.Name);
                }
            }
        }

        private void Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProduktName.Text = Products.SelectedItem?.ToString();
            warenkorbButton.Visibility = Visibility.Visible;
            foreach (var lager in products)
            {
                if (lager.CategoryName == kategorienCombo.SelectedItem.ToString())
                {
                    foreach (var product in lager.Products)
                    {
                        if (product.Name == ProduktName.Text)
                        {
                            ProduktPrice.Text = product.Price.ToString() + " €";
                        }
                    }
                }   
            }
        }

        private void WarenkorbButton_Clicked(object sender, RoutedEventArgs e)
        {
            double price = 0;
            price = double.Parse(ProduktPrice.Text.Remove(ProduktPrice.Text.Length - 2));
            warenkorb.Add(new Warenkorb(kategorienCombo.SelectedItem.ToString(), ProduktName.Text, price));
            warenkorbProducts.Visibility = Visibility.Visible;
            buyButton.Visibility = Visibility.Visible;
            warenkorbProducts.Items.Clear();
            foreach(var item in warenkorb)
            {
                warenkorbProducts.Items.Add(item.ToString());
            }
        }

        private void BuyButton_Clicked(object sender, RoutedEventArgs e)
        {
            string save = @"C:\Users\ITA7-TN01\Desktop\dotNet_Desktop\09b - Serialisierung\Aufgabe\buy.json";
            double price = 0;
            int itemscounte = 0;
            using (StreamWriter sw = new StreamWriter(save))
            {
                foreach(var item in warenkorb)
                {
                    Warenkorb korb = new Warenkorb()
                    {
                        Category = item.Category,
                        PartName = item.PartName,
                        PartPrice = item.PartPrice
                    };
                    itemscounte++;
                    price += item.PartPrice;
                    string json = JsonSerializer.Serialize(korb);
                    sw.WriteLine(json);
                }
            }
            MessageBox.Show($"You have bought {itemscounte} item/s | Total Price: {price} €");
            warenkorb.Clear();
            warenkorbButton.Visibility = Visibility.Hidden;
            warenkorbProducts.Visibility = Visibility.Hidden;
            buyButton.Visibility = Visibility.Hidden;
        }
    }
}
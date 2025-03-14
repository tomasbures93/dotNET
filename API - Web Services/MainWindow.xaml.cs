using API___Web_Services.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
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
using static System.Net.Mime.MediaTypeNames;

namespace API___Web_Services
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string url = $"https://api.predic8.de/shop/v2/products/";
        static List<Product> produkt = new List<Product>() ;
        public MainWindow()
        {
            InitializeComponent();

            ListBoxFuhlen();

        }
        
        private async void ListBoxFuhlen()
        {
            ProduktResponse response = await LoadDataAll();

            foreach (var product in response.products)
            {
                productList.Items.Add(product.name);
                produkt.Add(product);
            }
        }

        static async Task<ProduktResponse> LoadDataAll()
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetFromJsonAsync<ProduktResponse>(url);
            }
        }

        static async Task<ProduktInfo> LoadDataProdukt(string value)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetFromJsonAsync<ProduktInfo>(value);
            }
        }

        private async void productList_Selected(object sender, RoutedEventArgs e)
        {
            produktName.Text = productList.SelectedValue as string;
            string produktik = produkt.FirstOrDefault(x => x.name == produktName.Text)?.self_link;
            ProduktInfo produktInfo = await LoadDataProdukt(@"https://api.predic8.de" + produktik);
            produktPrice.Text = produktInfo.price.ToString();
            produktHersteller.Text = produktInfo.vendors[0].name;     

            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@"https://api.predic8.de" + produktInfo.image_link, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                image.Source = bitmap;
                image.Height = 400;
                image.Width = 400;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
    }
}
﻿using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Threads___FavIcon___WPF
{
    
    public partial class MainWindow : Window
    {
        static string[] websites = {"google.de", "bing.com", "heise.de", "microsoft.com", "facebook.com",
                                    "twitter.com", "amazon.de", "spiegel.de", "rheinwerk-verlag.de",
                                    "reddit.com", "youtube.de", "de.wikipedia.org"};
        CancellationTokenSource cts;
        public MainWindow()
        {
            InitializeComponent();

            foreach (var site in websites)
            {
                ListBox1Websites.Items.Add(site);
            }
            stopDownload.IsEnabled = false;
        }

        private BitmapImage ByteArrayToBitmapImage(byte[] imageData)
        {
            try
            {
                using (var ms = new System.IO.MemoryStream(imageData))
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
            catch
            {
                return null;
            }
        }

        private async void buttonDownload_ClickAsync(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            downloadButton.IsEnabled = false;
            stopDownload.IsEnabled = true;
            foreach (var site in websites)
            {
                try
                {
                    cts = new CancellationTokenSource();
                    await Task.Run(() =>
                    {
                        iconDownload(site, cts.Token);
                    });
                    this.Cursor = Cursors.Arrow;
                    downloadButton.IsEnabled = true;
                    stopDownload.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Arrow;
                    downloadButton.IsEnabled = true;
                    stopDownload.IsEnabled = false;
                }
                
            }
        }

        private async void iconDownload(string url, CancellationToken token)
        {
            using (HttpClient client = new HttpClient())
            {  
                try
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    var array = await client.GetByteArrayAsync("https://www." + url + "/favicon.ico");
                    BitmapImage img = null;
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        img = ByteArrayToBitmapImage(array);
                    });
                    if (img != null)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Image image = new Image();
                            image.Source = img;
                            image.Width = 32;
                            image.Height = 32;
                            stackPanelImages.Children.Add(image);
                        }); // Sicherstellen, dass die UI nicht crasht
                    }
                }
                catch (HttpRequestException ex)
                {
                }

            }
        }

        private void stopDownload_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
        }
    }
}
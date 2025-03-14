using System.Net.Http;
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
            cts = new CancellationTokenSource();
            foreach (var site in websites)
            {
                try
                {
                    await Task.Run(() =>
                        iconDownload(site, cts.Token), cts.Token);
                    this.Cursor = Cursors.Arrow;
                    downloadButton.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Arrow;
                    downloadButton.IsEnabled = true;
                }
            }
            stopDownload.IsEnabled = false;
        }

        private void iconDownload(string url, CancellationToken token)
        {
            using (HttpClient client = new HttpClient())
            {  
                try
                {
                    token.ThrowIfCancellationRequested();

                    var array = client.GetByteArrayAsync("https://www." + url + "/favicon.ico");
                    BitmapImage img = null;

                    try
                    {
                        if(array.Result != null)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                img = ByteArrayToBitmapImage(array.Result);
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        ausnahme.AppendText(ex.Message + "\n")
                        );
                    }
                    
                    if (img != null)
                    {
                        // Generating Picture and Adding it into Stackpanel
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Image image = new Image();
                            image.Source = img;
                            image.Width = 32;
                            image.Height = 32;
                            stackPanelImages.Children.Add(image);
                        }); 
                    }

                }
                catch (HttpRequestException ex)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        ausnahme.AppendText(ex.Message);
                    });
                }
            }
        }

        private void stopDownload_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
            ausnahme.AppendText("Cancel button pressed!");
        }

        private void clearIcons_Click(object sender, RoutedEventArgs e)
        {
            stackPanelImages.Children.Clear();
            ausnahme.Text = string.Empty;
        }
    }
}
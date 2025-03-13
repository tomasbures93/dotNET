using System.ComponentModel;
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

namespace Threads___PI_Berechnen_Async_und_Await
{
    public partial class MainWindow : Window
    {
        CancellationTokenSource cts;
        public MainWindow()
        {
            InitializeComponent();

            // Alles auf Default wert setzen
            pistatisch.Content = Math.PI;
            berechnetepi.Content = "";
            abbrechenButton.IsEnabled = false;
            progressBar1.Value = 0;
            progressPercent.Content = 0;
        }

        private async void berechneButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();            // Token mit welche kann ich sachen Canceln
            this.Cursor = Cursors.Wait;
            berechneButton.IsEnabled = false;
            abbrechenButton.IsEnabled = true;
            progressPercent.Visibility = Visibility.Visible;

            Progress<int> progress = new Progress<int>(percent =>
            {
                progressBar1.Value = percent;
                progressPercent.Content = percent.ToString() + " %";
            });                                                             // Verbingung zwischen ComputePi and Elementen ... kvasi ich gebe diese variable weiter
                                                                            // und die sie berechnet in ComputePi

            try
            {
                double erg = await Task.Run(
                    () => ComputePi(cts.Token, progress), cts.Token);
                berechnetepi.Content = erg;
                berechneButton.IsEnabled = true;
                abbrechenButton.IsEnabled = false;
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                berechneButton.IsEnabled = true;
                abbrechenButton.IsEnabled = false;
                this.Cursor = Cursors.Arrow;
            }
        }

        private double ComputePi(CancellationToken cancellationToken, IProgress<int> progress)
        {
            double sum = 0.0;
            long totalSteps = 1_000_000_000;
            const double step = 1e-9;
            for (int i = 0; i <= totalSteps; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return double.NaN;
                }

                if (i % totalSteps == 0) 
                {
                    int percent = (int)((i / (double)totalSteps) * 100);
                    progress.Report(percent);                                   // Reports update zu unsere variable
                }

                double x = (i + 0.5) * step;
                sum += 4.0 / (1.0 + x * x);
            }

            return sum * step;
        }

        private void abbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
            this.Cursor = Cursors.Arrow;
        }
    }
}
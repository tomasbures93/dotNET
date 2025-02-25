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
using WPF___Spaceship_simulator.Models;

namespace WPF___Spaceship_simulator
{
    public partial class MainWindow : Window
    {
        private Playership player;
        private bool pause;
        private bool startgame;
        public MainWindow()
        {
            InitializeComponent();
            startgame = false;
            pause = false;
            Menu.Visibility = Visibility.Visible;
            MainView.Visibility = Visibility.Collapsed;
            LoadShips();
        }

        public void LoadShips()
        {
            player = new Playership();
            space.Children.Add(player.Sprite);
            Canvas.SetLeft(player.Sprite, player.X);
            Canvas.SetBottom(player.Sprite, player.Y);
        }

        private void space_KeyDown(object sender, KeyEventArgs e)
        {
            if(pause == true)
            {
                return;
            }
            UpdateInfo();
            if (e.Key == Key.Right && e.Key == Key.Down)
            {
                player.MoveRight();
                Canvas.SetLeft(player.Sprite, player.X);
                player.MoveUp();
                Canvas.SetBottom(player.Sprite, player.Y);
            }
            if (e.Key == Key.Right && e.Key == Key.Up)
            {
                player.MoveRight();
                Canvas.SetLeft(player.Sprite, player.X);
                player.MoveDown();
                Canvas.SetBottom(player.Sprite, player.Y);
            }
            if (e.Key == Key.Left && e.Key == Key.Up)
            {
                player.MoveLeft();
                Canvas.SetLeft(player.Sprite, player.X);
                player.MoveDown();
                Canvas.SetBottom(player.Sprite, player.Y);
            }
            if (e.Key == Key.Left && e.Key == Key.Down)
            {
                player.MoveLeft();
                Canvas.SetLeft(player.Sprite, player.X);
                player.MoveUp();
                Canvas.SetBottom(player.Sprite, player.Y);
            }
            if (e.Key == Key.Left)
            {
                if(player.X > 0)
                {
                    player.MoveLeft();
                    Canvas.SetLeft(player.Sprite, player.X);
                }
            }
            if(e.Key == Key.Right)
            {
                if(player.X < 700)
                {
                    player.MoveRight();
                    Canvas.SetLeft(player.Sprite, player.X);
                }
            }
            if(e.Key == Key.Down)
            {
                if(Canvas.GetBottom(player.Sprite) > 10)
                {
                    player.MoveUp();
                    Canvas.SetBottom(player.Sprite, player.Y);
                }
            }
            if(e.Key == Key.Up)
            {
                if(Canvas.GetBottom(player.Sprite) < 150)
                {
                    player.MoveDown();
                    Canvas.SetBottom(player.Sprite, player.Y);
                }
            }
            if(e.Key == Key.Escape)
            {
                ChangeWindow();
            }
           
        }

        public void ChangeWindow()
        {
            if(Name.Text == "")
            {
                MessageBox.Show("Please insert Spaceship name.");
                return;
            }
            if(startgame == false)
            {
                player.Name = Name.Text;
                startgame = true;
                UpdateInfo();
            }
            if(MainView.Visibility == Visibility.Visible)
            {
                Menu.Visibility = Visibility.Visible;
                MainView.Visibility = Visibility.Collapsed;
                pause = true;
            } 
            else
            {
                Menu.Visibility = Visibility.Collapsed;
                MainView.Visibility = Visibility.Visible;
                pause = false;
            }
        }

        public void UpdateInfo()
        {
            GetB.Content = $"X: {player.X}";
            GetL.Content = $"Y: {player.Y}";
            shipName.Content = $"Name: {player.Name}";
            HP.Content = $"HP: {player.HP}";
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            ChangeWindow();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
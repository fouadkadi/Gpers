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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;

namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        static bool ouverte = false;
        public Start()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Height = ActualHeight;
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 700;
            myDoubleAnimation.To = 0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(3));
            myDoubleAnimation.AutoReverse = false;
            myStackPanel.BeginAnimation(StackPanel.HeightProperty, myDoubleAnimation);
            SolidColorBrush myBrush = new SolidColorBrush();
            myBrush.Color = Colors.DarkCyan;
            myStackPanel.Background = myBrush;
            RF.Children.Add(myStackPanel);
            XpsDocument doc = new XpsDocument($@"{System.IO.Directory.GetCurrentDirectory()
                        }\Projet04_Equipe02_kacet_daoudi_Manuel d'utilisation_2018.Xps", FileAccess.Read);

            docview.Document = doc.GetFixedDocumentSequence();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rec1.Width = 424;
            rec2.Width = 424;
            Lab.Visibility = Visibility.Visible;
            Lab.Opacity = 0;

            Butt.Visibility = Visibility.Visible;
            Butt.Opacity = 0;
            connection.Visibility = Visibility.Visible;
            connection.Opacity = 0;
            logo.Visibility = Visibility.Visible;
            logo.Opacity = 0;
            
        }


        
        private void connection_Click(object sender, RoutedEventArgs e)
        {
            login_user_ win = new login_user_();
            win.Show();
            
        }
        public static void cls()
        {
            ouverte = false;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void min_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ThicknessAnimation_Completed(object sender, EventArgs e)
        {
            rec1.Width = 0;
            rec2.Width = 0;
        }

        private void ThicknessAnimation_Completed_1(object sender, EventArgs e)
        {

        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {

        }

        private void DoubleAnimation_Completed_1(object sender, EventArgs e)
        {
            Lab.Visibility = Visibility.Collapsed;
            Butt.Visibility = Visibility.Collapsed;
            connection.Visibility = Visibility.Collapsed;
            logo.Visibility = Visibility.Collapsed;
        }
    }
}

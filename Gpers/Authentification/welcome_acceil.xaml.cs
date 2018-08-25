using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Media.Animation;


namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour welcome_acceil.xaml
    /// </summary>
    public partial class welcome_acceil : UserControl
    {
        Auth Client;
        public welcome_acceil()
        {
            InitializeComponent();
            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={ System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
            bool full = false;
            info_entreprise informa;
            DataClasses1DataContext db = new DataClasses1DataContext(connectString);
            //============================= Animatio ======================================//
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Height = ActualHeight;
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 700;
            myDoubleAnimation.To = 0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            myDoubleAnimation.AutoReverse = false;
            myStackPanel.BeginAnimation(StackPanel.HeightProperty, myDoubleAnimation);
            SolidColorBrush myBrush = new SolidColorBrush();
            myBrush.Color = Colors.White;
            //===============================================================================//


            //=================== Recuparation des informations ==========================//

            info_entreprise info = (from recup in db.info_entreprise select recup).FirstOrDefault();

            if (info != null)
            {
                byte[] array = (byte[])info.Logo.ToArray();

                File.WriteAllBytes($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\logo.png", array);
                File.WriteAllBytes($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\modeles\logo.png", array);
                logo.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "logo.png", UriKind.Absolute));
            }
                myStackPanel.Background = myBrush;


            g.Children.Add(myStackPanel);



            this.Content = g;

            int i = 0;

            //========================= Bouton de notification ==================================//
            IQueryable<Recrutement> list = from recup in db.Recrutement
                                           select recup;
            foreach (Recrutement rec in list)
            { if (rec.date_ent_ != null ) { i++; } }
            badgedentretien.Badge = i;
            IQueryable<objectif> list2 = from recup in db.objectif where  recup.fin<DateTime.Today
                                           select recup;
            badgeobjectif.Badge = list2.Count();


            //======================== Raison sociale ================================//

            raison.Text = info.Raison_so;

        }

        //========================  Click sur un des boutons de notification =============================//
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User7 win = new User7();
            win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Notif win = new Notif();
            win.Show();
        }
    }

}
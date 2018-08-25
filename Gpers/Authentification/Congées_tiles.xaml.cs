using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour Congées_tiles.xaml
    /// </summary>
    public partial class Congées_tiles : UserControl
    {
        public Congées_tiles()
        {
            InitializeComponent();
        }

        private void planing_click(object sender, RoutedEventArgs e)
        {
            Congées win = new Congées(0);
            win.Show();
        }
        private void ajout_click(object sender, RoutedEventArgs e)
        {
            Congées win = new Congées(1);
            win.Show();
        }
    }
}

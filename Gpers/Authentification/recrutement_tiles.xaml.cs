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
    /// Logique d'interaction pour recrutement_tiles.xaml
    /// </summary>
    public partial class recrutement_tiles : UserControl
    {
        public recrutement_tiles()
        {
            InitializeComponent();
        }

        private void condiat_click(object sender, RoutedEventArgs e)
        {
            recrue_view win = new recrue_view();
            win.Show();

        }

        private void entretien_click(object sender, RoutedEventArgs e)
        {
            Entretien_view win = new Entretien_view();
            win.Show();
        }
    }
}

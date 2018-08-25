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
    /// Logique d'interaction pour objectif_tiles.xaml
    /// </summary>
    public partial class objectif_tiles : UserControl
    {
        public objectif_tiles()
        {
            InitializeComponent();
        }

        private void Définir_click(object sender, RoutedEventArgs e)
        {
            objectif_ajout win = new objectif_ajout();
            win.Show();
        }

        private void evaclick(object sender, RoutedEventArgs e)
        {
            Evaluation win = new Evaluation();
            win.Show();
        }
    }
}

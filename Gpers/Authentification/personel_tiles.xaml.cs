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
    /// Logique d'interaction pour personel_tiles.xaml
    /// </summary>
    public partial class personel_tiles : UserControl
    {
        public personel_tiles()
        {
            InitializeComponent();
        }

        private void ajouter_employée(object sender, RoutedEventArgs e)
        {
            ajout_employée win = new ajout_employée();

            win.Show();

        }

        private void modif_click(object sender, RoutedEventArgs e)
        {
            modif_employée win = new modif_employée();
            win.Show();

        }

        private void annuaire_checked(object sender, RoutedEventArgs e)
        {
          Annuaire_view win = new Annuaire_view();
            win.Show();
        }

        private void Document_click(object sender, RoutedEventArgs e)
        {
            Génération_document win = new Génération_document();
            win.Show();
        }
    }
}

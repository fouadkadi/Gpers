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
    /// Logique d'interaction pour User6.xaml
    /// </summary>
    public partial class User6 : UserControl
    {
        private int id;
        public void set(int id) { this.id = id; }
        public User6()
        {
            InitializeComponent();
        }
        private void entretien_Click(object sender, RoutedEventArgs e)
        {

            fiche_ent fiche = new fiche_ent();
            fiche.setid(id);
            fiche.Show();
        }
    }
}

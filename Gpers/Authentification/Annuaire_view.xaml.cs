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
using System.Windows.Shapes;

namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour Annuaire_view.xaml
    /// </summary>
    public partial class Annuaire_view : Window
    {
        Annuaire win = new Annuaire();
        Annuaire2 win2 = new Annuaire2();
        public Annuaire_view()
        {
            InitializeComponent();
            //mygrid.Children.Add(  win);
            view.Content = win;
        }

        private void toogle_Click(object sender, RoutedEventArgs e)
        {
            if (toogle.IsChecked.Value == true) { view.Content = win; }
            else { view.Content = win2; }

        }
    }
}

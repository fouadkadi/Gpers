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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void condiat_click(object sender, RoutedEventArgs e)
        {
            Annuaire win = new Annuaire();
            win.Show();

        }

        private void entretien_click(object sender, RoutedEventArgs e)
        {
            Annuaire2 win = new Annuaire2();
            win.Show();
        }
    }
}

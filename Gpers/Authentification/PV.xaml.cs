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
    /// Logique d'interaction pour PV.xaml
    /// </summary>
    public partial class PV : Window
    {
        public PV(List<LView> l)
        {
            InitializeComponent();
            lvw.ItemsSource = l;
        }
        public PV()
        {
            InitializeComponent();

        }

    }
    public class LView
    {
        public string Objectif { get; set; }

        public string Type { get; set; }

        public string Evaluation { get; set; }
    }
}

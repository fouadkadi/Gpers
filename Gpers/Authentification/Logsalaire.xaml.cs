using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Logique d'interaction pour Logsalaire.xaml
    /// </summary>
    public partial class Logsalaire : Window
    {
        public Logsalaire()
        {
            InitializeComponent();
            string connectString = $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = { System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf; Integrated Security = True; Connect Timeout = 30";
            DataClasses1DataContext db = new DataClasses1DataContext(connectString);
            IQueryable<Salaire> list = from sal in db.Salaire
                                       select sal;
            gridsalaire.ItemsSource = list;
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour User1.xaml
    /// </summary>
    public partial class User1 : UserControl
    {
        private int id;
        public User1()
        {
            InitializeComponent();
        }
        public void set(int id) { this.id = id; }
        private void planif(object sender, RoutedEventArgs e)
        {
            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
            // initialitation de la preimiere fenetre et tout ce qui doit apparaitre en premier ... 

            DataClasses1DataContext db = new DataClasses1DataContext(connectString);
            Recrutement re = (from recup in db.Recrutement
                              where recup.matricule == id
                              select recup).FirstOrDefault();
           

            DateTime dt = new DateTime();
            dt = (DateTime)date.SelectedDate;
            if (date.SelectedDate != null && DateTime.Today.DayOfYear<dt.DayOfYear)
            {
                

                
                re.date_ent_ = dt;
                db.SubmitChanges();
                alert_text.Text="bien planifier";
                alert.IsOpen = true;
            }
            else
            { alert_text.Text="veiller introduire la date "; alert.IsOpen = true; }
        }
    }
}

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
    /// Logique d'interaction pour User7.xaml
    /// </summary>
    public partial class User7 : Window
    {
        public User7()
        {
            InitializeComponent();
            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
            // initialitation de la preimiere fenetre et tout ce qui doit apparaitre en premier ... 

            DataClasses1DataContext db = new DataClasses1DataContext(connectString);

            IQueryable<Recrutement> list = from recup in db.Recrutement
                                           orderby recup.date_ent_
                                           select recup;



            affic_ent_planif(list);
        }

        private void affic_ent_planif(IQueryable list)
        {
            panel.Children.Clear();
            foreach (Recrutement recup in list)
            {
                if (recup.date_ent_ != null)
                {
                    var flip = new User6();
                    flip.set(recup.matricule);
                    flip.ninom.Text = recup.nom_dm;
                    flip.poste.Text = recup.int_post;
                    TextBlock txt4 = new TextBlock();
                    DateTime date = new DateTime();
                    date = (DateTime)recup.date_ent_;
                    flip.date.Text = date.ToShortDateString();
                    flip.numtel.Text = "0" + recup.num.ToString();
                    flip.email.Text = recup.Adr_mail;
                    panel.Children.Add(flip);
                }
            }
        }
    }
}

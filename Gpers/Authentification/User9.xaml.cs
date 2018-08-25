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
    /// Logique d'interaction pour User9.xaml
    /// </summary>
    public partial class User9 : Window
    {
        static string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
        // initialitation de la preimiere fenetre et tout ce qui doit apparaitre en premier ... 

        DataClasses1DataContext db = new DataClasses1DataContext(connectString);
        public User9()
        {
            InitializeComponent();
            ////    Recup la liste des recrues 
            IQueryable<Entretien> list = from recup in db.Entretien
                                         orderby recup.date
                                         select recup;





            afficheur_Ent(list);
        }
        private void afficheur_Ent(IQueryable list)
        {
            

            panel.Children.Clear();
            foreach (Entretien recup in list)
            {
                Recrutement r = (from rp in db.Recrutement where rp.matricule == recup.matricule select rp).FirstOrDefault();
                if (r != null)
                {
                    var flip = new User8();
                    flip.set(r.matricule);
                    flip.ninom.Text = r.nom_dm;
                    flip.poste.Text = r.int_post;
                    TextBlock txt4 = new TextBlock();
                    DateTime date = new DateTime();
                    date = (DateTime)recup.date;
                    flip.date.Text = date.ToShortDateString();
                    flip.numtel.Text = "0" + r.num.ToString();
                    flip.email.Text = r.Adr_mail;
                    panel.Children.Add(flip);
                    flip.experience.Text = recup.exp;
                    flip.Q1.Text = recup.Q1;
                    flip.eva_q1.Text = ((int)recup.evaQ1).ToString();
                    flip.Q2.Text = recup.Q2;
                    flip.eva_q2.Text = ((int)recup.evaQ2).ToString();
                    flip.etape_suiv.Text = recup.etape_suiv;

                }


            }





        }
    }
}

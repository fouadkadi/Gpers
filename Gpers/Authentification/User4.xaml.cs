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
    /// Logique d'interaction pour User4.xaml
    /// </summary>
    public partial class User4 : Window
    {
        public User4()
        {
            InitializeComponent();
            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
            // initialitation de la preimiere fenetre et tout ce qui doit apparaitre en premier ... 

            DataClasses1DataContext db = new DataClasses1DataContext(connectString);
            ////    Recup la liste des recrues 
            IQueryable<Recrutement> list = from recup in db.Recrutement
                                           select recup;



            afficheur_Rec(list);
        }
        //------ List des Recrues avec bouton ( listbox + grid )
        private void afficheur_Rec(IQueryable list)
        {

            panel.Children.Clear();
            foreach (Recrutement recup in list)
            {
                var flip = new User3();

                flip.ninom.Text = recup.nom_dm;
                flip.poste.Text = recup.int_post;
                flip.numtel.Text = "0" + recup.num.ToString();
                flip.email.Text = recup.Adr_mail;
                panel.Children.Add(flip);
            }
        }
    }
}

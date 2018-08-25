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
    /// Logique d'interaction pour Evaluation.xaml
    /// </summary>
    public partial class Evaluation : Window
    {
        HashSet<string> list = new HashSet<string>();
        static string connectString = $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = { System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf; Integrated Security = True; Connect Timeout = 30";
        DataClasses1DataContext db = new DataClasses1DataContext(connectString);
        public Evaluation()
        {
            InitializeComponent();
            IQueryable<info_comp> poste = from rec in db.info_comp
                                          select rec;
            foreach (info_comp rec in poste)
            {
                list.Add(rec.poste);
                
            }

            
            filtre.ItemsSource = list;
            
        }

        private void recherche_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            bool trv = false;
            IQueryable<Employee> list = from rec in db.Employee
                                        select rec;
            IQueryable<info_comp> list1 = from rec1 in db.info_comp
                                          select rec1;
            if (!search.Text.Equals("") || (filtre.SelectedIndex) >= 0)
            {
                foreach (Employee rec in list)
                {
                    if (!search.Text.Equals("") && (filtre.SelectedIndex) >= 0)
                    {

                        if (((rec.nom.Equals(search.Text)) || ((rec.nom + " ").Equals(search.Text)) || rec.prenom.Equals(search.Text) || ((rec.prenom + " ").Equals(search.Text)) || ((rec.nom + " " + rec.prenom).Equals(search.Text)) || ((rec.prenom + " " + rec.nom).Equals(search.Text))) && (list1.ToArray()[x].poste.Equals((string)filtre.SelectedItem)))
                        {
                            trv = true;
                            var card = new Card2();
                            card.Margin = new Thickness(10, 10, 10, 10);
                            card.matricule.Text = rec.matricule.ToString();
                            card.nom.Text = rec.nom;
                            card.prenom.Text = rec.prenom;
                            card.adrmail.Text = rec.Adr_mail;
                            card.Poste.Text = list1.ToArray()[x].poste;
                            card.Projet.Text = list1.ToArray()[x].projet;
                            panel.Children.Add(card);
                            retour.IsEnabled = true;
                            recherche.IsEnabled = false;
                            filtre.IsEnabled = false;
                            search.IsEnabled = false;
                        }

                    }
                    else if (!search.Text.Equals("") && (filtre.SelectedIndex) == -1)
                    {

                        if (((rec.nom.Equals(search.Text)) || ((rec.nom + " ").Equals(search.Text)) || rec.prenom.Equals(search.Text) || ((rec.prenom + " ").Equals(search.Text)) || ((rec.nom + " " + rec.prenom).Equals(search.Text)) || ((rec.prenom + " " + rec.nom).Equals(search.Text))))
                        {
                            trv = true;
                            var card = new Card2();
                            card.Margin = new Thickness(10, 10, 10, 10);
                            card.matricule.Text = rec.matricule.ToString();
                            card.nom.Text = rec.nom;
                            card.prenom.Text = rec.prenom;
                            card.adrmail.Text = rec.Adr_mail;
                            card.Poste.Text = list1.ToArray()[x].poste;
                            card.Projet.Text = list1.ToArray()[x].projet;
                            panel.Children.Add(card);
                            retour.IsEnabled = true;
                            recherche.IsEnabled = false;
                            filtre.IsEnabled = false;
                            search.IsEnabled = false;
                        }


                    }
                    else if (search.Text.Equals("") && (filtre.SelectedIndex) >= 0)

                    {

                        if ((list1.ToArray()[x].poste.Equals((string)filtre.SelectedItem)))
                        {
                            trv = true;
                            var card = new Card2();
                            card.Margin = new Thickness(10, 10, 10, 10);
                            card.matricule.Text = rec.matricule.ToString();
                            card.nom.Text = rec.nom;
                            card.prenom.Text = rec.prenom;
                            card.adrmail.Text = rec.Adr_mail;
                            card.Poste.Text = list1.ToArray()[x].poste;
                            card.Projet.Text = list1.ToArray()[x].projet;
                            panel.Children.Add(card);
                            retour.IsEnabled = true;
                            recherche.IsEnabled = false;
                            filtre.IsEnabled = false;
                            search.IsEnabled = false;

                        }


                    }

                    x++;

                }
                if (!trv)
                {
                    alert.IsOpen = true;
                    search.Text = "";
                    filtre.SelectedIndex = -1;


                }
            }

        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            panel.Children.Clear();
            filtre.SelectedIndex = -1;
            search.Text = "";
            retour.IsEnabled = false;
            recherche.IsEnabled = true;
            filtre.IsEnabled = true;
            search.IsEnabled = true;
        }
        // Progress bar
        private void nontrouvé_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

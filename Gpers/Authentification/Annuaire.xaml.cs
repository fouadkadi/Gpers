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
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour Window4.xaml
    /// </summary>
    public partial class Annuaire : Window
    {
        private List<UserControl2> list2 = new List<UserControl2>();
        private List<UserControl2> list3 = new List<UserControl2>();
        private List<UserControl2> list4 = new List<UserControl2>();
        private HashSet<string> list7 = new HashSet<string>();
        private Boolean t = true;
        private Boolean t2 = true;
        private int x = 0;


        static string connectString = $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = { System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf; Integrated Security = True; Connect Timeout = 30";
        DataClasses1DataContext db = new DataClasses1DataContext(connectString);
        public Annuaire()
        {
            InitializeComponent();
            IQueryable<info_comp> poste = from rec in db.info_comp
                                          select rec;
            foreach (info_comp rec in poste)
            {
                list7.Add(rec.poste);
            }

            filtre.ItemsSource = list7;
            charger();

        }


        private void charger()
        {

            filtre.IsEnabled = true;

            if (t)
            {

                IQueryable<Employee> list = from rec in db.Employee
                                            select rec;
                IQueryable<info_comp> list5 = from rec2 in db.info_comp
                                              select rec2;
                foreach (Employee rec in list)
                {

                    var card = new UserControl2();



                    card.Margin = new Thickness(10, 10, 10, 10);
                    card.nom.Text = rec.nom;

                    card.prenom.Text = rec.prenom;
                    card.num.Text = "0" + rec.Num_tel.ToString();
                    card.adrmail.Text = rec.Adr_mail;
                    foreach (info_comp rec2 in list5)
                    {
                        if (rec2.matricule == rec.matricule)
                        {
                            card.Poste.Text = rec2.poste;
                            card.Projet.Text = rec2.projet;
                        }
                    }
                    list2.Add(card);

                    panel.Children.Add(card);

                }
                t = false;
            }


        }

        private void searchbutton_Click(object sender, RoutedEventArgs e)
        {


            Boolean trv = false;


            if (!search.Text.Equals(""))
            {
                bar.Visibility = Visibility.Visible;
                bar.Value = 0;

                foreach (UserControl2 crd in list2)
                {

                    bar.Value += 10;
                    if (crd.nom.Text.Equals(search.Text) || ((crd.nom.Text) + " " + crd.prenom.Text).Equals(search.Text) || ((crd.nom.Text) + " ").Equals(search.Text) || crd.num.Text.ToString().Equals(search.Text) || ((crd.num.Text) + " ").ToString().Equals(search.Text) || crd.adrmail.Text.Equals(search.Text) || ((crd.adrmail.Text) + " ").Equals(search.Text) || crd.prenom.Text.Equals(search.Text) || ((crd.prenom.Text) + " ").Equals(search.Text) || ((crd.prenom.Text) + " " + crd.nom.Text).Equals(search.Text))
                    {

                        trv = true;
                        list3.Add(crd);

                    }


                }
                if (trv)
                {
                    filtre.IsEnabled = false;
                    filtret.IsEnabled = false;
                    bar.Value = 100;
                    System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();
                    time.Interval = 2000;
                    time.Enabled = true;
                    time.Tick += new EventHandler(time_Tick);



                    foreach (UserControl2 crd2 in list3)
                    {
                        panel.Children.Clear();
                        panel.Children.Add(crd2);
                    }
                    retour.IsEnabled = true;


                }
                else
                {
                    bar.Value = 100;


                    alert.IsOpen = true;


                }

            }


        }



        private void time_Tick(object sender, EventArgs e)
        {
            bar.Visibility = Visibility.Hidden;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            filtre.IsEnabled = true;
            filtret.IsEnabled = true;
            filtre.SelectedIndex = -1;

            panel.Children.Clear();
            IQueryable<Employee> list = from rec in db.Employee
                                        select rec;
            IQueryable<info_comp> list5 = from rec2 in db.info_comp
                                          select rec2;
            foreach (Employee rec in list)
            {
                var card = new UserControl2();



                card.Margin = new Thickness(10, 10, 10, 10);
                card.nom.Text = rec.nom;

                card.prenom.Text = rec.prenom;
                card.num.Text = "0" + rec.Num_tel.ToString();
                card.adrmail.Text = rec.Adr_mail;
                foreach (info_comp rec2 in list5)
                {
                    if (rec2.matricule == rec.matricule)
                    {
                        card.Poste.Text = rec2.poste;
                        card.Projet.Text = rec2.projet;
                    }
                }
                list2.Add(card);

                panel.Children.Add(card);
            }


            retour.IsEnabled = false;
            search.Text = "";

        }

        private void filtre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            retour.IsEnabled = true;
            string pst = "";
            string prj = "";

            if (filtre.SelectedIndex >= 0)

            {
                Boolean trv3 = false;

                IQueryable<Employee> list = from rec in db.Employee
                                            select rec;
                IQueryable<info_comp> list5 = from rec2 in db.info_comp
                                              select rec2;
                string selectedcmb = (string)filtre.SelectedItem;

                panel.Children.Clear();

                foreach (Employee crd3 in list)
                {

                    foreach (info_comp rec2 in list5)
                    {
                        if (rec2.matricule == crd3.matricule)
                        {
                            pst = rec2.poste;
                            prj = rec2.projet;
                        }
                    }

                    if (pst.Equals(selectedcmb))
                    {
                        trv3 = true;
                        var card = new UserControl2();



                        card.Margin = new Thickness(10, 10, 10, 10);
                        card.nom.Text = crd3.nom;
                        card.prenom.Text = crd3.prenom;
                        card.num.Text = "0" + crd3.Num_tel.ToString();
                        card.adrmail.Text = crd3.Adr_mail;
                        card.Poste.Text = pst;
                        card.Projet.Text = prj;

                        panel.Children.Add(card);
                    }
                }
                if (trv3 == false)
                {
                    alert2.IsOpen = true;
                    foreach (Employee rec in list)
                    {
                        var card = new UserControl2();
                        card.Margin = new Thickness(10, 10, 10, 10);
                        card.nom.Text = rec.nom;
                        card.prenom.Text = rec.prenom;
                        card.num.Text = "0" + rec.Num_tel.ToString();
                        card.adrmail.Text = rec.Adr_mail;
                        foreach (info_comp rec2 in list5)
                        {
                            if (rec2.matricule == rec.matricule)
                            {
                                card.Poste.Text = rec2.poste;
                                card.Projet.Text = rec2.projet;
                            }
                        }
                        panel.Children.Add(card);

                    }

                }
            }
        }

        private void nontrouvé_Click(object sender, RoutedEventArgs e)
        {
            bar.Visibility = Visibility.Hidden;

        }
    }

}
using Microsoft.Win32;
using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour modif_employée.xaml
    /// </summary>
    public partial class modif_employée : Window
    {
        static String connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
        DataClasses1DataContext db = new DataClasses1DataContext(connectString);
        List<Employee> empliste;
        List<info_comp> compliste;

        public modif_employée()
        {


            InitializeComponent();
            empliste = (from recup in db.Employee select recup).ToList();
            compliste= (from recup in db.info_comp select recup).ToList();
            choixemployée.ItemsSource = tostring(empliste);


        }

        public List<string> tostring(List<Employee> l)
        {
            List<string> result = new List<string>();

            foreach(Employee e in l)
            {
                result.Add(e.nom + " " + e.prenom + " " + e.matricule);

            }

            return result;
        }


        //========================= validation du choix de l'employée ==================================//
        string ancien_salaire;
        private void valid_Click(object sender, RoutedEventArgs e)
        {
            if (choixemployée.SelectedIndex != -1)
            {
                
                Nom.Text = empliste.ToArray()[choixemployée.SelectedIndex].nom;
                Prenom.Text = empliste.ToArray()[choixemployée.SelectedIndex].prenom;
                Adresse.Text = empliste.ToArray()[choixemployée.SelectedIndex].Adresse;
                Email.Text = empliste.ToArray()[choixemployée.SelectedIndex].Adr_mail;
                Telephone.Text= empliste.ToArray()[choixemployée.SelectedIndex].Num_tel.ToString();
                Coordonnes_bancaires.Text= empliste.ToArray()[choixemployée.SelectedIndex].Cor_bnc;
                Date_naissance.SelectedDate = empliste.ToArray()[choixemployée.SelectedIndex].Date_de_ness;
                Poste_occupee.Text= compliste.ToArray()[choixemployée.SelectedIndex].poste;
                
                
                Responsable_hiearchique.Text= compliste.ToArray()[choixemployée.SelectedIndex].respo;
                Salaire.Text = compliste.ToArray()[choixemployée.SelectedIndex].salaire.ToString();                
                Projet.Text= compliste.ToArray()[choixemployée.SelectedIndex].projet ;
                numero_immatriculation_sociale.Text= compliste.ToArray()[choixemployée.SelectedIndex].NIS;
                sex.SelectedIndex = getsex( compliste.ToArray()[choixemployée.SelectedIndex].sex);
                Situationfamiliale.SelectedIndex= getsitu( compliste.ToArray()[choixemployée.SelectedIndex].situ_fam);
                Statut.SelectedIndex=getstat( compliste.ToArray()[choixemployée.SelectedIndex].statut);
                Date_embauche.SelectedDate = compliste.ToArray()[choixemployée.SelectedIndex].Date_emb;
                Date_demission.SelectedDate = compliste.ToArray()[choixemployée.SelectedIndex].Date_dem;
                nbr_conge_restants.Text= compliste.ToArray()[choixemployée.SelectedIndex].Nbj_r_c.ToString();
                Commentaire.Text = compliste.ToArray()[choixemployée.SelectedIndex].comment;

                edit.IsEnabled = true;

                Date_demission.IsEnabled = false;
                nbr_conge_restants.IsEnabled = false;
                numero_immatriculation_sociale.IsEnabled = false;

                ancien_salaire= compliste.ToArray()[choixemployée.SelectedIndex].salaire.ToString();



            }
            else { alert_text.Text = "selectioner un employée";
                alert.IsOpen = true;
            }
        }




        /**============================LES VARIABLES GLOBALES================================**/


        DateTime today = DateTime.Today;
        /**==============================Valider : Permet d'ajouter un employé à la base de données===================**/
        private void Valider(object sender, RoutedEventArgs e)
        {

           

            info_comp comp = compliste.ToArray()[choixemployée.SelectedIndex];

            Employee membre = empliste.ToArray()[choixemployée.SelectedIndex];
            DateTime date1 = new DateTime();
            

            if (Date_naissance.SelectedDate != null)
            {
                date1 = DateTime.ParseExact(Date_naissance.Text, "d", null);
            }

            DateTime date2 = new DateTime();
            if (Date_embauche.SelectedDate != null)
            {
               date2= DateTime.ParseExact(Date_embauche.Text, "d", null);
            }
            DateTime date3 = new DateTime();
            if (Date_demission.SelectedDate != null)
            { date3 = DateTime.ParseExact(Date_demission.Text, "d", null); }


            if (Nom.Text != "" &&  Prenom.Text != "" && Adresse.Text != "" && Telephone.Text != "" && Email.Text != "" && Coordonnes_bancaires.Text != "" && Date_naissance.Text != "" && Poste_occupee.Text != "" && Responsable_hiearchique.Text != "" && Salaire.Text != "" && Projet.Text != "" && Situationfamiliale.Text != "" && Statut.Text != "" && Date_embauche.Text != "" && validerdatenaissance(date1) && validerdateembauche(date2) && validerdatedemission(date3))
            {
                int val1 = Convert.ToInt32(Telephone.Text.Trim());
                Decimal val2 = Convert.ToDecimal(Salaire.Text);
                membre.nom = Nom.Text;
                membre.prenom = Prenom.Text;
                membre.Adresse = Adresse.Text;
                membre.Num_tel = val1;
                membre.Adr_mail = Email.Text;
                membre.Cor_bnc = Coordonnes_bancaires.Text;
                membre.Date_de_ness = date1;
                comp.poste = Poste_occupee.Text;
                comp.respo = Responsable_hiearchique.Text;
                comp.salaire = val2;
                comp.Date_emb = date2;
                comp.sex = sex.Text;
                comp.projet = Projet.Text;
                comp.NIS = numero_immatriculation_sociale.Text;
                comp.situ_fam = Situationfamiliale.Text;
                comp.statut = Statut.Text;
                if (nbr_conge_restants.Text != "")
                {
                    int val3 = Convert.ToInt32(nbr_conge_restants.Text.Trim());
                    comp.Nbj_r_c = val3;
                }
                comp.comment = Commentaire.Text;
                if (Date_demission.Text != "")
                { comp.Date_dem = date3; }

                if (Salaire.Text != ancien_salaire && Salaire.Text!="")
                {
                    Salaire sal = new Salaire();
                    sal.matricule = membre.matricule;
                    sal.ancien_ = (long) Convert.ToUInt64(ancien_salaire);
                    sal.nouveau= (long)Convert.ToUInt64(Salaire.Text);
                    sal.date_modif = DateTime.Today;
                    db.Salaire.InsertOnSubmit(sal);
                    
                }

                
                db.SubmitChanges();
                alert_text.Text = "information bien modifier";
                alert.IsOpen = true;
            }

            else
            {
                if (validerdatenaissance(date1) == false) { alert_text.Text = "Verifiez date de naissance"; }
                else alert_text.Text = "fiche incomplète";
                alert.IsOpen = true;
            }
        }


        /**==============================Permet de controler et de valider la saisie===========================**/

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)  //Pour autoriser que les chiffres
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }
        private void SalaryValidationTextBox(object sender, TextCompositionEventArgs e) //Pour autoriser que les avleur decimales
        {
            Regex regex = new Regex("[^0-9 ,.]+");
            e.Handled = regex.IsMatch(e.Text);

        }
        private void coordValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9 a-z A-Z -_.]+");
            e.Handled = regex.IsMatch(e.Text);

        }


        private void textvalidationTextBox(object sender, TextCompositionEventArgs e) //Pour autoriser que les chaines de caractères
        {
            Regex regex = new Regex("[^a-z A-Z éèàçùêïîôâ]+");
            e.Handled = regex.IsMatch(e.Text);

        }


        


        /**=========================Verifier les dates saisies====================================**/
        private Boolean validerdatenaissance(DateTime date)
        {



            var age = today.Year - date.Year;
            if (age >= 18 && age <= 100)
            { return true; }
            else return false;
            
        }

        private Boolean validerdateembauche(DateTime date)
        {


            if (date > today) return false;
            else return true;
        }

        private Boolean validerdatedemission(DateTime date)
        {

            if (date != null)
            {
                if (date > today) return false;
                else return true;
            }
            else return true;
        }

        //================================= Control de recherche =======================================//

        List<string> wilayas = new List<string> { "1- Adrar", "2- Chlef","3- Laghouat","4- Oum El Bouaghi", "5- Batna","6- Bejaia",
                                "7- Biskra",
                                "8- Bechar",
                                "9- Blida",
                                "10- Bouira",
                                "11- Tamanrassat",
                                "12- Tébessa",
                                "13- Tlemcen",
                                "14- Tiaret",
                                "15- Tizi Ouzou",
                                "16- Alger",
                                "17- Djelfa",
                                "18- Jijel",
                                "19- Sétif",
                                "20- Saida",
                                "21- Skikda",
                                "22- Sidi Bel Abbès",
                                "23- Annaba",
                                "24- Guelma",
                                "25- Constantine",
                                "26- Médéa",
                                "27- Mostaganem",
                                "28- M'Sila",
                                "29- Mascara",
                                "30- Ouargla",
                                "31- Oran",
                                "32- El Bayadh",
                                "33- Illizi",
                                "34- Bordj Bou Arreridj",
                                "35- Boumerdès",
                                "36- El Tarf",
                                "37- Tindouf",
                                "38- Tissemsilt",
                                "39- El oued",
                                "40- Khenchela",
                                "41- Souk Ahras",
                                "42- Tipaza",                                "43- Mila",                                "44- Ain Defla",
                                "45- Naama",                                "46- Ain Témouchent",                               "47- Ghardaia",                               "48- Relizane" };
        int getwilay(string e)
        {
            return wilayas.IndexOf(e);

        }

        List<string> sexes = new List<string> { "Homme", "Femme" };
        List<string> situ_fam = new List<string> { "Célibataire", "Marié" };
        List<string> stat = new List<string> { "Actif", "Désactivé", "Retraite" };
        int getsex(string e)
        {
            return sexes.IndexOf(e);

        }
        int getsitu(string e)
        {
            return situ_fam.IndexOf(e);

        }
        int getstat(string e)
        {
            return stat.IndexOf(e);

        }



    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour Génération_document.xaml
    /// </summary>
    public partial class Génération_document : Window
    {// Pour se connecter à la BDD
        static String connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
        DataClasses1DataContext db = new DataClasses1DataContext(connectString);
        List<Employee> empliste;
        List<info_comp> compliste;
        info_entreprise info;
        static DateTime today = DateTime.Today;
        string DateNaissance;
        string DateEmbauche;
        string DateDemission;
        string Today = Convert.ToString(today.Date.Day + "/" + today.Date.Month + "/" + today.Date.Year);



        public Génération_document()
        {
            InitializeComponent();
            empliste = (from recup in db.Employee select recup).ToList();
            compliste = (from recup in db.info_comp select recup).ToList();
            employé.ItemsSource = tostring(empliste);
            droper.IsEnabled = false;
            info = (from recup in db.info_entreprise select recup).FirstOrDefault();
            
        }

        public List<string> tostring(List<Employee> l)
        {
            List<string> result = new List<string>();

            foreach (Employee e in l)
            {
                result.Add(e.nom + " " + e.prenom + " " + e.matricule);

            }

            return result;
        }









        //==================================   RECHERCHE ====================================================================//








        private void Recherche_Click(object sender, RoutedEventArgs e)
        {
            if (employé.SelectedIndex != -1)
            {
                droper.IsEnabled = true;
                droper.IsExpanded = true;

            }
            else { alert_text.Text = "selectioner l'employé";alert.IsOpen = true; }

        }




        //========================================== Methode pour la génération =========================================//
        /**=============================  LES METHODES DE GENERTATION DES DIFFERENTS DOCUMENTS   =============================**/

        public static void contratTravail(string raison, string spécialité, string wilaya, string Rc, string matricule_fiscal, string matricule, string nom, string prenom, string date_naissance, string wilaya_naissance, string adresse, string date_embauche, string poste, string salaire, string gérant, string chemin, string chemin1)
        {
            Microsoft.Office.Interop.Word.Application _ApplicationWord = new Microsoft.Office.Interop.Word.Application();
            _ApplicationWord.Visible = false;
            string path = chemin1 + "\\Modeles\\REF-CONTRAT DE TRAVAIL .docx";
            object oFileName = (object)@path;
            object Faux = (object)false;
            object Vrai = (object)true;
            object M = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Word._Document _MonDocument = _ApplicationWord.Documents.Add(ref oFileName, ref Faux, ref M, ref Vrai);

            object Nom = (object)"adresse";
            object Nom1 = (object)"DateEmbauche";
            object Nom2 = (object)"DateEmbauche1";
            object Nom3 = (object)"DateNaissance";
            object Nom4 = (object)"gérant";
            object Nom5 = (object)"matricule";
            object Nom6 = (object)"NomPrénom";
            object Nom7 = (object)"poste";
            object Nom8 = (object)"raison";
            object Nom9 = (object)"raison1";
            object Nom10 = (object)"raison2";
            object Nom11 = (object)"raison3";
            object Nom12 = (object)"raison4";
            object Nom13 = (object)"raison5";
            object Nom14 = (object)"raison6";
            object Nom15 = (object)"raison7";
            object Nom16 = (object)"RcMatriculeFiscal";
            object Nom17 = (object)"salaire";
            object Nom18 = (object)"salaire1";
            object Nom19 = (object)"spécialité";
            object Nom20 = (object)"wilaya";
            object Nom21 = (object)"WilayaNaissance";
            object Nom22 = (object)"logo";

            Microsoft.Office.Interop.Word.Bookmark _MonSignet;
            Microsoft.Office.Interop.Word.Range _MonRange;
            Microsoft.Office.Interop.Word.InlineShape _MonImage;



            //récupére la liste de signets
            Microsoft.Office.Interop.Word.Bookmarks _MesSignets = _MonDocument.Bookmarks;


            if (_MesSignets.Exists("adresse"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(adresse);
            }
            if (_MesSignets.Exists("DateEmbauche"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom1);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(date_embauche);
            }
            if (_MesSignets.Exists("DateEmbauche1"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom2);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(date_embauche);
            }
            if (_MesSignets.Exists("DateNaissance"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom3);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(date_naissance);
            }
            if (_MesSignets.Exists("gérant"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom4);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(gérant);
            }
            if (_MesSignets.Exists("matricule"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom5);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(matricule);
            }
            if (_MesSignets.Exists("NomPrénom"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom6);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(" " + nom + " " + prenom + " ");
            }
            if (_MesSignets.Exists("poste"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom7);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(poste);
            }
            if (_MesSignets.Exists("raison"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom8);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("raison1"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom9);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("raison2"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom10);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("raison3"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom11);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("raison4"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom12);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("raison5"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom13);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("raison6"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom14);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("raison7"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom15);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("RcMatriculeFiscal"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom16);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(Rc + "/" + matricule_fiscal);
            }
            if (_MesSignets.Exists("salaire"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom17);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                double sal = (Convert.ToDouble(salaire)) * 12;
                _MonRange.InsertAfter(Convert.ToString(sal));
            }
            if (_MesSignets.Exists("salaire1"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom18);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(salaire);
            }
            if (_MesSignets.Exists("spécialité"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom19);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(spécialité);
            }
            if (_MesSignets.Exists("wilaya"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom20);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(wilaya);
            }
            if (_MesSignets.Exists("WilayaNaissance"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom21);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(wilaya_naissance);
            }
            if (_MesSignets.Exists("logo"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom22);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonImage = _MonRange.InlineShapes.AddPicture(@chemin1 + "\\logo.png", ref Faux, ref Vrai, ref M);
            }



            oFileName = @chemin;
            try
            {
                _MonDocument.SaveAs(ref oFileName, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M);
            }
            catch (Exception e) { }
            _MonDocument.Close(ref M, ref M, ref M);
            _ApplicationWord.Application.Quit(ref M, ref M, ref M);
        }
        public static void titreCongé(string raison, string spécialité, string wilaya, string RC, string matricule_fiscal, string date, string gérant, string employé, string poste, string début, string fin, string chemin, string chemin1)
        {

            Microsoft.Office.Interop.Word.Application _ApplicationWord = new Microsoft.Office.Interop.Word.Application();
            _ApplicationWord.Visible = false;
            string path = chemin1 + "\\Modeles\\REF-TITRE DE CONGES.docx";
            object oFileName = (object)@path;
            object Faux = (object)false;
            object Vrai = (object)true;
            object M = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Word._Document _MonDocument = _ApplicationWord.Documents.Add(ref oFileName, ref Faux, ref M, ref Vrai);

            object Nom = (object)"Logo";
            object Nom1 = (object)"Raison";
            object Nom2 = (object)"Spécialité";
            object Nom3 = (object)"Adresse";
            object Nom4 = (object)"Rc_MatriculeFiscal";
            object Nom5 = (object)"Gérant";
            object Nom6 = (object)"Raison1";
            object Nom7 = (object)"Employé";
            object Nom8 = (object)"Poste";
            object Nom9 = (object)"Date1";
            object Nom10 = (object)"Date2";
            object Nom11 = (object)"Gérant1";
            object Nom12 = (object)"Raison2";
            object Nom13 = (object)"nbr_jours";
            object Nom14 = (object)"Début";
            object Nom15 = (object)"Fin";
            object Nom16 = (object)"Fin1";



            Microsoft.Office.Interop.Word.Bookmark _MonSignet;
            Microsoft.Office.Interop.Word.Range _MonRange;
            Microsoft.Office.Interop.Word.InlineShape _MonImage;



            //récupére la liste de signets
            Microsoft.Office.Interop.Word.Bookmarks _MesSignets = _MonDocument.Bookmarks;

            if (_MesSignets.Exists("Logo"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonImage = _MonRange.InlineShapes.AddPicture(@chemin1 + "\\logo.png", ref Faux, ref Vrai, ref M);
            }
            if (_MesSignets.Exists("Raison"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom1);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("Spécialité"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom2);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(spécialité);
            }
            if (_MesSignets.Exists("Adresse"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom3);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(wilaya + "/Algérie ");
            }
            if (_MesSignets.Exists("Rc_MatriculeFiscal"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom4);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(RC + "/" + matricule_fiscal);
            }
            if (_MesSignets.Exists("Gérant"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom5);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(gérant);
            }
            if (_MesSignets.Exists("Raison1"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom6);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("Employé"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom7);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(employé);
            }
            if (_MesSignets.Exists("Poste"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom8);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(poste);
            }
            if (_MesSignets.Exists("Date1"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom9);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(date);
            }
            if (_MesSignets.Exists("Date2"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom10);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter("le " + date);
            }
            if (_MesSignets.Exists("Gérant1"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom11);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(gérant);
            }
            if (_MesSignets.Exists("Raison2"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom12);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("nbr_jours"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom13);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                DateTime debut = Convert.ToDateTime(début);
                DateTime end = Convert.ToDateTime(fin);
                TimeSpan difference = end.Date - debut.Date;
                string nbj = Convert.ToString(difference.Days);
                _MonRange.InsertAfter(nbj + " ");
            }
            if (_MesSignets.Exists("Début"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom14);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(" " + début + " ");
            }
            if (_MesSignets.Exists("Fin"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom15);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(" " + fin + " ");
            }
            if (_MesSignets.Exists("Fin1"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom16);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(" " + fin);
            }

            oFileName = @chemin;
            _MonDocument.SaveAs(ref oFileName, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M);

            _MonDocument.Close(ref M, ref M, ref M);
            _ApplicationWord.Application.Quit(ref M, ref M, ref M);
        }
        public static void certificatTravail(string raison, string spécialité, string wilaya, string Rc, string matricule_fiscal, string date, string gérant, string employé, string date_embauche, string date_emission, string poste, string chemin, string chemin1)
        {

            Microsoft.Office.Interop.Word.Application _ApplicationWord = new Microsoft.Office.Interop.Word.Application();
            _ApplicationWord.Visible = false;

            // chemin vers le modéle word qu'on doit remplir ... 
            string path = chemin1 + "\\Modeles\\REF-CERTIFICAT DE TRAVAIL.docx";
            object oFileName = (object)@path;
            object Faux = (object)false;
            object Vrai = (object)true;
            object M = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Word._Document _MonDocument = _ApplicationWord.Documents.Add(ref oFileName, ref Faux, ref M, ref Vrai);

            object Nom = (object)"Date";
            object Nom1 = (object)"date1";
            object Nom2 = (object)"DateEmbauche";
            object Nom3 = (object)"DateEmission";
            object Nom4 = (object)"employé";
            object Nom5 = (object)"employé1";
            object Nom6 = (object)"gérant";
            object Nom7 = (object)"logo";
            object Nom8 = (object)"poste";
            object Nom9 = (object)"raison";
            object Nom10 = (object)"raison1";
            object Nom11 = (object)"raison2";
            object Nom12 = (object)"RcMatriculeFiscal";
            object Nom13 = (object)"spécialité";
            object Nom14 = (object)"wilaya";

            Microsoft.Office.Interop.Word.Bookmark _MonSignet;
            Microsoft.Office.Interop.Word.Range _MonRange;
            Microsoft.Office.Interop.Word.InlineShape _MonImage;



            //récupére la liste de signets
            Microsoft.Office.Interop.Word.Bookmarks _MesSignets = _MonDocument.Bookmarks;

            if (_MesSignets.Exists("Date"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(date + " ");
            }
            if (_MesSignets.Exists("date1"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom1);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(" " + date + " ");
            }
            if (_MesSignets.Exists("DateEmbauche"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom2);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(date_embauche + " ");
            }
            if (_MesSignets.Exists("DateEmission"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom3);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(date_emission + " ");
            }
            if (_MesSignets.Exists("employé"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom4);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(employé + " ");
            }
            if (_MesSignets.Exists("employé1"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom5);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(employé + " ");
            }
            if (_MesSignets.Exists("gérant"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom6);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(gérant + " ");
            }
            if (_MesSignets.Exists("logo"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom7);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonImage = _MonRange.InlineShapes.AddPicture(@chemin1 + "\\logo.png", ref Faux, ref Vrai, ref M);
            }
            if (_MesSignets.Exists("poste"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom8);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(" " + poste + " ");
            }
            if (_MesSignets.Exists("raison"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom9);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison + " ");
            }
            if (_MesSignets.Exists("raison1"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom10);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison + " ");
            }
            if (_MesSignets.Exists("raison2"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom11);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison + " ");
            }
            if (_MesSignets.Exists("RcMatriculeFiscal"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom12);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(Rc + "/" + matricule_fiscal + " ");
            }
            if (_MesSignets.Exists("spécialité"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom13);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(spécialité + " ");
            }
            if (_MesSignets.Exists("wilaya"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom14);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(wilaya + "- Algérie");
            }


            // le fichier généré et son chemin .... 
            oFileName = @chemin;
            _MonDocument.SaveAs(ref oFileName, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M);

            _MonDocument.Close(ref M, ref M, ref M);
            _ApplicationWord.Application.Quit(ref M, ref M, ref M);
        }
        public static void attestation(string raison, string spécialité, string image, string wilaya, string Rc, string matricule_fiscal, string date, string gérant, string employé, string date_naissance, string date_embauche, string poste, string chemin, string chemin1)
        {
            Microsoft.Office.Interop.Word.Application _ApplicationWord = new Microsoft.Office.Interop.Word.Application();
            _ApplicationWord.Visible = false;
            string path = chemin1 + "\\Modeles\\REF-ATTESTATION DE TRAVAIL.docx";
            object oFileName = (object)@path;
            object Faux = (object)false;
            object Vrai = (object)true;
            object M = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Word._Document _MonDocument = _ApplicationWord.Documents.Add(ref oFileName, ref Faux, ref M, ref Vrai);

            object Nom = (object)"date";
            object Nom1 = (object)"date1";
            object Nom2 = (object)"dateEmbauche";
            object Nom3 = (object)"dateNaissance";
            object Nom4 = (object)"employé";
            object Nom5 = (object)"gérant";
            object Nom6 = (object)"gérant1";
            object Nom7 = (object)"RcMatriculeFiscal";
            object Nom8 = (object)"poste";
            object Nom9 = (object)"raison";
            object Nom10 = (object)"raison1";
            object Nom11 = (object)"raison2";
            object Nom13 = (object)"spécialité";
            object Nom14 = (object)"wilaya";
            object Nom15 = (object)"wilaya1";
            object Nom16 = (object)"logo";




            Microsoft.Office.Interop.Word.Bookmark _MonSignet;
            Microsoft.Office.Interop.Word.Range _MonRange;
            Microsoft.Office.Interop.Word.InlineShape _MonImage;

            //récupére la liste de signets
            Microsoft.Office.Interop.Word.Bookmarks _MesSignets = _MonDocument.Bookmarks;

            //si le signet cherché existe
            if (_MesSignets.Exists("date"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(date);
            }
            if (_MesSignets.Exists("date1"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom1);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(date);
            }
            if (_MesSignets.Exists("dateEmbauche"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom2);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(date_embauche);
            }
            if (_MesSignets.Exists("dateNaissance"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom3);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(date_naissance);
            }
            if (_MesSignets.Exists("employé"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom4);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(employé);
            }
            if (_MesSignets.Exists("gérant"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom5);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(gérant);
            }
            if (_MesSignets.Exists("gérant1"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom6);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(gérant);
            }
            if (_MesSignets.Exists("RcMatriculeFiscal"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom7);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(Rc + "/" + matricule_fiscal);
            }
            if (_MesSignets.Exists("poste"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom8);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(poste);
            }
            if (_MesSignets.Exists("raison"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom9);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("raison1"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom10);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("raison2"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom11);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(raison);
            }
            if (_MesSignets.Exists("spécialité"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom13);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(spécialité);
            }
            if (_MesSignets.Exists("wilaya"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom14);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(wilaya);
            }
            if (_MesSignets.Exists("wilaya1"))
            {
                //on positionne le range sur le signet et la fonction retourne true
                _MonSignet = _MesSignets.get_Item(ref Nom15);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonRange.InsertAfter(wilaya);
            }
            if (_MesSignets.Exists("logo"))
            {
                _MonSignet = _MesSignets.get_Item(ref Nom16);
                _MonSignet.Select();
                _MonRange = _MonSignet.Range;
                _MonRange.Delete(ref M, 1);
                _MonImage = _MonRange.InlineShapes.AddPicture(image + "\\logo.png", ref Faux, ref Vrai, ref M); //le chemin d'accès au logo image+ "\\Logo\\Logo.png"

            }
            

            oFileName = @chemin;
            _MonDocument.SaveAs(ref oFileName, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M, ref M);

            _MonDocument.Close(ref M, ref M, ref M);
            _ApplicationWord.Application.Quit(ref M, ref M, ref M);

        }



        //============================================= methode de click =======================================================//
        private void Attestation_travaille(object sender, RoutedEventArgs e)
        {
            SaveFileDialog //ouvre une fentre pour que l'utilisateur choisit l'emplacement de l'attestation
            op = new SaveFileDialog();
            Employee membre = empliste.ToArray()[employé.SelectedIndex];
            info_comp membreComp = compliste.ToArray()[employé.SelectedIndex];
            op.Title = "Selectionner L'emplacement du fichier";
            op.Filter = "fichier word (*.docx)|*.docx";
            op.FileName = membre.nom + membre.prenom + "_" + Convert.ToString(today.Date.Day + "_" + today.Date.Month + "_" + today.Date.Year) + "attestation de travail";
            // la conversion de DateTime en String
            DateTime datenaiss = Convert.ToDateTime(membre.Date_de_ness);
            DateNaissance = Convert.ToString(datenaiss.Date.Day + "/" + datenaiss.Date.Month + "/" + datenaiss.Date.Year);
            DateTime dateemb = Convert.ToDateTime(membreComp.Date_emb);
            DateEmbauche = Convert.ToString(dateemb.Date.Day + "/" + dateemb.Date.Month + "/" + dateemb.Date.Year);
            DateTime datedem = Convert.ToDateTime(membreComp.Date_dem);
            DateDemission = Convert.ToString(datedem.Date.Day + "/" + datedem.Date.Month + "/" + datedem.Date.Year);
            String chemin1 = Directory.GetCurrentDirectory();
            String chemin2 = Convert.ToString(Directory.GetParent(chemin1));
            String chemin3 = Convert.ToString(Directory.GetParent(chemin2));
            String chemin4 = Convert.ToString(Directory.GetParent(chemin3));
           
           
            if (membreComp.statut == "Actif")
            {
                if (info != null) { 
                op.ShowDialog();
                attestation(" " + info.Raison_so, " " + info.Spécialité, @chemin1, membre.wilaya_naiss, Convert.ToString(info.Numéro_RC), info.identifiant_fi, Today, info.Gérant + " ", " " + membre.nom + " " + membre.prenom, " " + DateNaissance, DateEmbauche + " ", membreComp.poste + " ", op.FileName, chemin1);
                alert_text.Text= "La génération a bien été faite";
                alert.IsOpen = true;
                droper.IsExpanded = false;
                droper.IsEnabled = false;
                }
                else { alert_text.Text = "il manque les informations de l'entreprise";alert.IsOpen = true; }
            }
            else
            { alert_text.Text="Vous ne pouvez pas générer une attestation de travail pour un(e) employé(e) désactivé(e) ou retraité(e)"; alert.IsOpen = true; }
        }

    

        private void Certificat_travail(object sender, RoutedEventArgs e)
        {
            SaveFileDialog //ouvre une fentre pour que l'utilisateur choisit l'emplacement de l'attestation
             op = new SaveFileDialog();
            Employee membre = empliste.ToArray()[employé.SelectedIndex];
            info_comp membreComp = compliste.ToArray()[employé.SelectedIndex];
            op.Title = "Selectionner L'emplacement du fichier";
            op.Filter = "fichier word (*.docx)|*.docx";
            op.FileName = membre.nom + membre.prenom + "_" + Convert.ToString(today.Date.Day + "_" + today.Date.Month + "_" + today.Date.Year) + "certificat de travail";
            // la conversion de DateTime en String
            DateTime datenaiss = Convert.ToDateTime(membre.Date_de_ness);
            DateNaissance = Convert.ToString(datenaiss.Date.Day + "/" + datenaiss.Date.Month + "/" + datenaiss.Date.Year);
            DateTime dateemb = Convert.ToDateTime(membreComp.Date_emb);
            DateEmbauche = Convert.ToString(dateemb.Date.Day + "/" + dateemb.Date.Month + "/" + dateemb.Date.Year);
            DateTime datedem = Convert.ToDateTime(membreComp.Date_dem);
            DateDemission = Convert.ToString(datedem.Date.Day + "/" + datedem.Date.Month + "/" + datedem.Date.Year);
            String chemin1 = Directory.GetCurrentDirectory();
            String chemin2 = Convert.ToString(Directory.GetParent(chemin1));
            String chemin3 = Convert.ToString(Directory.GetParent(chemin2));
            String chemin4 = Convert.ToString(Directory.GetParent(chemin3));
            if (membreComp.statut == "Désactivé"  || membreComp.Date_dem == null)
            {
                if (info != null) { 
                op.ShowDialog();
                certificatTravail(info.Raison_so, info.Spécialité, info.wilaya, Convert.ToString(info.Numéro_RC), info.identifiant_fi, Today, info.Gérant, " " + membre.nom + " " + membre.prenom, DateEmbauche, DateDemission, membreComp.poste, op.FileName, chemin1);
                alert_text.Text="La génération a bien été faite";alert.IsOpen = true;
                droper.IsExpanded = false;
                droper.IsEnabled = false;
               }
            else { alert_text.Text = "il manque les informations de l'entreprise"; alert.IsOpen = true; }
        }
            else
            {
                alert_text.Text="Vous ne pouvez pas générer un certificat de travail pour un(e) employé(e) qui n'a pas demissionné(e)"; alert.IsOpen = true;
            }


        }

        private void Titre_congé(object sender, RoutedEventArgs e)
        {
            SaveFileDialog //ouvre une fentre pour que l'utilisateur choisit l'emplacement de l'attestation
             op = new SaveFileDialog();
            Employee membre = empliste.ToArray()[employé.SelectedIndex];
            info_comp membreComp = compliste.ToArray()[employé.SelectedIndex];
            op.Title = "Selectionner L'emplacement du fichier";
            op.Filter = "fichier word (*.docx)|*.docx";
            op.FileName = membre.nom + membre.prenom + "_" + Convert.ToString(today.Date.Day + "_" + today.Date.Month + "_" + today.Date.Year) + "Titre de congé";
            // la conversion de DateTime en String
            DateTime datenaiss = Convert.ToDateTime(membre.Date_de_ness);
            DateNaissance = Convert.ToString(datenaiss.Date.Day + "/" + datenaiss.Date.Month + "/" + datenaiss.Date.Year);
            DateTime dateemb = Convert.ToDateTime(membreComp.Date_emb);
            DateEmbauche = Convert.ToString(dateemb.Date.Day + "/" + dateemb.Date.Month + "/" + dateemb.Date.Year);
            DateTime datedem = Convert.ToDateTime(membreComp.Date_dem);
            DateDemission = Convert.ToString(datedem.Date.Day + "/" + datedem.Date.Month + "/" + datedem.Date.Year);
            String chemin1 = Directory.GetCurrentDirectory();
            String chemin2 = Convert.ToString(Directory.GetParent(chemin1));
            String chemin3 = Convert.ToString(Directory.GetParent(chemin2));
            String chemin4 = Convert.ToString(Directory.GetParent(chemin3));
            IQueryable<congé2> list = from recup in db.congé2
                                     where recup.matricule == empliste.ToArray()[employé.SelectedIndex].matricule
                                     select recup;
            if (list.Count() == 0) { alert_text.Text="Il n'y a aucun congé attribué à cet(te) employé(e)"; alert.IsOpen = true; }
            else if (membreComp.statut != "Actif" ) { alert_text.Text= "Vous ne pouvez pas générer un titre de congé à un(e) employée désactivé(e) ou retraité(e)"; alert.IsOpen = true; }
            else
            {
                congé2 C = new Authentification.congé2();
                foreach (var info in list)
                {
                    C = info;
                }

                if (info!= null){ 
                DateTime Debut = Convert.ToDateTime(C.debut);
                string debut = Convert.ToString(Debut.Date.Day + "/" + Debut.Date.Month + "/" + Debut.Date.Year);
                DateTime Fin = Convert.ToDateTime(C.fin);
                string fin = Convert.ToString(Fin.Date.Day + "/" + Fin.Date.Month + "/" + Fin.Date.Year);
                op.ShowDialog();
                titreCongé(info.Raison_so, info.Spécialité, membre.wilaya_naiss, Convert.ToString(info.Numéro_RC), info.identifiant_fi, Today, info.Gérant, membre.nom + " " + membre.prenom, membreComp.poste, debut, fin, op.FileName, chemin1);
                alert_text.Text="La génération a bien été faite";alert.IsOpen = true;
                droper.IsExpanded = false;
                droper.IsEnabled = false;
                }
                else { alert_text.Text = "il manque les informations de l'entreprise"; alert.IsOpen = true; }
            }



        }

        private void Contrat_travail(object sender, RoutedEventArgs e)
        {

            SaveFileDialog //ouvre une fentre pour que l'utilisateur choisit l'emplacement de l'attestation
             op = new SaveFileDialog();
            Employee membre = empliste.ToArray()[employé.SelectedIndex];
            info_comp membreComp = compliste.ToArray()[employé.SelectedIndex];
            op.Title = "Selectionner L'emplacement du fichier";
            op.Filter = "fichier word (*.docx)|*.docx";
            op.FileName = membre.nom + membre.prenom + "_" + Convert.ToString(today.Date.Day + "_" + today.Date.Month + "_" + today.Date.Year) + "Contrat de travail";
            // la conversion de DateTime en String
            DateTime datenaiss = Convert.ToDateTime(membre.Date_de_ness);
            DateNaissance = Convert.ToString(datenaiss.Date.Day + "/" + datenaiss.Date.Month + "/" + datenaiss.Date.Year);
            DateTime dateemb = Convert.ToDateTime(membreComp.Date_emb);
            DateEmbauche = Convert.ToString(dateemb.Date.Day + "/" + dateemb.Date.Month + "/" + dateemb.Date.Year);
            DateTime datedem = Convert.ToDateTime(membreComp.Date_dem);
            DateDemission = Convert.ToString(datedem.Date.Day + "/" + datedem.Date.Month + "/" + datedem.Date.Year);
            String chemin1 = Directory.GetCurrentDirectory();
            String chemin2 = Convert.ToString(Directory.GetParent(chemin1));
            String chemin3 = Convert.ToString(Directory.GetParent(chemin2));
            String chemin4 = Convert.ToString(Directory.GetParent(chemin3));
            if (membreComp.statut == "Actif")
            {
                if (info != null)
                { 
                op.ShowDialog();
                contratTravail(" " + info.Raison_so, " " + info.Spécialité, membre.wilaya_naiss, Convert.ToString(info.Numéro_RC), info.identifiant_fi, Convert.ToString(membre.matricule), membre.nom, membre.prenom, DateNaissance, membre.wilaya_naiss, membre.Adresse, DateEmbauche, membreComp.poste, Convert.ToString(membreComp.salaire), info.Gérant, op.FileName, chemin1);///*Convert.ToString(" " + today.Date.Day + "/" + today.Date.Month + "/" + today.Date.Year),*/ info.Gérant + " ", " " + membre.nom + " " + membre.prenom, " " + membre.Date_de_ness, membreComp.Date_dem + " ", membreComp.poste + " ", op.FileName, chemin3);
               alert_text.Text="La génération a bien été faite"; alert.IsOpen = true;
                droper.IsExpanded = false;
                    droper.IsEnabled = false;
                }
                else
                { alert_text.Text = "il manque les informations de l'entreprise"; alert.IsOpen = true; }
            }
            else
            {
                alert_text.Text="Vous ne pouvez pas générer un titre de congé à un(e) employée désactivé(e) ou retraité(e)"; alert.IsOpen = true;
            }

        }

        
    }
}

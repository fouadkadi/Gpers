using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour ajout_employée.xaml
    /// </summary>
    public partial class ajout_employée : Window
    {
        byte[] CV=null;

        public ajout_employée()
        {
            InitializeComponent();
        }

        /**============================LES VARIABLES GLOBALES================================**/
        
        
        DateTime today = DateTime.Today;
        info_comp comp = new info_comp(); 
        static string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={ System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
        DataClasses1DataContext BD = new DataClasses1DataContext(connectString);
        Employee membre = new Employee();
        /**==============================Valider : Permet d'ajouter un employé à la base de données===================**/
        private void Valider(object sender, RoutedEventArgs e)
        {
            DateTime date1=new DateTime();
            if (Date_naissance.SelectedDate!=null)
            {
                 date1 = DateTime.ParseExact(Date_naissance.Text, "d", null);
            }

            DateTime date2= new DateTime();
            if (Date_embauche.SelectedDate!=null) { 
           date2= DateTime.ParseExact(Date_embauche.Text, "d", null);
            }
            DateTime date3 = new DateTime();
            if (Date_demission.SelectedDate!=null)
            { date3 = DateTime.ParseExact(Date_demission.Text, "d", null); }
            

            if (Nom.Text != ""  && CV!=null && Prenom.Text != "" && Adresse.Text != "" && Telephone.Text != "" && Email.Text != "" && Coordonnes_bancaires.Text != ""  && Poste_occupee.Text != "" && Responsable_hiearchique.Text != "" && Salaire.Text != "" && Projet.Text != "" && Situationfamiliale.Text != "" && Statut.Text != "" &&  validerdatenaissance(date1) && validerdateembauche(date2)  &&  wilaya_nessance.SelectedIndex!=-1 && sex.SelectedIndex!=-1)
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
                membre.wilaya_naiss =(string)wilaya_nessance.Text;
                comp.poste = Poste_occupee.Text;
                comp.respo = Responsable_hiearchique.Text;
                comp.salaire = val2;
                comp.Date_dem = date2;
                comp.CV = CV;
                
                comp.Date_emb = date2;            
                comp.projet = Projet.Text;
                comp.NIS = numero_immatriculation_sociale.Text;
                comp.situ_fam = Situationfamiliale.Text;
                comp.statut = Statut.Text;
                comp.sex = sex.Text;
                if (nbr_conge_restants.Text != "")
                {
                    int val3 = Convert.ToInt32(nbr_conge_restants.Text.Trim());
                    comp.Nbj_r_c = val3;
                }
                comp.comment = Commentaire.Text;
                if (Date_demission.Text != "")
                { comp.Date_dem = date3; }

                BD.Employee.InsertOnSubmit(membre);
                BD.info_comp.InsertOnSubmit(comp);
                BD.SubmitChanges();
                alert_text.Text="L'employé a été ajouté";
                alert.IsOpen = true;
            }

            else
            {
                if (validerdatenaissance(date1) == false) { alert_text.Text="Verifiez date de naissance (Min 18 ans)"; }
                if (validerdateembauche(date2) == false) { alert_text.Text = "Verifiez date d'embauche"; }
                if (CV == null) { alert_text.Text = "Charger votre cv"; }
                else alert_text.Text="fiche incomplète";
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


        //===================== Chargement du CV ==================// 
        private void charge_cv(object sender, RoutedEventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Selectionner un fichier";
            op.Filter = "fichier word (*.docx)|*.docx";

            if (op.ShowDialog() == true)
            {
                CV = File.ReadAllBytes(op.FileName);
            }

            if (CV != null) { cv_file.Text = op.FileName; }
        }

        //===================== Chargement du Contrat ==================// 
       /* private void charge_contrat(object sender, RoutedEventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Selectionner un fichier";
            op.Filter = "fichier word (*.docx)|*.docx";

            if (op.ShowDialog() == true)
            {
                Con = File.ReadAllBytes(op.FileName);
            }

            if (Con != null) { contract_file.Text = op.FileName; }
        }*/





        /**=========================Verifier les dates saisies====================================**/
        private Boolean validerdatenaissance(DateTime date)
        {


            if (date != null)
            {
                var age = today.Year - date.Year;
                if (age >= 18 && age <= 100)
                { return true; }
                else return false;
            }
            else return false;
            //{ MessageBox.Show("veuillez verfier"); }
        }

        private Boolean validerdateembauche(DateTime date)
        {

            if (date != null)
            {
                if (date > today) return false;
                else return true;
            }
            else return false;
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

        
        private void contrat_Click(object sender, RoutedEventArgs e)
        {
            
            SaveFileDialog //ouvre une fentre pour que l'utilisateur choisit l'emplacement de l'attestation
             op = new SaveFileDialog();
            info_entreprise info = (from recup in BD.info_entreprise select recup).FirstOrDefault();
            IQueryable<Employee> em = from recup in BD.Employee select recup;
            int mat=0;
            foreach (var s in em) { mat = s.matricule + 1; }
             
            op.Title = "Selectionner L'emplacement du fichier";
            op.Filter = "fichier word (*.docx)|*.docx";
            op.FileName = membre.nom + membre.prenom + "_" + Convert.ToString(today.Date.Day + "_" + today.Date.Month + "_" + today.Date.Year) + "Contrat de travail";
            // la conversion de DateTime en String
            string DateNaissance;
            string DateEmbauche;
            string DateDemission;
            String chemin1 = Directory.GetCurrentDirectory();
            String chemin2 = Convert.ToString(Directory.GetParent(chemin1));
            String chemin3 = Convert.ToString(Directory.GetParent(chemin2));
            String chemin4 = Convert.ToString(Directory.GetParent(chemin3));
            
           
          
            
            
                
                
            
            DateTime date1 = new DateTime();
            if (Date_naissance.SelectedDate != null)
            {
                date1 = DateTime.ParseExact(Date_naissance.Text, "d", null);
            }

            DateTime date2 = new DateTime();
            if (Date_embauche.SelectedDate != null)
            {
                date2 = DateTime.ParseExact(Date_embauche.Text, "d", null);
            }
            DateTime date3 = new DateTime();

            if (Date_demission.SelectedDate != null)
            { date3 = DateTime.ParseExact(Date_demission.Text, "d", null); }


            if (Nom.Text != ""  && Prenom.Text != "" && Adresse.Text != ""  && Coordonnes_bancaires.Text != "" && Poste_occupee.Text != ""  && Salaire.Text != ""  && Statut.Text == "Actif"  && validerdatenaissance(date1) && validerdateembauche(date2) && wilaya_nessance.SelectedIndex!=-1)
                
           
            {

                DateTime datenaiss = Convert.ToDateTime(Date_naissance.SelectedDate);
                DateNaissance = Convert.ToString(datenaiss.Date.Day + "/" + datenaiss.Date.Month + "/" + datenaiss.Date.Year);
                DateTime dateemb = Convert.ToDateTime(Date_embauche.SelectedDate);
                DateEmbauche = Convert.ToString(dateemb.Date.Day + "/" + dateemb.Date.Month + "/" + dateemb.Date.Year);
                if (info != null)
                {
                    op.ShowDialog();
                    contratTravail(" " + info.Raison_so, " " + info.Spécialité, info.wilaya, Convert.ToString(info.Numéro_RC), info.identifiant_fi, mat.ToString(), Nom.Text, Prenom.Text, DateNaissance, wilaya_nessance.Text, Adresse.Text, DateEmbauche, Poste_occupee.Text, Salaire.Text, info.Gérant, op.FileName, chemin1);///Convert.ToString(" " + today.Date.Day + "/" + today.Date.Month + "/" + today.Date.Year), info.Gérant + " ", " " + membre.nom + " " + membre.prenom, " " + membre.Date_de_ness, membreComp.Date_dem + " ", membreComp.poste + " ", op.FileName, chemin3);
                    alert_text.Text = "La génération a bien été faite"; alert.IsOpen = true;
                
                }
                else { alert_text.Text = "il manque les informations de l'entreprise"; alert.IsOpen = true; }
            }
            else
            {
                alert_text.Text = "Vous ne pouvez pas générer un titre de congé à un(e) employée désactivé(e) ou retraité(e)"; alert.IsOpen = true;
            }

            
        }


        private void Attestation_travaille(object sender, RoutedEventArgs e)
        {
            SaveFileDialog //ouvre une fentre pour que l'utilisateur choisit l'emplacement de l'attestation
            op = new SaveFileDialog();
            info_entreprise info = (from recup in BD.info_entreprise select recup).FirstOrDefault();
            
            op.Title = "Selectionner L'emplacement du fichier";
            op.Filter = "fichier word (*.docx)|*.docx";
            op.FileName = membre.nom + membre.prenom + "_" + Convert.ToString(today.Date.Day + "_" + today.Date.Month + "_" + today.Date.Year) + "attestation de travail";
            // la conversion de DateTime en String
            
            String chemin1 = Directory.GetCurrentDirectory();
            String chemin2 = Convert.ToString(Directory.GetParent(chemin1));
            String chemin3 = Convert.ToString(Directory.GetParent(chemin2));
            String chemin4 = Convert.ToString(Directory.GetParent(chemin3));

            DateTime date1 = new DateTime();
            if (Date_naissance.SelectedDate != null)
            {
                date1 = DateTime.ParseExact(Date_naissance.Text, "d", null);
            }

            DateTime date2 = new DateTime();
            if (Date_embauche.SelectedDate != null)
            {
                date2 = DateTime.ParseExact(Date_embauche.Text, "d", null);
            }
            DateTime date3 = new DateTime();

            if (Date_demission.SelectedDate != null)
            { date3 = DateTime.ParseExact(Date_demission.Text, "d", null); }


            if (Nom.Text != "" && Prenom.Text != ""   && Poste_occupee.Text != "" && Salaire.Text != ""  && validerdatenaissance(date1) && validerdateembauche(date2) && wilaya_nessance.SelectedIndex != -1)
            {
                if (info != null)
                {
                    DateTime datenaiss = Convert.ToDateTime(Date_naissance.SelectedDate);
                    string DateNaissance = Convert.ToString(datenaiss.Date.Day + "/" + datenaiss.Date.Month + "/" + datenaiss.Date.Year);
                    DateTime dateemb = Convert.ToDateTime(Date_embauche.SelectedDate);
                    string DateEmbauche = Convert.ToString(dateemb.Date.Day + "/" + dateemb.Date.Month + "/" + dateemb.Date.Year);
                    string Today= Convert.ToString(DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year);
                    op.ShowDialog();
                    attestation(" " + info.Raison_so, " " + info.Spécialité, @chemin1, wilaya_nessance.Text, Convert.ToString(info.Numéro_RC), info.identifiant_fi, Today, info.Gérant + " ", " " + Nom.Text + " " + Prenom.Text, " " + DateNaissance, DateEmbauche + " ", Poste_occupee.Text + " ", op.FileName, chemin1);
                    alert_text.Text = "La génération a bien été faite";
                    alert.IsOpen = true;
                    
                }
                else { alert_text.Text = "il manque les informations de l'entreprise"; alert.IsOpen = true; }
            }
        }


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
                _MonImage = _MonRange.InlineShapes.AddPicture($@"{System.IO.Directory.GetCurrentDirectory()}\logo.png", ref Faux, ref Vrai, ref M);
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
    }
}

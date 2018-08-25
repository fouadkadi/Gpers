using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour fiche_ent.xaml
    /// </summary>
    public partial class fiche_ent : Window
    {
        int identifant;
        public fiche_ent()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void setid(int id)
        {
            this.identifant = id;
            matri_label.Content = "Matricule " + " " + identifant.ToString();
        }



        ///////--------------------------------- Validation de l'entretien -----------------------------//////

        private void validation(object sender, RoutedEventArgs e)
        {
            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
            // initialitation de la preimiere fenetre et tout ce qui doit apparaitre en premier ... 

            DataClasses1DataContext db = new DataClasses1DataContext(connectString);


            //-------------------------------  Creation du Profil de l'entretien--------------------------
            if (expe.Text != "" && Q1.Text != "" && evQ1.Text != "" && Q2.Text != "" && evQ2.Text != "" && statu.Text != "" && etape.Text != "" && comnt.Text != "" && Salaire.Text != "" && date_et.SelectedDate != null)
            {
                Entretien personne = new Entretien();
                personne.matricule = this.identifant;
                personne.exp = expe.Text;
                personne.Q1 = Q1.Text;
                personne.evaQ1 = Convert.ToInt32(evQ1.Text);
                personne.Q2 = Q2.Text;
                personne.evaQ2 = Convert.ToInt32(evQ2.Text);
                personne.date = (DateTime)date_et.SelectedDate;
                personne.salaire_des = Convert.ToInt32(Salaire.Text);
                personne.statut = statu.Text;
                personne.etape_suiv = etape.Text;
                personne.comment = comnt.Text;
                db.Entretien.InsertOnSubmit(personne);
                db.SubmitChanges();
                alert_text.Text= "Bien ajouté";
                alert.IsOpen = true;

                //----- Supprimer la date de l'entretien apres evaluation 
                Recrutement rec = (from recup in db.Recrutement
                                   where recup.matricule == identifant
                                   select recup).FirstOrDefault();
                rec.date_ent_ = null;
                db.SubmitChanges();
                this.Close();
            }
            else { 
                alert_text.Text = "Fiche incomplète";
                alert.IsOpen = true;
            }



        }


        //-------- Verif si numerique  
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        // ---------- verif si text 
        private void textvalid(object sender, TextCompositionEventArgs e)
        {


            Regex regex = new Regex("[^a-z A-Z éèàçù]+");
            e.Handled = regex.IsMatch(e.Text);

        }
    }
}

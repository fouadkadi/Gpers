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
    /// Logique d'interaction pour objectif_ajout.xaml
    /// </summary>
    public partial class objectif_ajout : Window
    {
        List<Employee> empliste;
        List<info_comp> compliste;
        int nbobjectifs = 0;
        objectif Personne; // pour inserer chaque objectif dans la table = new objectif()
        string type = "";
        int duree = 0;
        int count = 0;
        Employee membre = new Employee();
        info_comp membreComp = new info_comp();
        List<TextBox> Objectifs = new List<TextBox>();
        //================================= Stringer ==============================//
        public List<string> tostring(List<Employee> l)
        {
            List<string> result = new List<string>();

            foreach (Employee e in l)
            {
                result.Add(e.nom + " " + e.prenom + " " + e.matricule);

            }

            return result;
        }

        public objectif_ajout()
        {
            InitializeComponent();
            empliste = (from recup in Variables.BD.Employee select recup).ToList();
            compliste = (from recup in Variables.BD.info_comp select recup).ToList();
            employée.ItemsSource = tostring(empliste);
        }

        class TodoItem
        { public int Completion { set; get; } }

        private void ajout_obj(object sender, RoutedEventArgs e)
        {
            Boolean possible = false;
            if (employe_choisi() == false) { alert_text.Text="Veuillez d'abord choisir l'employé(e) auquel(le) vous souhaitez assigner des objectifs ";  alert.IsOpen = true; }
            else if (duree_choisie() == false)
            { alert_text.Text="Veuillez choisir d'abord le type d'objectifs que vous souhaitez assigner";  alert.IsOpen = true; }
            else
            {
                typeobjectif();
                possible = objectifevalue();
                count++;
                if (possible == false)
                { alert_text.Text="Vous avez déjà assigner 6 objectifs de ce type, veuillez faire passer un entretien d'évaluation avant d'assigner d'autres objectifs";  alert.IsOpen = true; }
                else if (count > 6 - nbobjectifs)
                { alert_text.Text="Vous ne pouvez pas assigner plus de 6 objectifs non évalués, vous en avez déjà assigner " + nbobjectifs + "précédemenet";  alert.IsOpen = true; }

                else
                {
                    field t = new field();
                   
                    list_of_obj.Children.Add(t);
                    Objectifs.Add(t.obj_text);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {/*
            StackPanel h = (StackPanel)list_of_obj.Items[0];
            TextBox b = (TextBox)h.Children[1];
            MessageBox.Show(b.Text);*/
            Valider();
        }
        private void typeobjectif()   //permet d'attribuer le type d'objectif suivant le bouton radio validé et aussi de préciser la durée
        {
            if (type_objectif.Text == "Objectif à court terme")
            {
                duree = 6;
                type = "c";
            }
            else
            {
                if (type_objectif.Text == "Objectif à moyen terme")
                {
                    duree = 12;
                    type = "m";
                }
                else
                {
                    if (type_objectif.Text == "Objectif à long terme")
                    {
                        duree = 24;
                        type = "l";
                    }
                }
            }

        }
        private Boolean duree_choisie() // vérifie si un des types a été validé
        {
            if (type_objectif.SelectedIndex == -1) return false;
            return true;
        }
        private Boolean employe_choisi() // vérifie si un employé a été choisi
        {
            if (employée.SelectedIndex == -1) return false;
            return true;
        }
        private Boolean objectifevalue() // retourne si l'employé choisis a 6 objectifs non évalué
        {
            IQueryable<objectif> list = from recup in Variables.BD.objectif
                                        where (recup.matricule == membre.matricule) && (recup.eva == 0) && (recup.type == type)
                                        select recup;
            nbobjectifs = list.Count();
            if (nbobjectifs == 6) return false;
            else return true;
        }

        private void Valider() //permet d'inserer le contenu des champs dans la table objectifs 
        { if(employée.SelectedIndex != -1) { 

            if (date_debut.Text != "" && duree_choisie() == true && NbObjectifs() <= 6 - nbobjectifs && NbObjectifs() != 0 && compliste.ToArray()[employée.SelectedIndex].statut == "Actif") // on vérifie que le type a été choisis et que tous les champs sont remplis //champ_plein() == true

            {
                count = 0;
                DateTime datedebut = DateTime.ParseExact(date_debut.Text, "d", null);
                DateTime datefin = datedebut;
                DateTime date1 = datefin.AddMonths(duree);


                foreach (field info in list_of_obj.Children)
                {
                    if (info.obj_text.Text != "")
                    {
                        

                        Personne = new objectif();
                        Personne.o = info.obj_text.Text;
                        Personne.debut = datedebut;
                        Personne.fin = date1;
                        Personne.matricule = empliste.ToArray()[employée.SelectedIndex].matricule;
                        Personne.eva = 0;
                        Personne.type = type;
                        Variables.BD.objectif.InsertOnSubmit(Personne);
                        Variables.BD.SubmitChanges();
                        alert_text.Text = "Bien assigné";
                        alert.IsOpen = true;
                    }
                }
            }

            else
            {
                if (compliste.ToArray()[employée.SelectedIndex].statut!= "Actif")
                {


                    alert_text.Text="Vous ne pouvez pas assigner des objectifs pour un(e) employé(e) désactivé(e) ou retraité(e)";
                    
                    alert.IsOpen = true;
                }
                else if (NbObjectifs() > 6 - nbobjectifs)
                {

                    alert_text.Text = "Vous ne pouvez pas assigner plus de 6 objectifs non évalués, vous en avez déjà assigner " + nbobjectifs + "précédemenet";
                     
                    alert.IsOpen = true;
                }
                else
                {
                    if (NbObjectifs() == 0) {  alert_text.Text = "veuillez ajouter des objectifs ";alert.IsOpen = true; }
                    else { alert_text.Text="Veuillez sélectionner la date de début des objectifs"; alert.IsOpen = true; }
                }

            }
            }
            else { alert_text.Text = "selctioner l'employé";alert.IsOpen = true; }
        }

        private void employée_seleted(object sender, SelectionChangedEventArgs e)
        {
            if (employée.SelectedIndex != -1)
            {
                membre = empliste.ToArray()[employée.SelectedIndex];
                membreComp = compliste.ToArray()[employée.SelectedIndex];
                count = 0;
            }
        }

        private int NbObjectifs() // calcule le nombre de textBoxes non vides
        {
            int cpt = 0;
            foreach (var B in Objectifs)
            {
                if (B.Text != "") { cpt++; }
            }
            return cpt;
        }
    }
    static class Variables // celà permet de se connecter à la base de données
    {
        private static string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={ System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
        public static readonly DataClasses1DataContext BD = new DataClasses1DataContext(connectString);
    }
}
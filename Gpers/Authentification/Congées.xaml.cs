using Microsoft.Win32;
using Syncfusion.Windows.Controls.Gantt;
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
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using System.Windows.Ink;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Gantt.Grid;



namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour congé2es.xaml
    /// </summary>
    public partial class Congées : Window
    {
        public Congées(int win)
        {
            InitializeComponent();
            dragmenu.SelectedIndex = win;
            ObservableCollection<TaskDetails> task = new ObservableCollection<TaskDetails>();


            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
            // initialitation de la preimiere fenetre et tout ce qui doit apparaitre en premier ... 

            DataClasses1DataContext db = new DataClasses1DataContext(connectString);


            // vérifier les congés dans la base de données , si un congé est deja commencer, diminuer son nombre de jours restants ... 
            IQueryable<congé2> list = from recup in db.congé2 select recup;
            foreach (var b in list)
            {
                DateTime date1 = Convert.ToDateTime(b.debut);
                DateTime date2 = Convert.ToDateTime(b.fin);
                if ((DateTime.Now.Date > date1.Date) && (DateTime.Now.Date < date2.Date))
                {
                    DateTime date = Convert.ToDateTime(b.fin);
                    TimeSpan difference = date.Date - DateTime.Now.Date;
                    b.nb_j_r = (int)difference.Days;
                }
            }
            db.SubmitChanges();
           
            employé_check();
        }

        //==================================================================================================//


        // Les  classes Employée pour les manipulet a partir du code .... 
        public class EmployéeItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public class EmployéeItem1
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }
        public class EmployéeItem2
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }
        public class EmployéeItem3
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }
       
        // ******************************************************** /// 

        // recherche d'un congé2 a partir d'un matircule ... 
        public void rech_congé2_matricule(int matricule)
        {
            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";


            DataClasses1DataContext db = new DataClasses1DataContext(connectString);


            IQueryable<congé2> list = from recup in db.congé2 select recup;

            foreach (var b in list)
            {
                if (b.matricule == matricule)
                {
                    MessageBox.Show("date debut de congé2 : " + Convert.ToString(b.debut) + "\n" + "date fin de congé2 : " + Convert.ToString(b.fin) + "\n" + "type de cogé : " + b.type + "\n");
                }
            }
        }



        public int cpt = 0;
        public int compteur = 0;
        public string matric;
        byte[] file = null;

        


        // évenement clique sur le boutton de saisie d'une nouvelle demande de congé2 et faire apparaitre tous les champs de la saisie ...
        private void employé_check()
        {




            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";


            DataClasses1DataContext db = new DataClasses1DataContext(connectString);

            // remplir les champs des Employée 

            IQueryable<Employee> list = from recup in db.Employee select recup;

            Employée.Items.Clear();

            foreach (var b in list)
            {
                EmployéeItem item = new EmployéeItem();
                item.Text = b.nom + " " + b.prenom + " " + "| " + Convert.ToString(b.matricule);
                Employée.Items.Add(item);
            }





        }


        // Soummetre le formulaire ..

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";


            DataClasses1DataContext db = new DataClasses1DataContext(connectString);

            if (Employée.Text == "")
            {
                alert_text.Text = "veuillez choisir l'employé ";
                alert.IsOpen = true;
            }
            else
            {
                if (Type_congé.Text == "")
                {
                    alert_text.Text = "veuillez choisir le type du congé";
                    alert.IsOpen = true;
                }
                else
                {
                    if (date_début.SelectedDate == null)
                    {
                        alert.IsOpen = true;
                        alert_text.Text = "veuillez choisir la date début de votre congé";
                    }
                    else
                    {
                        if (date_fin.SelectedDate == null)
                        {
                            alert_text.Text = "veuillez choisir la date fin de votre congé";
                            alert.IsOpen = true;
                        }
                        else
                        {
                            if (file != null) {
                                 
                            DateTime datee1 = Convert.ToDateTime(date_début.SelectedDate);
                            DateTime datee2 = Convert.ToDateTime(date_fin.SelectedDate); 
                            if ( datee1.Date> datee2.Date )
                            {
                                alert_text.Text = " La date début de congé doit etre supérieur a la date de fin";
                                alert.IsOpen = true; 
                            }
                            else
                            {
                                Boolean possible = false;
                                string employé = Employée.Text;
                                string[] words = employé.Split(' ');
                                foreach( string word in words )
                                {
                                    matric = word; 
                                }
                                IQueryable<info_comp> liste = from recup in db.info_comp select recup ; 
                                foreach( var b in liste )
                                {
                                    if ( b.matricule== Convert.ToInt32(matric) )
                                    {
                                        DateTime date1 = Convert.ToDateTime(date_fin.SelectedDate);
                                        DateTime date2 = Convert.ToDateTime(date_début.SelectedDate);

                                        TimeSpan dif = date1.Date - date2.Date;
                                        int nombrejours = dif.Days;
                                        if (nombrejours < (int)b.Nbj_r_c) { possible = true; b.Nbj_r_c = (b.Nbj_r_c - dif.Days); }
                                           
                                           
                                     }
                                }
                                if (!possible)
                                {
                                    alert_text.Text = "vous n'avez pas le droit de prendre ce nombre de jouirs de congés.";
                                    alert.IsOpen = true;
                                }
                                else
                                {


                                    // enregistrement du congé2 dans la base de données ....
                                    congé2 newcongé2 = new congé2();

                                    newcongé2.matricule = Convert.ToInt32(matric);
                                    DateTime debut = (DateTime)date_début.SelectedDate;
                                    DateTime fin = (DateTime)date_fin.SelectedDate;
                                    newcongé2.debut = debut;
                                    newcongé2.fin = fin;
                                    newcongé2.type = Type_congé.Text;

                                    TimeSpan difference = fin.Date - debut.Date;
                                    newcongé2.nb_j_r = (int)difference.Days;





                                    if (file != null)
                                    {
                                        newcongé2.formulaire = file;
                                    }

                                    db.congé2.InsertOnSubmit(newcongé2);
                                    db.SubmitChanges();

                                    alert_text.Text = " congé bien enregistré ";
                                    alert.IsOpen = true;
                                }

                            }
                            }
                            else { alert_text.Text = "Charger votre formulaire";alert.IsOpen = true; }
                        }
                    }





                }
            }





            //   Application.Current.Shutdown(); 
        }





        private void formulaire_Click(object sender, RoutedEventArgs e)
        {
            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";


            DataClasses1DataContext db = new DataClasses1DataContext(connectString);


            OpenFileDialog op = new OpenFileDialog();
            op.Title = " Formulaire Demande de congé ";
            op.Filter = "document(*.docx)|*.docx";


            if (op.ShowDialog() == true)
            {
                file = File.ReadAllBytes(op.FileName);
            }

            if (op.FileName != "")
            {
                formulaire_name.Text = op.FileName;
            }

        }


        int cptt = 0;


        // évenement clique sur le bouton valider  .... 
        // remplir la combobox du filtrage en fonction de ce que a choisi l'utilisateur comme filtre .. 
        private void Filtre_actif(object sender, EventArgs e)
        {
            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";


            DataClasses1DataContext db = new DataClasses1DataContext(connectString);



            choixfiltre.Items.Clear();
            cptt++;
            if (Filtre.Text != "")
            {


                IQueryable<Employee> list = from recup in db.Employee select recup;
                if (Filtre.Text == "Employé")
                {

                    foreach (var b in list)
                    {
                        EmployéeItem3 item = new EmployéeItem3();
                        item.Text = b.nom + " " + b.prenom + " " + Convert.ToString(b.matricule);
                        choixfiltre.Items.Add(item);
                    }
                }
                else
                {
                    if (Filtre.Text == "Mois")
                    {

                        for (int i = 1; i < 13; i++)
                        {
                            EmployéeItem3 item = new EmployéeItem3();
                            item.Text = Convert.ToString(i);
                            choixfiltre.Items.Add(item);

                        }
                    }
                    else
                    {

                        for (int i = 0; i < 5; i++)
                        {
                            EmployéeItem3 item = new EmployéeItem3();
                            string année = Convert.ToString(DateTime.Now.Date.Year);
                            int an = Convert.ToInt32(année);
                            choixfiltre.Items.Add(Convert.ToString(an + i));
                        }

                    }
                }

            }
            else { MessageBox.Show("veuillez spécifier le type du filtrage"); }

        }



        /// <summary>
        /// si l'indice du filtre a changé 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 


        // **************************************************************// 

        //             champ de la liste planing des congès ......... // 
        public struct champ_liste
        {
            public int matricule { get; set; }
            public string nom { get; set; }
            public string prenom { get; set; }
            public DateTime debut { get; set; }
            public DateTime fin { get; set; }
            public string type { get; set; }
            public int nb_j_r { get; set; }
        }
        List<champ_liste> planing = new List<champ_liste>();
        private void Filtre_actif2(object sender, EventArgs e)
        {  
            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";


            DataClasses1DataContext db = new DataClasses1DataContext(connectString);
            planing.Clear();

            if (Filtre.Text == "")
            {
                MessageBox.Show("veuillez choisir l'employé ou le mois ou l'année ");
            }
            else
            {
                
                IQueryable<congé2> list = from recup in db.congé2 select recup;
                IQueryable<Employee> list1 = from recup1 in db.Employee select recup1;
                if (Filtre.Text == "Employé")
                {
                   
                    
                        
                        Employee b = list1.ToArray()[choixfiltre.SelectedIndex];
                        
                        foreach (var congé2 in list)
                        {

                            if (congé2.matricule == b.matricule)
                            {
                                
                            champ_liste champ = new champ_liste();
                            champ.matricule = (int)b.matricule;
                            champ.nom = b.nom;
                                champ.prenom = b.prenom;
                               champ.debut = (DateTime)congé2.debut;
                               champ.fin = (DateTime)congé2.fin;
                                champ.type = congé2.type;
                               champ.nb_j_r = (int)congé2.nb_j_r;
                            planing.Add(champ);
                        }
                        }
                        

                       // string chaine = champ.nom + " " + champ.prenom + " " + champ.matricule;
                        //if (chaine == choixfiltre.Text) ;
                        
                    

                    



                }
                else
                {
                    if (Filtre.Text == "Mois")
                    {
                        foreach (var b in list)
                        {
                            champ_liste champ = new champ_liste();

                            champ.matricule = (int)b.matricule;
                            foreach (var employe in list1)
                            {
                                if (employe.matricule == b.matricule)
                                {
                                    champ.nom = employe.nom;
                                    champ.prenom = employe.prenom;
                                }
                            }
                            champ.debut = (DateTime)b.debut;
                            champ.fin = (DateTime)b.fin;
                            champ.type = b.type;
                            champ.nb_j_r = (int)b.nb_j_r;

                            string chaine = Convert.ToString(champ.debut.Date.Month);
                            if (chaine == choixfiltre.Text) planing.Add(champ);
                        }



                    }
                    else
                    {
                        if (Filtre.Text == "Année")
                        {
                            foreach (var b in list)
                            {
                                champ_liste champ = new champ_liste();

                                champ.matricule = (int)b.matricule;
                                foreach (var employe in list1)
                                {
                                    if (employe.matricule == b.matricule)
                                    {
                                        champ.nom = employe.nom;
                                        champ.prenom = employe.prenom;
                                    }
                                }
                                champ.debut = (DateTime)b.debut;
                                champ.fin = (DateTime)b.fin;
                                champ.type = b.type;
                                champ.nb_j_r = (int)b.nb_j_r;

                                string chaine = Convert.ToString(champ.debut.Date.Year);
                                if (chaine == choixfiltre.Text) planing.Add(champ);
                            }

                            



                        }
                    }
                }
            }
            
        }



        private void Visulisé_gantt(object sender, RoutedEventArgs e)
        {

            Gantt_window win = new Gantt_window(planing);
            win.Show();

        }

        private void annule_filtre(object sender, RoutedEventArgs e)
        {
            Filtre.SelectedIndex = -1;
            choixfiltre.SelectedIndex = -1;
            planing.Clear();

            

        }
    }









}

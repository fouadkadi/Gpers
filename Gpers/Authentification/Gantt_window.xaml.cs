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
using static Authentification.Congées;

namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour Gantt_window.xaml
    /// </summary>
    public partial class Gantt_window : Window
    {
        public Gantt_window(List<champ_liste> list)
        {
            InitializeComponent();
            if (!list.Any())
            { plannig_check(); }
            else { 

            gantt.ItemsSource = adapter_gantt(list);
            }
        }
    
    

     


    //=================================  Gantt adapter ================================================//

    public ObservableCollection<TaskDetails> adapter_gantt(List<champ_liste> list)
    {
        ObservableCollection<TaskDetails> Task = new ObservableCollection<TaskDetails>();
        double h;
         double dur;
        TimeSpan d;




        foreach (champ_liste Emp in list)
        {
            h = DateTime.Today.DayOfYear - Emp.debut.DayOfYear;
            d = Emp.fin - Emp.debut;
            dur = Emp.fin.DayOfYear - Emp.debut.DayOfYear;
                if (h > dur) h = dur;
                if (h < 0) h = 0;
            Task.Add(new TaskDetails { TaskId = (int)Emp.matricule, TaskName = Emp.nom + " " + Emp.prenom, StartDate = (DateTime)Emp.debut, FinishDate = (DateTime)Emp.fin, Progress = (h/dur)*100, Duration = d });

        }


        return Task;
    }




    //=========================== Chargement du planning ================================================//
    private void plannig_check()
    {
        string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";


        DataClasses1DataContext db = new DataClasses1DataContext(connectString);




        // création d'une liste nommée planing et mettre dedans les champs qu'on veut afficher dans le data-grid qu'on prendera des deux bases congé et employé
        List<champ_liste> planing = new List<champ_liste>();
        IQueryable<congé2> list = from recup in db.congé2 select recup;
        IQueryable<Employee> list1 = from recup1 in db.Employee select recup1;
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

            planing.Add(champ);
        }

        // une fois la liste pleine on la met dans le Data-grid et l'afficher ... 

        gantt.ItemsSource = adapter_gantt(planing);


    }


    }

    //========================================== GANTT VIEW ================================================//

    /// <summary>
    ///  Grid behavion ( columns header .....etc )
    /// </summary>
    /// 
    class Gridbehave : Behavior<GanttControl>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the Gantt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.GanttGrid.ReadOnly = true;

            // Customizing the header text of the Grid.
            this.AssociatedObject.GanttGrid.Columns[0].HeaderText = "Employée";
            this.AssociatedObject.GanttGrid.Columns[2].HeaderText = "Debut";

            this.AssociatedObject.GanttGrid.Columns[3].HeaderText = "Fin";
            this.AssociatedObject.GanttGrid.Columns[4].HeaderText = "Avancement";
            this.AssociatedObject.GanttGrid.Columns[5].HeaderText = "Durée";

            //this.AssociatedObject.TaskNodeBackground = new SolidColorBrush(Colors.LightCyan);

            // this.AssociatedObject.ScrollGanttChartTo(new DateTime(2012, 01, 06));
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

    }
}

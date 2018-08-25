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
using System.Windows.Shapes;
using System.Reflection;
using MahApps.Metro.Controls;

namespace Authentification
{
    /// <summary>
    /// Interaction logic for Notif.xaml
    /// </summary>
    public partial class Notif : MetroWindow
    {
        static string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
        DataClasses1DataContext BD = new DataClasses1DataContext(connectString);

        public Notif()
        {
            InitializeComponent();
            notification();

        }
        private void notification()
        {
            //listes qui contiendront les résultats de la recherche dans la table Employee et info_comp avec des doublons
            List<Employee> infoA = new List<Employee>();
            List<info_comp> infoB = new List<info_comp>();
            int i = 0;
            // le textblock qui contiendra le nom prenom et le poste des personnes à évaluer


            DateTime today = DateTime.Today;  // permet de contenir la date actuelle
            // permet de récuperer de la table objectif le matricule de toutes les personnes à évaluer
            IQueryable<objectif> list = from recup in BD.objectif
                                        where (recup.eva == 0) && (recup.fin < today)
                                        select recup;

            foreach (var obj in list)
            {   //permet de recuperer de la table Employee l'enregistrement de l'employé ayant un id = matricule
               
                IQueryable<Employee> lista = from recupa in BD.Employee
                                             where recupa.matricule == obj.matricule
                                             select recupa;
                //permet de recuperer de la table info_comp l'enregistrement de l'employé ayant un id = matricule
                IQueryable<info_comp> listb = from recupb in BD.info_comp
                                              where recupb.matricule == obj.matricule
                                              select recupb;
                infoA.Add(lista.First());
                infoB.Add(listb.First());

            }
            // listes qui contients les enregistrements de Employee et info_comp SANS DOUBLONS
            IEnumerable<Employee> SansDoublonsA = infoA.Distinct();
            IEnumerable<info_comp> SansDoublonsB = infoB.Distinct();
            info_comp[] L = new info_comp[1000];
            int top = 20;
            L = SansDoublonsB.ToArray(); // convertir SansDoublonsB en tableau
            if (infoA.Count == 0 && infoB.Count == 0)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Height = 200;
                textBlock.Width = 300;
                Thickness m = textBlock.Margin;
                m.Top = 50;
                m.Left = 20;
                m.Bottom = 0;
                m.Right = 0;
                textBlock.Text = "Aucun entretien d'évaluation à prévoir";
                textBlock.Visibility = Visibility.Visible;
                stackpanel.Children.Add(textBlock);
            }
            else
            {
                TextBlock textBlock1 = new TextBlock();
                textBlock1.Height = 30;
                textBlock1.Width = 300;
                //Thickness m = textBlock1.Margin;
                //m.Top = 20;
                //m.Left = 20;
                //m.Bottom = 0;
                //m.Right = 0;
                textBlock1.Text = "Il est temps de faire passer un entretien d'évaluation à : ";
                textBlock1.Visibility = Visibility.Visible;
                stackpanel.Children.Add(textBlock1);
                foreach (var info in SansDoublonsA)
                {

                    TextBlock textBlock2 = new TextBlock();
                    textBlock1.Height = 30;
                    textBlock1.Width = 400;
                    //Thickness M= textBlock1.Margin;
                    //M.Top = top*(i+1);
                    //M.Left = 20;
                    //M.Bottom = 0;
                    //M.Right = 0;
                    textBlock2.Text = textBlock2.Text + info.nom + " " + info.prenom + " poste : " + L[i].poste;
                    textBlock2.Visibility = Visibility.Visible;
                    stackpanel.Children.Add(textBlock2);
                    i++;
                }
            }

        }


    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration.Assemblies;
using System.Drawing;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Diagnostics;

namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour Card2.xaml
    /// </summary>
    public partial class Card2 : UserControl
    {
      

        static string connectString = $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = { System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf; Integrated Security = True; Connect Timeout = 30";
        DataClasses1DataContext bdd = new DataClasses1DataContext(connectString);
        DateTime today = DateTime.Today;
        public Card2()
        {
            InitializeComponent();

        }


        private void edition_Click(object sender, RoutedEventArgs e)
        {

            var info = bdd.info_entreprise.FirstOrDefault();
            var comp = bdd.info_comp.First(k => k.matricule.ToString().Equals(matricule.Text));
            var list = (from rec in bdd.objectif
                        where (rec.matricule.ToString().Equals(matricule.Text)) && (rec.eva == 0)
                        select rec).ToList();
           try

           {
                int count = 1;
                int gpt = 1;
            MessageBox.Show(list.Count().ToString());

                string fileNameOnly = System.IO.Path.GetFileNameWithoutExtension($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\Fiche\{nom.Text + "_" + prenom.Text + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year}.xlsx");
                string extension = System.IO.Path.GetExtension($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\Fiche\{nom.Text + "_" + prenom.Text + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year}.xlsx");
                string path = System.IO.Path.GetDirectoryName($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\Fiche\{nom.Text + "_" + prenom.Text + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year}.xlsx");

                string newFullPath = $@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\Fiche\{nom.Text + "_" + prenom.Text + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year}.xlsx";

                while (File.Exists(newFullPath))
                {
                    gpt++;
                    string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                    newFullPath = System.IO.Path.Combine(path, tempFileName + extension);
                    if (gpt == 2)
                        MessageBox.Show(nom.Text.ToUpper() + " " + prenom.Text.ToUpper() + " a déja été évalué(e) aujourd'hui, une copie de la dernière fiche d'évaluation va donc être créé.", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                ExcelManip ob = new ExcelManip($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\modeles\Fiche.xlsx", 1);
                string[] dirs = Directory.GetFiles($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\Fiche", $"{nom.Text + "_" + prenom.Text}*");
                if (dirs.Length > 0)
                {
                    var directory = new DirectoryInfo($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\Fiche");
                    var dernier = directory.GetFiles($"{nom.Text + "_" + prenom.Text}*").OrderByDescending(f => f.LastWriteTime).First();
                    ob.ancien($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\Fiche\{dernier.ToString()}");

                }
                ob.creer_fichier_entretien($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\logo.png", info.Raison_so, info.Spécialité, nom.Text + " " + prenom.Text, Poste.Text, comp.respo, comp.Date_emb.Value.ToShortDateString(), list);
                ob.saveas(newFullPath);
                MessageBox.Show("Opération effectuée avec succes.", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                ob.Close();
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void compte_rendu_Click(object sender, RoutedEventArgs e)
        {
            string[] dirss = Directory.GetFiles($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\Fiche", $"{nom.Text + "_" + prenom.Text}*");
            if (dirss.Length > 0)
            {
                var directory = new DirectoryInfo($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\Fiche");
                var dernier = directory.GetFiles($"{nom.Text + "_" + prenom.Text}*").OrderByDescending(f => f.LastWriteTime).First();
                ExcelManip ob3 = new ExcelManip($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\Fiche\{dernier.ToString()}", 1);
                List<LView> items = new List<LView>();

                int cpt1 = 94;
                for (int i = 0; i < 6; i++)
                {
                    if (ob3.readExcelcell(cpt1, 3) != "0")
                    {
                        LView a = new LView();
                        a.Objectif = ob3.readExcelcell(cpt1, 3);
                        a.Evaluation = ob3.readExcelcell(cpt1, 8);
                        a.Type = "Court terme";
                        items.Add(a);

                    }
                    cpt1++;
                }
                int cpt2 = 103;
                for (int i = 0; i < 6; i++)
                {
                    if (ob3.readExcelcell(cpt2, 3) != "0")
                    {
                        LView a = new LView();
                        a.Objectif = ob3.readExcelcell(cpt2, 3);
                        a.Evaluation = ob3.readExcelcell(cpt2, 8);
                        a.Type = "Moyen terme";
                        items.Add(a);
                    }
                    cpt2++;
                }
                int cpt3 = 112;
                for (int i = 0; i < 6; i++)
                {
                    if (ob3.readExcelcell(cpt3, 3) != "0")
                    {
                        LView a = new LView();
                        a.Objectif = ob3.readExcelcell(cpt3, 3);
                        a.Evaluation = ob3.readExcelcell(cpt3, 8);
                        a.Type = "Long terme";
                        items.Add(a);
                    }
                    cpt3++;
                }
                PV compte = new PV(items);
                
                compte.Show();
                ob3.Close();

            }
            else
            {
                MessageBox.Show("Aucune évaluation n'a été effectuée pour le moment.", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void visualiser_Click(object sender, RoutedEventArgs e)
        {
            string folder = Uri.EscapeDataString($@"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\Fiche");
            string file = Uri.EscapeDataString(nom.Text + "_" + prenom.Text);
            string uri = "search:query=" + file + "&crumb=" + folder;
            Process.Start(new ProcessStartInfo(uri));
            
        }
    }
}

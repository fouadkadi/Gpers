using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.XlsIO;
using System.IO;
//using Windows.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
    /// Logique d'interaction pour Annuaire2.xaml
    /// </summary>
    public partial class Annuaire2 : Window
    {
        public Annuaire2()
        {
            InitializeComponent();
            InitializeComponent();
            string connectString = $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = { System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf; Integrated Security = True; Connect Timeout = 30";
            DataClasses1DataContext db = new DataClasses1DataContext(connectString);

            IQueryable<Employee> list = from rec in db.Employee
                                        select rec;
            IQueryable<info_comp> list9 = from rec in db.info_comp
                                          select rec;
            List<customgrid> custom = new List<customgrid>();
            int i = 0;
            foreach (Employee a in list)
            {
                customgrid e = new customgrid();
                e.matricule = a.matricule;
                e.nom = a.nom;
                e.prenom = a.prenom;
                e.Numtel = ("0" + (a.Num_tel)).ToString();
                e.Adr_mail = a.Adr_mail;
                e.poste = list9.ToArray()[i].poste;
                e.projet = list9.ToArray()[i].projet;
                i++;
                custom.Add(e);

            }
            datagrid.ItemsSource = custom;
        }
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var options = new ExcelExportingOptions();
            options.ExcelVersion = ExcelVersion.Excel2013;
            var excelEngine = datagrid.ExportToExcel(datagrid.View, options);
            var workbook = excelEngine.Excel.Workbooks[0];
            System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog
            {
                FilterIndex = 2,
                Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx"
            };
            sfd.FileName = "Annuaire";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (Stream stream = sfd.OpenFile())
                {
                    if (sfd.FilterIndex == 1)
                        workbook.Version = ExcelVersion.Excel97to2003;
                    else if (sfd.FilterIndex == 2)
                        workbook.Version = ExcelVersion.Excel2010;
                    else
                        workbook.Version = ExcelVersion.Excel2013;
                    workbook.SaveAs(stream);
                }

            }
        }


    }


    public class customgrid
    {

        public int matricule { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string Numtel { get; set; }
        public string Adr_mail { get; set; }
        public string poste { get; set; }
        public string projet { get; set; }




    }
}

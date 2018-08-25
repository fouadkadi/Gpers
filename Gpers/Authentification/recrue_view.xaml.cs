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
    /// Logique d'interaction pour recrue_view.xaml
    /// </summary>
    public partial class recrue_view : Window
    {
        public recrue_view()
        {
            InitializeComponent();
        }
        private void add_rec(object sender, RoutedEventArgs e)
        {
            string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
            // initialitation de la preimiere fenetre et tout ce qui doit apparaitre en premier ... 

            DataClasses1DataContext db = new DataClasses1DataContext(connectString);
            if (nom.Text != "" && num.Text != "" && poste.Text != "" && adr.Text != "")
            {
                Recrutement rec = new Recrutement();
                rec.nom_dm = nom.Text;
                rec.num = Convert.ToInt32(num.Text);
                rec.int_post = poste.Text;
                rec.Adr_mail = adr.Text;
                db.Recrutement.InsertOnSubmit(rec);
                db.SubmitChanges();
               alert_text.Text=" Bien ajouté";
                alert.IsOpen = true;
            }
            else {
                alert_text.Text = "fiche incomplète";
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

        private void UserControl4_Initialized(object sender, EventArgs e)
        {

        }

        private void TabItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}

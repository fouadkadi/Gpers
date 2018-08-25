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
    /// Logique d'interaction pour infoentreprise.xaml
    /// </summary>
    public partial class infoentreprise : Window
    {
        static string connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={ System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
        bool full=false;
        info_entreprise informa;
        DataClasses1DataContext db = new DataClasses1DataContext(connectString);
        public infoentreprise()
        {
            InitializeComponent();
            IQueryable<info_entreprise> list = from recup in db.info_entreprise select recup;
            List<info_entreprise> e = list.ToList();
            if (e.Any())
            { charger(e.LastOrDefault()); full = true; }


        }

        //======================== Charger les informations précédentes ==================//

        public void charger(info_entreprise e)
        {
            informa = e;
            Raison_sociale.Text=e.Raison_so;
            Spécialité.Text=e.Spécialité;
            Site_web.Text=e.site_web;
            Adresse.Text=e.Adr;
            Adresse_mail_gérant.Text=e.Adr_mail_g;
            Numéro_RC.Text = e.Numéro_RC.ToString();
            Telephone.Text=e.Téléphone.ToString();
            Identifiant_fiscal.Text=e.identifiant_fi;
            Fax.Text = e.Fax.ToString();
            wilaya.SelectedIndex = getwilay(e.wilaya);
            Gérant.Text=e.Gérant;
            if (e.Logo!=null) { 
            logo.Source =LoadImage(e.Logo.ToArray());
            }

        }


        //======================== Charger le logo =======================//

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }


        byte[] _imageBytes;
        private void logo_Click(object sender, RoutedEventArgs e)
        {


            

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png" ;
            if (op.ShowDialog() == true)
            {

                logo.Source = new BitmapImage(new Uri(op.FileName));

            }



            if (op.FileName != "")
            { 
            _imageBytes = File.ReadAllBytes(op.FileName);
            }

            //---------------- RECOVER IMAGE -------------------------------
            /*
             var list = (from b in db.container
                                           where b.Id == 1
                                           select b).FirstOrDefault();

             byte[] array = (byte[])list.img_.ToArray();

             File.WriteAllBytes(@"C:\Users\user\Desktop\projet\stagelist.png", array);*/

            //--------------------------- SAVE IMAGE -------------------------------
            /* _imageBytes = File.ReadAllBytes(op.FileName);

              container b = new container();a
              b.img_ = _imageBytes;
              db.container.InsertOnSubmit(b);
              db.SubmitChanges();*/

        }




        //====================== Validé les informations ========================//

        private void valid(object sender, RoutedEventArgs e)
        {
            if (_imageBytes!=null && Raison_sociale.Text!="" && Spécialité.Text!="" && Site_web.Text!="" && Gérant.Text!="" && Adresse.Text!="" && Telephone.Text !="" && Fax.Text!="" && Adresse_mail_gérant.Text!="" && Numéro_RC.Text!="" && Identifiant_fiscal.Text!="" && wilaya.SelectedIndex!=-1)
            {
                info_entreprise info;

                if (full) { info = informa; } else { info = new info_entreprise(); }
                info.Raison_so = Raison_sociale.Text;
                info.Spécialité = Spécialité.Text;
                info.site_web = Site_web.Text;
                info.Adr = Adresse.Text;
                info.Adr_mail_g = Adresse_mail_gérant.Text;
                info.Numéro_RC = Convert.ToInt32(Numéro_RC.Text);
                info.Téléphone = Convert.ToInt32(Telephone.Text);
                info.identifiant_fi = Identifiant_fiscal.Text;
                info.Fax = Convert.ToInt32(Fax.Text);
                info.Gérant = Gérant.Text;
                info.wilaya =(string)wilaya.Text;
                info.Logo = _imageBytes;
                
                if (!full) { db.info_entreprise.InsertOnSubmit(info); }
                
                db.SubmitChanges();

                alert_text.Text = "Bien ajouté";
                alert.IsOpen = true;






            }
            else { alert_text.Text="Fiche non compléte"; alert.IsOpen = true;
            }
        }

        List<string> wilayas = new List<string> { "1- Adrar", "2- Chlef","3- Laghouat","4- Oum El Bouaghi", "5- Batna","6- Bejaia",
                                "7- Biskra",
                                "8- Bechar",
                                "9- Blida",
                                "10- Bouira",
                                "11- Tamanrassat",
                                "12- Tébessa",
                                "13- Tlemcen",
                                "14- Tiaret",
                                "15- Tizi Ouzou",
                                "16- Alger",
                                "17- Djelfa",
                                "18- Jijel",
                                "19- Sétif",
                                "20- Saida",
                                "21- Skikda",
                                "22- Sidi Bel Abbès",
                                "23- Annaba",
                                "24- Guelma",
                                "25- Constantine",
                                "26- Médéa",
                                "27- Mostaganem",
                                "28- M'Sila",
                                "29- Mascara",
                                "30- Ouargla",
                                "31- Oran",
                                "32- El Bayadh",
                                "33- Illizi",
                                "34- Bordj Bou Arreridj",
                                "35- Boumerdès",
                                "36- El Tarf",
                                "37- Tindouf",
                                "38- Tissemsilt",
                                "39- El oued",
                                "40- Khenchela",
                                "41- Souk Ahras",
                                "42- Tipaza",                                "43- Mila",                                "44- Ain Defla",
                                "45- Naama",                                "46- Ain Témouchent",                               "47- Ghardaia",                               "48- Relizane" };
        int getwilay( string e)
        {
            return wilayas.IndexOf(e);
            
        }

        //====================== Controle de saisie ========================//

        //-------- Verif si numerique  
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }
        // ---------- verif si text 
        private void textvalidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-z A-Z éèàçù]+");
            e.Handled = regex.IsMatch(e.Text);

        }


        //================================= Fermer / Reduire ==============================//

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

    }
}

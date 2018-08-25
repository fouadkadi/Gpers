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
    /// Logique d'interaction pour modif_password.xaml
    /// </summary>
    public partial class modif_password : Window
    {
        static String connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
        DataClasses1DataContext db = new DataClasses1DataContext(connectString);
        Auth client;
        public modif_password()
        {
            InitializeComponent();
        }


        //============================ Récuperation de l'employé =============================//

        public void getclient(Auth client)
        {
            



            this.client = (from recup in db.Auth where recup.Id == client.Id select recup).FirstOrDefault();
            user.Text = client.user;
            user.IsEnabled = false;

        }

        //=============================== Validation du changement ====================================//

        private void Ajout_Click(object sender, RoutedEventArgs e)
        {
           


            if (passwordBox_old.Password == client.password)
            {  
                if(passwordBox_new.Password!="" && passwordBox_new.Password.Length >= 8)
                {

                    client.password = passwordBox_new.Password;
                    db.SubmitChanges();
                    alert_text.Text = "Bien modifié";
                    alert.IsOpen = true;

                }
                else
                {
                    alert_text.Text = "Nouveau mot de pass invalid ( Min 8 caractères)";
                    alert.IsOpen = true;
                }





            }
            else
            {
                alert_text.Text = "ancien mot de passe invalid";
                alert.IsOpen = true;

            }

            



            
        }
    }
}

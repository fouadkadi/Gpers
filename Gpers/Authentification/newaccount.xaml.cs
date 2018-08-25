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
namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour newaccount.xaml
    /// </summary>
    public partial class newaccount : Window
    {
        public newaccount()
        {
            InitializeComponent();
        }

        private void Ajout_Click(object sender, RoutedEventArgs e)
        {
            String connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
            DataClasses1DataContext db = new DataClasses1DataContext(connectString);

            //--- Recuperation de l'utilisateur 
            IQueryable<Auth> list = from recup in db.Auth where recup.user == user.Text  select recup;
            List<Auth> lst = list.ToList();

            if (list.Any())
            { alert_text.Text= "utilisateur exictant!";  alert.IsOpen = true; }
            else
            {
                if (user.Text != "" && passwordBox.Password != "" && comboBox.Text != "" && passwordBox.Password.Length >= 8)
                {
                    Auth client = new Auth();
                    client.password = passwordBox.Password;

                    client.user = user.Text;
                    if (comboBox.SelectedIndex == 0) { client.profil_admin = 1; client.profil_gest = 0; }
                    if (comboBox.SelectedIndex == 1) { client.profil_admin = 1; client.profil_gest = 1; }
                    if (comboBox.SelectedIndex == 2) { client.profil_admin = 0; client.profil_gest = 1; }
                    db.Auth.InsertOnSubmit(client);
                    db.SubmitChanges();
                    alert_text.Text = "Bien ajouter";
                    alert.IsOpen = true;
                }
                else
                { if (passwordBox.Password.Length < 8) { alert_text.Text = "mot de passe tros petit ( MIN 8 caractères)"; }

                    else { alert_text.Text = "nom d'utilisateur ou profil érroné "; }
                    alert.IsOpen = true;
                }



            }
        }
    }
}

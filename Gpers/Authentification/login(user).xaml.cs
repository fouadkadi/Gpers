using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Logique d'interaction pour login_user_.xaml
    /// </summary>
    public partial class login_user_ : Window
    {
        Window w;


        public login_user_()
        {
            InitializeComponent();
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //======================================== Bouton de connexion ==============================================//

        private void valid_Click(object sender, RoutedEventArgs e)
        {
            String connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
            DataClasses1DataContext db = new DataClasses1DataContext(connectString);



            //--- Recuperation de l'utilisateur 
            IQueryable<Auth> list = from recup in db.Auth where recup.user == user.Text && recup.password == pass.Password select recup;
            List<Auth> lst = list.ToList();
            

            if (lst.Any()) //---- Si il exicte 
            {
                Auth client = lst.FirstOrDefault();

                //---- Passage de l'utilisateur vers la nouvelle fenetre 
                alert_text.Text = "Bien connecté";
                alert.IsOpen = true;
                Principal win = new Principal();
                win.get_client(client);
                w = win;
            }
            else //---- Si il exicte pas alors afficher un message d'erreur 
            {
                alert_text.Text = "Utilisateur ou mot de passe incorrect";
                alert.IsOpen = true;
            }


        }

        private void alert_quite(object sender, RoutedEventArgs e)
        {
            if(alert_text.Text=="Bien connecté")
            {
                w.Show();
                this.Close();
            }

        }

        //============================= Recupération du mot de passe ===============================//
        private void link_click(object sender, RoutedEventArgs e)
        {
            MailMessage email = new MailMessage();
            email.From = new System.Net.Mail.MailAddress("fouadkrimou@gmail.com");
            email.To.Add(new MailAddress("gf_kadi@esi.dz"));
            email.IsBodyHtml = true;
            
            email.Subject = "objet du mail";
            email.Body = "  contenu du mail";
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 465;
            smtp.EnableSsl = true;
            smtp.Timeout = 4000;
            smtp.Credentials = new System.Net.NetworkCredential("fouadkrimou@gmail.com", "foufoufoufou");
            try
            {
                smtp.Send(email);
                MessageBox.Show("email est envoyer");

            }
            catch (SmtpException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

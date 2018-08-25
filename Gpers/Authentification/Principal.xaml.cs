using MahApps.Metro;
using MahApps.Metro.Controls;
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
using Microsoft.TeamFoundation.Build.Controls;
using System.ComponentModel.DataAnnotations;
using MahApps.Metro.Controls.Dialogs;
using System.Reflection;

namespace Authentification
{
    /// <summary>
    /// Logique d'interaction pour Principal.xaml
    /// </summary>
    public partial class Principal : MetroWindow
    {
        static String connectString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\ProjetBDD.mdf;Integrated Security=True;Connect Timeout=30";
        DataClasses1DataContext db = new DataClasses1DataContext(connectString);

        Auth Client;

        public Principal()
        {
            InitializeComponent();
            IQueryable<info_comp> liste = from recup in db.info_comp select recup;
            foreach (var b in liste)
            {
                DateTime date = new DateTime();
                date = (DateTime)b.Date_emb;
                DateTime date1 = DateTime.Now;

                int nbm = ((date1.Year - date.Year) * 12) + date1.Month - date.Month;
                int nbjc = (int)((nbm) * 1.8);
                
                b.Nbj_r_c = nbjc -calcule_congé(b.matricule);
               

                db.SubmitChanges();
            }

            chargethemes();
            chargecalendier();



        }


        public void get_client(Auth c)
        {


            //=========================== inisialisation des information de la fenetre selon le client ===================================// 

            this.Client = (from recup in db.Auth where recup.Id == c.Id select recup).First();
            user_name.Text = c.user;
            if (Client.couleur != null && Client.theme != null)
            {
                ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent(Client.couleur),
                                    ThemeManager.GetAppTheme(Client.theme));

            }
            else
            {
                if (Client.couleur != null) ThemeManager.ChangeAppStyle(this,
                                 ThemeManager.GetAccent(Client.couleur),
                                 ThemeManager.DetectAppStyle(this).Item1);
                if (Client.theme != null) ThemeManager.ChangeAppStyle(this,
                                           ThemeManager.DetectAppStyle(this).Item2,
                                           ThemeManager.GetAppTheme(Client.theme));
            }
        }


        int calcule_congé(int ma)
        {
            IQueryable<congé2> list = from recup in db.congé2 where recup.matricule == ma select recup;

            int sauv=0;
            foreach(congé2 c in list)
            {
                DateTime f= (DateTime)c.fin;
                DateTime deb= (DateTime)c.debut;

                TimeSpan t = f.Date - deb.Date;
                sauv +=   t.Days;
            }


                                     return sauv;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            login_user_ a = new login_user_();
            a.Show();

        }



        //====================== Option pour le menu déroulent =========================// 

        private void ShowAccent(object sender, RoutedEventArgs e)
        {

            this.ToggleFlyout(0);
        }
        private void ToggleFlyout(int index)
        {
            var flyout = this.Flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;

        }











        //============================================================================================================//
        //==================================== Affichage et theme ====================================================//
        //============================================================================================================//



        void chargethemes()
        {
            List<string> theme_l = new List<string> { "BaseLight", "BaseDark" };

            theme.ItemsSource = theme_l;
            List<string> accent_l = new List<string> { "Red", "Green", "Blue", "Purple", "Orange", "Lime", "Emerald", "Teal", "Cyan", "Cobalt", "Indigo", "Violet", "Pink", "Magenta", "Crimson", "Amber", "Yellow", "Brown", "Olive", "Steel", "Mauve", "Taupe", "Sienna" };
            accent.ItemsSource = accent_l;


        }

        private void theme_chosed(object sender, RoutedEventArgs e)
        {
            MenuItem b = (MenuItem)sender;

            MessageBox.Show(sender.ToString());
        }

        private void accent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            ThemeManager.ChangeAppStyle(this,
                                        ThemeManager.GetAccent((string)accent.SelectedItem),
                                        ThemeManager.DetectAppStyle(this).Item1);

            Client.couleur = (string)accent.SelectedItem;
            db.SubmitChanges();



        }

        private void theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ThemeManager.ChangeAppStyle(this,
                                         ThemeManager.DetectAppStyle(this).Item2,
                                         ThemeManager.GetAppTheme((string)theme.SelectedItem));
            Client.theme = (string)theme.SelectedItem;
            db.SubmitChanges();

        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            HamburgerMenuControl.Content = e.InvokedItem;
        }



        private void chargecalendier()
        {
            IQueryable<Recrutement> ent = from recup in db.Recrutement where recup.date_ent_ > DateTime.Today select recup;
            IQueryable<objectif> obj= from recup in db.objectif where recup.fin > DateTime.Today select recup;
            calendar1.SelectionMode = CalendarSelectionMode.MultipleRange;
            foreach (var e in ent)
            {
                calendar1.SelectedDates.Add((DateTime)e.date_ent_);
            }
            foreach (var e in obj)
            {
                
                 calendar1.SelectedDates.Add((DateTime)e.fin);
            }

            calendar1.SelectionMode = CalendarSelectionMode.MultipleRange;
        }
        //============================== Evenments De click ===================================//



            //==========// Partie parametres //==========//

            //=================== Information de l'entreprise ====================//

        private void Infoentreprise_checked(object sender, RoutedEventArgs e)
        {
            if (Client.profil_admin == 1)
            {
                infoentreprise win = new infoentreprise();
                win.Show();
            }
            else { this.ShowMessageAsync("Accès Refusé", "Vous n'avez pas de droit administrateur"); }

        }


        //=================== Modification du mot de passe ====================//
        private void mofid_compte_checked(object sender, RoutedEventArgs e)
        {
            modif_password win = new modif_password();
            win.getclient(Client);
            win.Show();
        }

        //=================== Creation D'un nouveau compte ====================//
        private void nouveau_compte_checked(object sender, RoutedEventArgs e)
        {
            if (Client.profil_admin == 1)
            {
                newaccount win = new newaccount();
                win.Show();
            }
            else
            {
                this.ShowMessageAsync("Accès Refusé", "Vous n'avez pas de droit administrateur");
            }

        }


        private void click(object sender, ItemClickEventArgs e)
        {
            if (Client.profil_gest != 1)
            {
                this.ShowMessageAsync("Accès Refusé", "Vous n'avez pas de droit Gestionaire");
                HamburgerMenuControl.IsEnabled = false;


            }
        }


        //============= --- Deconnexion --- ===============//
        private void Logout_click(object sender, RoutedEventArgs e)
        {
            login_user_ win = new login_user_();
            win.Show();
            this.Close();

        }



                      //==========// Partie Menu //==========//


        private void ajouter_employée(object sender, RoutedEventArgs e)
        {
            ajout_employée win = new ajout_employée();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.button1.Background = redBrush;
            win.button1.BorderThickness = new Thickness(0);
            win.button2.Background = redBrush;
            win.button2.BorderThickness = new Thickness(0);
            win.cv.Background = redBrush;
            win.cv.BorderThickness = new Thickness(0);
            win.contrat.Background = redBrush;
            win.contrat.BorderThickness = new Thickness(0);
            win.contrat_charger.Background = redBrush;
            win.contrat_charger.BorderThickness = new Thickness(0);
            win.Show();

        }

        private void modif_click(object sender, RoutedEventArgs e)
        {
            modif_employée win = new modif_employée();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.button1.Background = redBrush;
            win.button1.BorderThickness = new Thickness(0);
            win.button2.Background = redBrush;
            win.button2.BorderThickness = new Thickness(0);
            win.button3.Background = redBrush;
            win.button3.BorderThickness = new Thickness(0);
            win.Show();

        }
        private void planing_click(object sender, RoutedEventArgs e)
        {
            Congées win = new Congées(0);
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.dragmenu.BorderBrush = redBrush;
            
            win.vis.Background = redBrush;
            win.vis.BorderThickness = new Thickness(0);
            win.but.Background = redBrush;
            win.but.BorderThickness = new Thickness(0);
            win.validé.Background = redBrush;
            win.validé.BorderThickness = new Thickness(0);
            win.formulaire.Background = redBrush;
            win.formulaire.BorderThickness = new Thickness(0);
            win.dono.Background = redBrush;
            win.dono.BorderThickness = new Thickness(0);
            win.Show();
        }
        private void ajout_click(object sender, RoutedEventArgs e)
        {
            Congées win = new Congées(1);
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.dragmenu.BorderBrush = redBrush;
            win.vis.Background = redBrush;
            win.vis.BorderThickness = new Thickness(0);
            win.but.Background = redBrush;
            win.but.BorderThickness = new Thickness(0);
            win.validé.Background = redBrush;
            win.validé.BorderThickness = new Thickness(0);

            win.formulaire.Background = redBrush;
            win.formulaire.BorderThickness = new Thickness(0);
            win.dono.Background = redBrush;
            win.dono.BorderThickness = new Thickness(0);
            win.Show();
        }
        private void condiat_click(object sender, RoutedEventArgs e)
        {

            User4 win = new User4();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.Show();

        }

        //============================= - - - - - -  Liste des entretien - - - - - ========================//
        private void entretien_click(object sender, RoutedEventArgs e)
        {
            Entretien_view win = new Entretien_view();
            win.Show();
        }

        //============================= - - - - - -  Ajout objectif  - - - - - ========================//
        private void Définir_click(object sender, RoutedEventArgs e)
        {
            objectif_ajout win = new objectif_ajout();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.but1.Background = redBrush;
            win.but1.BorderThickness = new Thickness(0);

            win.but2.Background = redBrush;
            win.but2.BorderThickness = new Thickness(0);
            win.Show();
        }

        //============================= - - - - - -  Evaluation objectif  - - - - - ========================//
        private void evaclick(object sender, RoutedEventArgs e)
        {
            Evaluation win = new Evaluation();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.nontrouvé.Background = redBrush;
            win.nontrouvé.BorderThickness = new Thickness(0);
            win.recherche.Background = redBrush;
            win.recherche.BorderThickness = new Thickness(0);

            win.retour.Background = redBrush;
            win.retour.BorderThickness = new Thickness(0);
            win.Show();
        }

        //============================= - - - - - -  Annuaire mosaique  - - - - - ========================//
        private void ann_click(object sender, RoutedEventArgs e)
        {
            Annuaire win = new Annuaire();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.retour.Background = redBrush;
            win.retour.BorderThickness = new Thickness(0);
            win.search.Background = redBrush;
            win.search.BorderThickness = new Thickness(0);
            win.searchbutton.Background = redBrush;
            win.searchbutton.BorderThickness = new Thickness(0);
            win.Show();

        }
        //============================= - - - - - -  Annuaire Grille  - - - - - ========================//
        private void an_click(object sender, RoutedEventArgs e)
        {
            Annuaire2 win = new Annuaire2();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.Export.Background = redBrush;
            win.Export.BorderThickness = new Thickness(0);
            win.Show();
        }

        //============================= - - - - - -  Liste des recrues  - - - - - ========================//
        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            recrue_view win = new recrue_view();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.button_Copy.Background = redBrush;
            win.button_Copy.BorderThickness = new Thickness(0);
            win.Show();
        }
        //============================= - - - - - -  Planifier un entretien  - - - - - ========================//
        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            User5xaml win = new User5xaml();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.Show();
        }

        //============================= - - - - - -  Evaluation  - - - - - ========================//
        private void Tile_Click_2(object sender, RoutedEventArgs e)
        {
            User7 win = new User7();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.Show();
        }

        //============================= - - - - - -  Resultat evaluation  - - - - - ========================//
        private void Tile_Click_3(object sender, RoutedEventArgs e)
        {
            User9 win = new User9();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.Show();
        }



        //============================= - - - - - -  Génération des documents  - - - - - ========================//

        private void Attestation_clik(object sender, RoutedEventArgs e)
        {
            Génération_document win = new Génération_document();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.valid.Background = redBrush;
            win.one.Background = redBrush;
            win.two.Background = redBrush;
            win.three.Background = redBrush;
            win.four.Background = redBrush;


            win.valid.BorderThickness = new Thickness(0);
            win.one.BorderThickness = new Thickness(0);
            win.two.BorderThickness = new Thickness(0);
            win.three.BorderThickness = new Thickness(0);
            win.four.BorderThickness = new Thickness(0);
            win.Show();
        }

        private void Historique_salaire(object sender, RoutedEventArgs e)
        {
            Logsalaire win = new Logsalaire();
            SolidColorBrush redBrush;
            if (Client.couleur == "Taupe") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("BurlyWood"); }
            else if (Client.couleur == "Mauve") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkMagenta"); }
            else if (Client.couleur == "Steel") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGray"); }
            else if (Client.couleur == "Amber") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Moccasin"); }
            else if (Client.couleur == "Cobalt") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkBlue"); }
            else if (Client.couleur == "Emerald") { redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("DarkGreen"); }
            else
            {
                redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(Client.couleur);
            }
            win.colzone.Background = redBrush;
            win.Show();

        }
    }

}
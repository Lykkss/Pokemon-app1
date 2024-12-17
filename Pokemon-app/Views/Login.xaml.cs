using System.Windows;
using Pokemon_app.ViewModel; // Assure-toi d'ajouter cette ligne si tu utilises le ViewModel

namespace Pokemon_app.Views
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();  // Lier le ViewModel pour gérer la logique de connexion
        }

        // Événement de clic sur le bouton "Valider"
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = mail.Text;  // Récupérer l'email
            string password = pass.Password;  // Récupérer le mot de passe

            // Ici, tu pourrais appeler un service ou un ViewModel pour valider les informations
            // Par exemple, vérifier si l'email et le mot de passe sont valides
            if (email == "user@example.com" && password == "password123")
            {
                // Si l'utilisateur est validé, ouvrir la fenêtre principale du jeu
                var mainWindow = new MainWindow();  // Tu devrais déjà avoir un MainWindow créé
                mainWindow.Show();
                this.Close();  // Fermer la fenêtre de connexion
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

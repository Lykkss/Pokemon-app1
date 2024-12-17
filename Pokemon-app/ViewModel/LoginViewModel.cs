using System.Windows;
using System.Windows.Input;
using Pokemon_app.Commands;
using Pokemon_app.Data;
using Pokemon_app.Helpers;
using Pokemon_app.Views; // Ajout de l'espace de noms manquant

namespace Pokemon_app.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            // Initialiser la commande de connexion
            LoginCommand = new RelayCommand(Login);
        }

        // Méthode pour se connecter
        private void Login(object parameter)
        {
            using (var context = new PokemonLikeContext())  // Utilise AppDbContext si nécessaire
            {
                // Hacher le mot de passe saisi
                var hashedPassword = PasswordHelper.HashPassword(Password);

                // Vérifier si l'utilisateur existe dans la base de données avec le mot de passe haché
                var user = context.Logins
                    .FirstOrDefault(u => u.Username == Username && u.PasswordHash == hashedPassword);

                if (user != null)
                {
                    // Connexion réussie, ouvrir la fenêtre principale
                    OnLoginSuccess();
                }
                else
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Méthode pour gérer le succès de la connexion
        private void OnLoginSuccess()
        {
            // Créer une instance de la fenêtre principale et l'afficher
            var mainWindow = new MainWindow();  // Ou l'autre fenêtre principale de ton jeu
            mainWindow.Show();

            // Fermer la fenêtre de connexion après la connexion réussie
            var loginWindow = Application.Current.Windows.OfType<Login>().FirstOrDefault();
            loginWindow?.Close();
        }
    }
}

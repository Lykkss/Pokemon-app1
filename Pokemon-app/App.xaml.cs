using System.Windows;

namespace Pokemon_app
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Lancer la fenêtre Login au démarrage
            var loginWindow = new Views.Login();
            loginWindow.Show();
        }
    }
}

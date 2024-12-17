using System.Windows.Controls;
using System.Windows.Input;
using Pokemon_app.Commands;
using Pokemon_app.Views;

namespace Pokemon_app.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private object _selectedTabContent;
        public object SelectedTabContent
        {
            get => _selectedTabContent;
            set
            {
                _selectedTabContent = value;
                OnPropertyChanged();  // Notifie la vue lorsque le contenu change
            }
        }

        private object _selectedTab;
        public object SelectedTab
        {
            get => _selectedTab;
            set
            {
                _selectedTab = value;
                OnPropertyChanged();
                UpdateTabContent();  // Met à jour le contenu en fonction de l'onglet sélectionné
            }
        }

        public string HomeMessage { get; set; } = "Bienvenue sur la page d'accueil !";
        public string MonstersMessage { get; set; } = "Gérez vos monstres ici.";
        public string CombatMessage { get; set; } = "Affrontez vos ennemis dans cette section.";
        public string SettingsMessage { get; set; } = "Modifiez vos paramètres ici.";

        public MainWindowViewModel()
        {
            // Définir le contenu par défaut de l'onglet
            SelectedTabContent = new Home();
        }

        private void UpdateTabContent()
        {
            // Met à jour le contenu en fonction de l'onglet sélectionné
            if (SelectedTab is TabItem selectedTab)
            {
                switch (selectedTab.Header.ToString())
                {
                    case "Accueil":
                        SelectedTabContent = new Home();  // Assurez-vous que cette vue existe
                        break;
                    case "Monstres":
                        SelectedTabContent = new MonsterView();  // Assurez-vous que cette vue existe
                        break;
                    case "Combat":
                        SelectedTabContent = new Combat();  // Assurez-vous que cette vue existe
                        break;
                    case "Paramètres":
                        SelectedTabContent = new Setting();  // Assurez-vous que cette vue existe
                        break;
                }
            }
        }
    }
}

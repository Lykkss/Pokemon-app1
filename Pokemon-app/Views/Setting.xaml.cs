using System.Windows;
using Pokemon_app.ViewModel;

namespace Pokemon_app.Views
{
    /// <summary>
    /// Logique d'interaction pour Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel();  // Lier le SettingsViewModel à la vue
        }
    }
}

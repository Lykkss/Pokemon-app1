using System.Windows;
using Pokemon_app.ViewModel;

namespace Pokemon_app.Views
{
    /// <summary>
    /// Logique d'interaction pour Combat.xaml
    /// </summary>
    public partial class Combat : Window
    {
        public Combat()
        {
            InitializeComponent();
            DataContext = new CombatViewModel();
        }
    }
}

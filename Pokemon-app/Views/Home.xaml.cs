using System.Windows;
using Pokemon_app.ViewModel;

namespace Pokemon_app.Views
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }
    }
}

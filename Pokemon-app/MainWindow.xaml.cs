using System.Windows;
using Pokemon_app.ViewModel;

namespace Pokemon_app.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(); // Lier le ViewModel
        }
    }
}

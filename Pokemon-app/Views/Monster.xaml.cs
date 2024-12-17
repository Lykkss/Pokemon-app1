using System.Windows;
using System.Windows.Controls;
using Pokemon_app.ViewModel;

namespace Pokemon_app.Views
{
    public partial class Monster : Window
    {
        public Monster()
        {
            InitializeComponent();
            DataContext = new MonsterViewModel();  // Lier le ViewModel
        }

        // Gestion de la sélection d'un monstre
        private void OnMonsterSelected(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedMonster = listBox?.SelectedItem as Monster;

            if (selectedMonster != null)
            {
                // Logique à exécuter quand un monstre est sélectionné
                MessageBox.Show($"Monstre sélectionné : {selectedMonster.Name}");
            }

            // Ouvrir la vue de combat
            var combatView = new Combat();
            combatView.Show();
        }

    }
}

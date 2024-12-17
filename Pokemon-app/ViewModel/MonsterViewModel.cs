using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Pokemon_app.Commands;

namespace Pokemon_app.ViewModel
{
    public class MonsterViewModel : BaseViewModel
    {
        public ObservableCollection<Monster> Monsters { get; set; }

        private Monster _selectedMonster;
        public Monster SelectedMonster
        {
            get => _selectedMonster;
            set
            {
                _selectedMonster = value;
                OnPropertyChanged(); // Mettre à jour la vue avec le monstre sélectionné
            }
        }

        public ICommand SelectMonsterCommand { get; }

        public string Title { get; set; } = "Gestion des monstres";

        public MonsterViewModel()
        {
            // Ajout de quelques monstres à la liste
            Monsters = new ObservableCollection<Monster>
            {
                new Monster { Name = "Pikachu", Health = 100 },
                new Monster { Name = "Bulbasaur", Health = 80 },
                new Monster { Name = "Charmander", Health = 90 },
                new Monster { Name = "Squirtle", Health = 85 }
            };

            SelectMonsterCommand = new RelayCommand(SelectMonster);
        }

        // Logique pour la sélection d'un monstre
        private void SelectMonster(object parameter)
        {
            var selectedMonster = parameter as Monster;
            if (selectedMonster != null)
            {
                SelectedMonster = selectedMonster; // Mettre à jour le monstre sélectionné
                MessageBox.Show($"Monstre sélectionné : {selectedMonster.Name}");
            }
        }
    }

    // Modèle de monstre
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
    }
}

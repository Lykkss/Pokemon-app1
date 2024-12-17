using System.IO;
using System.Windows.Input;
using Newtonsoft.Json;
using Pokemon_app.Commands;

namespace Pokemon_app.ViewModel
{
    public class CombatViewModel : BaseViewModel
    {
        public string Title { get; set; } = "Gestion des combats";
        private Monster _playerMonster;
        private Monster _enemyMonster;

        public Monster PlayerMonster
        {
            get => _playerMonster;
            set
            {
                _playerMonster = value;
                OnPropertyChanged(nameof(PlayerMonster));
            }
        }

        public Monster EnemyMonster
        {
            get => _enemyMonster;
            set
            {
                _enemyMonster = value;
                OnPropertyChanged(nameof(EnemyMonster));
            }
        }

        public ICommand AttackCommand { get; }
        public ICommand SaveGameCommand { get; }
        public ICommand LoadGameCommand { get; }

        private const string SaveFilePath = "Data/gameData.json";  // Dossier relatif dans le répertoire du projet

        public CombatViewModel()
        {
            // Initialisation des monstres
            PlayerMonster = new Monster { Name = "Pikachu", Health = 100 };
            EnemyMonster = new Monster { Name = "Charmander", Health = 90 };

            // Commandes
            AttackCommand = new RelayCommand(Attack, CanAttack);
            SaveGameCommand = new RelayCommand(SaveGame);
            LoadGameCommand = new RelayCommand(LoadGame);
        }

        private bool CanAttack(object parameter)
        {
            return PlayerMonster != null && EnemyMonster != null && EnemyMonster.Health > 0;
        }

        private void Attack(object parameter)
        {
            if (EnemyMonster != null && EnemyMonster.Health > 0)
            {
                // Sélectionner une attaque aléatoire
                var random = new Random();
                var attackType = random.Next(1, 4);  // Choisit une attaque entre 1 et 3

                int damage = 0;

                switch (attackType)
                {
                    case 1:
                        damage = 10;  // Attaque basique
                        break;
                    case 2:
                        damage = 20;  // Attaque spéciale
                        break;
                    case 3:
                        damage = 30;  // Attaque ultime
                        break;
                }

                EnemyMonster.Health -= damage;
                OnPropertyChanged(nameof(EnemyMonster));
            }
        }
        private void SaveGame(object parameter)
        {
            var gameData = new
            {
                PlayerMonster,
                EnemyMonster
            };

            var json = JsonConvert.SerializeObject(gameData, Formatting.Indented);
            File.WriteAllText(SaveFilePath, json);
        }

        private void LoadGame(object parameter)
        {
            if (File.Exists(SaveFilePath))
            {
                var json = File.ReadAllText(SaveFilePath);
                var gameData = JsonConvert.DeserializeObject<dynamic>(json);

                PlayerMonster = gameData.PlayerMonster.ToObject<Monster>();
                EnemyMonster = gameData.EnemyMonster.ToObject<Monster>();
            }
        }
    }
}




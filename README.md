Pokémon-Like Game

Bienvenue dans le projet Pokémon-Like Game, un jeu de gestion de monstres et de combats, inspiré de l'univers des Pokémon. Ce projet est une application WPF (Windows Presentation Foundation) développée en C# avec MVVM (Model-View-ViewModel) et Entity Framework pour la gestion des données de la base de données.

Table des matières
Description du projet
Prérequis
Installation
Structure du projet
Fonctionnalités
Technologies utilisées
Contribuer
Description du projet

Le projet Pokémon-Like Game permet de :

Gestion des Monstres : Afficher une liste de monstres, les sélectionner et afficher leurs détails (nom, points de vie, sorts associés).
Gestion des Combats : Simuler des combats entre un monstre du joueur et un monstre ennemi. Le joueur peut attaquer, infliger des dégâts, et gagner des combats.
Vue des Sorts : Visualiser les sorts des monstres et gérer le tri des sorts selon les monstres qui les possèdent.
Système de Sauvegarde et Chargement : Sauvegarder et charger l'état du jeu pour permettre à l'utilisateur de reprendre sa partie.
L'application utilise une base de données SQL Server pour stocker les informations des utilisateurs, des monstres, des sorts, et des joueurs.

Prérequis
Avant de pouvoir exécuter l'application, vous devez avoir installé les éléments suivants :

Visual Studio avec le .NET SDK installé (version 8.0 ou supérieure).
SQL Server ou SQL Server Express pour héberger la base de données.
Une connexion Internet pour télécharger les dépendances via NuGet.
Installation
Suivez ces étapes pour configurer le projet sur votre machine locale :

1. Cloner le projet

git clone https://github.com/ton-projet/Pokemon-Like-Game.git
2. Installer les dépendances
Ouvrez le projet avec Visual Studio et assurez-vous que toutes les dépendances sont installées via NuGet. Si elles ne le sont pas, vous pouvez les installer en exécutant la commande suivante dans le Package Manager Console :

Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

3. Configurer la base de données
Créez une base de données SQL Server nommée ExerciceMonster.
Utilisez le script SQL suivant pour créer les tables nécessaires :

CREATE DATABASE ExerciceMonster;
GO

USE ExerciceMonster;
GO

-- Création de la table Login
CREATE TABLE Login (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL
);

-- Autres tables pour Player, Monster, Spell, etc. (voir le script complet dans le dossier `SQL`)
4. Configurer la chaîne de connexion
Dans le fichier App.config, modifiez la chaîne de connexion à la base de données pour correspondre à votre serveur SQL.

xml
Copier le code
<connectionStrings>
    <add name="PokemonLikeContext"
         connectionString="Server=YOUR_SERVER_NAME;Database=ExerciceMonster;Trusted_Connection=True;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>

5. Exécuter l'application
Une fois les étapes ci-dessus terminées, exécutez l'application en appuyant sur F5 ou en choisissant Start dans Visual Studio.

Structure du projet
L'architecture de l'application suit le modèle MVVM et est divisée en plusieurs dossiers :

vbnet
Copier le code
- Commands/           : Contient les commandes de l'application (RelayCommand).
- Data/               : Contient le contexte de la base de données et les modèles de données (PokemonLikeContext).
- Models/             : Contient les modèles de données (Monster, Spell, Player, etc.).
- Views/              : Contient les vues de l'application (MainWindow.xaml, Login.xaml, etc.).
- ViewModel/          : Contient les ViewModels (MainWindowViewModel, LoginViewModel, etc.).
- Helpers/            : Contient des classes d'assistance comme PasswordHelper pour le hachage des mots de passe.
- 
Fichiers principaux :
MainWindow.xaml : Vue principale affichant les différents onglets (Monstres, Combat, etc.).
Login.xaml : Fenêtre de connexion avec authentification des utilisateurs.
MonsterView.xaml : Vue de gestion des monstres, affichant la liste des monstres et leurs détails.
CombatView.xaml : Vue de combat, permettant au joueur de se battre contre un ennemi.
SettingsView.xaml : Vue pour modifier les paramètres du jeu.
Fonctionnalités

1. Page de Connexion
Les utilisateurs peuvent se connecter avec un nom d'utilisateur et un mot de passe stocké dans la base de données.
Une fois connecté, l'utilisateur est redirigé vers la page principale du jeu.
2. Page des Monstres
Affichage d'une liste de monstres.
Sélection d'un monstre et affichage de ses informations détaillées : points de vie, description, et sorts associés.
3. Page de Combat
Combat entre un monstre du joueur et un monstre ennemi.
Attaque d'un monstre, réduction de ses points de vie, et affichage des résultats du combat.
4. Page des Paramètres
Modifier les paramètres du jeu, tels que les options de gameplay.
5. Sauvegarde et Chargement
Sauvegarder et charger l'état du jeu, permettant au joueur de reprendre sa partie où il l'a laissée.
Technologies utilisées
C# : Langage principal pour l'application.
WPF : Pour le développement de l'interface graphique.
MVVM : Modèle architectural pour séparer la logique métier de l'interface utilisateur.
Entity Framework Core : Pour la gestion de la base de données.
SQL Server : Base de données pour stocker les informations des utilisateurs, monstres et combats.
Contribuer
Si vous souhaitez contribuer au projet, vous pouvez faire une pull request avec des modifications ou des améliorations. Assurez-vous que vos modifications sont testées et bien documentées.


using Microsoft.EntityFrameworkCore;
using Pokemon_app.Models;

namespace Pokemon_app.Data
{
    public class PokemonLikeContext : DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Spell> Spells { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Définir directement la chaîne de connexion ici
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5436SB6\SQLEXPRESS;Database=ExerciceMonster;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerMonster>().HasKey(pm => new { pm.PlayerID, pm.MonsterID });
        }
    }
}

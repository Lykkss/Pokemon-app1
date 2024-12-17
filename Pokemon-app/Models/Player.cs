using System.ComponentModel.DataAnnotations;

namespace Pokemon_app.Models
{
    public class Player
    {
        public int ID { get; set; }  // Identifiant unique

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int LoginID { get; set; }  // Clé étrangère pour lier le joueur à un utilisateur

        public Login Login { get; set; }  // Navigation vers le modèle Login
    }
}

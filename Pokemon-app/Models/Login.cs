using System.ComponentModel.DataAnnotations;



namespace Pokemon_app.Models
{
    public class Login
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }  // Le mot de passe haché
    }
}

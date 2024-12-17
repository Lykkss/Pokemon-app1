namespace Pokemon_app.Models
{
    public class Monster
    {
        public int ID { get; set; }  // Identifiant unique

        public string Name { get; set; }

        public int Health { get; set; }

        public string ImageURL { get; set; }  // URL de l'image (peut être null)
    }
}

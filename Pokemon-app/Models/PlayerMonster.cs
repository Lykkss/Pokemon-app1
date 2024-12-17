namespace Pokemon_app.Models
{
    public class PlayerMonster
    {
        public int PlayerID { get; set; }
        public Player Player { get; set; }

        public int MonsterID { get; set; }
        public Monster Monster { get; set; }
    }
}

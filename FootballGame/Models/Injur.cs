using System.ComponentModel.DataAnnotations;

namespace FootballGame.Models
{
    public class Injur
    {
        [Key]
        public int ID { set; get; }
        public DateTime date { set; get; }
        public DateTime RDate { set; get; }

        public ICollection<Player_inj> player_Injs { set; get; }

    }
}

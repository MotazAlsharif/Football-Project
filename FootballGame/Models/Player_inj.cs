using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballGame.Models
{
    public class Player_inj
    {
        [Key]
        public int ID { set; get; }
        [ForeignKey("PlayerID")]
        public Players player { set; get; }
        [ForeignKey("InjurID")]

        public Injur Injur { set; get; }
    }
}

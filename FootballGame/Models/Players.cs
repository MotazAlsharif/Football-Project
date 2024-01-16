using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballGame.Models
{
    public class Players
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public string name { set; get; }
        
        [Required]
        public string skilllevel { set; get; }

        [ForeignKey("TeamID")]
        public Teams teams { set; get; }

   

        public ICollection<Player_inj> player_Injs { set; get; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballGame.Models
{
    public class Teams_Users
    {
        [Key]
        public int ID { set; get; }

        [ForeignKey("UserID")]
        public User user { set; get; }

        [ForeignKey("TeamID")]
        public Teams team { set; get; }
    }
}

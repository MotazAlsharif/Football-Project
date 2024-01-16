using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballGame.Models
{
    [Index(nameof(Teams.name), IsUnique = true)]
    public class Teams
    {
        [Key]
        public int ID { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Must be insert")]
        public string name { set; get; }
        [Required(ErrorMessage = "Must be insert")]

        public string captain { set; get; }
        [Required(ErrorMessage = "Must be insert")]

        public string coach { set; get; }
        [Required(ErrorMessage = "Must be insert")]

        public int numberofPlayer { set; get; }


        [ForeignKey("AdminID")]
        public Admin Admin { get; set; }
 


        public ICollection<Players> players { set; get; }
        public ICollection<Teams_Users> teams_Users { set; get; }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace FootballGame.Models
{
    [Index(nameof(User.Username), IsUnique = true)]

    public class User
    {
        [Key]
        public int ID { set; get; }
        [Required(ErrorMessage ="Should Be insert")]
        [StringLength(50)]
        public string name { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Should Be insert")]
        public string password { set; get; }

        public ICollection<Teams_Users> teams_Users { set; get; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace FootballGame.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Please fill the username")]
        public string username { set; get; }
        [Required(ErrorMessage = "*")]

        public string password { set; get; }
    }
}

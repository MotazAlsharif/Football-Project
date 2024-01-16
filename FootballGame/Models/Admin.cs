using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FootballGame.Models
{
    [Index(nameof(Admin.username),IsUnique =true)]
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        public string name { set; get; }
        [Required]
        public string username { set; get; }
        [Required]
        public string password { set; get; }

        public ICollection<Teams> teams { set; get; }
    }
}

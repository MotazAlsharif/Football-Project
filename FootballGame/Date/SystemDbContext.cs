
using FootballGame.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballGame.Date
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> user { set; get; }
        public DbSet<Teams> teams { set; get; }
        public DbSet<Players> players { set; get; }

        public DbSet<Admin> admin { set; get; }
        public DbSet<Player_inj> player_Injs { set; get; }
        public DbSet<Teams_Users> teams_Users { set; get; }
        public DbSet<Injur> injurs { set; get; }



    }
}

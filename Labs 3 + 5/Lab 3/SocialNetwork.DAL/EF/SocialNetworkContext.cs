using Microsoft.EntityFrameworkCore;
using SocialNetwork.DAL.Models;

namespace SocialNetwork.DAL.EF
{
    public class SocialNetworkContext: DbContext
    {
        private string _file;
        public SocialNetworkContext(string file)
        {
            _file = file;
            Database.EnsureCreated();
        }
        public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options)
                 : base(options)
        {
            Database.EnsureCreated();
        }

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=" + _file + ".db");
        }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Network> Networks { get; set; }

        public DbSet<User> Users { get; set; }
    }
}

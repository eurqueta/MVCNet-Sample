using Microsoft.EntityFrameworkCore;

namespace MVCNet.Models
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        // DbSets para otros modelos...

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MiBaseDeDatos.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Profile)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.ProfileId);

            modelBuilder.Entity<Profile>()
                .HasKey(x => x.IdProfile);

            modelBuilder.Entity<Profile>()
                .HasData(new List<Profile>
                {
                    new Profile
                    {
                        IdProfile = 1,
                        Name = "Admin"
                    },
                    new Profile 
                    {
                        IdProfile = 2,
                        Name = "Developer"
                    }
                });
        }
    }

}

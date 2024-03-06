using Microsoft.EntityFrameworkCore;
using WholeSaler.Entity;

namespace WholeSaler.Context
{
    public class CoreContext : DbContext
    {
        private const string CONNECTION_STRING= "Server=(localdb)\\mssqllocaldb;Database=MyBoardsDb;Trusted_Connection=True;";
        public DbSet<Assortment> assortments {  get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Localisation> Localisations { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Palette> palettes { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<Transport> transports { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<Assortment>();
            modelBuilder.Entity<Localisation>();
            modelBuilder.Entity<Car>();
            modelBuilder.Entity<Palette>();
            modelBuilder.Entity<Transport>();

            modelBuilder.Entity<User>()
                .Property(user => user.Email).IsRequired();

            modelBuilder.Entity<Role>()
                .Property(role => role.RoleName).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using BotanikBambu.Models;
using System.Reflection;

namespace BotanikBambu.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Trucker> Truckers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Bambu> Bambus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

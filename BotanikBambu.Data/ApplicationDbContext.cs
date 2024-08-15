using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BotanikBambu.Models;
namespace BotanikBambu.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<BaseModel> BaseModel { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Trucker> Trucker { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Bambu> Bambus { get; set; }

    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    //  modelBuilder.ApplyConfiguration(new CityConfiguration());
    //    // modelBuilder.ApplyConfiguration(new GenderConfiguration());
    //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    //}

}


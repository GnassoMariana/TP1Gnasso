using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Data
{
    public class SportShoesDbContext: DbContext
    {
        public DbSet<SportShoe> SportShoes { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Size> Sizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .UseSqlServer("Data Source=.; Initial Catalog=SportShoes2026; Trusted_Connection=true; TrustServerCertificate=true;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SportShoesDbContext).Assembly);
            ///Desactivar borrado en cascada
            foreach (var fk in modelBuilder.Model
                 .GetEntityTypes()
                 .SelectMany(e => e.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }


        }


    }
}

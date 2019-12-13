using Microsoft.EntityFrameworkCore;
using Qualysoft.WebShop.ForKSB.Database.Configurations;
using Qualysoft.WebShop.ForKSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualysoft.WebShop.ForKSB.Database
{
    public class QualysoftContext : DbContext
    {
        public QualysoftContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=qualysoftWebShop;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        //when you run for the first time app, run in Package Manager Console Update-Database
        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<RelationProducts> Relations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new RelationsConfiguration());
        }
    }
}

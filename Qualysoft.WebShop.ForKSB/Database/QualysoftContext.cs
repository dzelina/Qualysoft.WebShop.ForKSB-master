using Microsoft.EntityFrameworkCore;
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

        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<RelationProducts> Relations { get; set; }
    }
}

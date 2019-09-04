using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualysoft.WebShop.ForKSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualysoft.WebShop.ForKSB.Database.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Password).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qualysoft.WebShop.ForKSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualysoft.WebShop.ForKSB.Database.Configurations
{
    public class RelationsConfiguration : IEntityTypeConfiguration<RelationProducts>
    {
        public void Configure(EntityTypeBuilder<RelationProducts> builder)
        {
            builder.Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Visitor).IsRequired();
        }
    }
}

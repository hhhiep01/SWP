using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasOne(c => c.UserAccount)
              .WithOne(u => u.Cart)
              .HasForeignKey<Cart>(c => c.UserId);

            builder.HasMany(x => x.CartItems)
               .WithOne(x => x.Cart)
               .HasForeignKey(x => x.CartId);
        }
    }
}

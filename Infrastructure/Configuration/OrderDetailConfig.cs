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
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasOne(x => x.Order)
                 .WithMany(x => x.OrderDetails)
                 .HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.Product)
                 .WithMany(x => x.OrderDetails)
                 .HasForeignKey(x => x.ProductId);
        }
    }
}

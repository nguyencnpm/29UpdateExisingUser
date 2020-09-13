using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();

            builder.Property(o => o.OrderDate);
            builder.Property(o => o.ShipEmail).IsUnicode(false).HasMaxLength(50);

            builder.Property(o => o.ShipAddress).IsRequired().HasMaxLength(200);
            builder.Property(o => o.ShipName).IsRequired().HasMaxLength(200);
            builder.Property(o => o.ShipPhoneNumber).IsRequired().HasMaxLength(200);

            builder.HasOne(o => o.AppUser).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);
        }
    }
}

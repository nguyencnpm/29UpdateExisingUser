using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(cart => cart.Id);

            builder.Property(cart => cart.Id).UseIdentityColumn();

            builder.HasOne(cart => cart.Product).WithMany(p => p.Carts).HasForeignKey(cart => cart.ProductId);
            builder.HasOne(cart => cart.AppUser).WithMany(u => u.Carts).HasForeignKey(cart => cart.UserId);
        }
    }
}

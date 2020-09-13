using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories");
            builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder.HasOne(pc => pc.Product).WithMany(p=>p.ProductInCategories).HasForeignKey(pc=>pc.ProductId);
            builder.HasOne(pc => pc.Category).WithMany(c => c.ProductInCategories).HasForeignKey(pc => pc.CategoryId);
        }
    }
}

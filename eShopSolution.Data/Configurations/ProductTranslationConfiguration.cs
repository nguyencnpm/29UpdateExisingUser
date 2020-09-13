using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("ProductTranslations");

            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.Id).UseIdentityColumn();

            builder.Property(pt => pt.Name).IsRequired().HasMaxLength(200);

            builder.Property(pt => pt.SeoAlias).IsRequired().HasMaxLength(200);

            builder.Property(pt => pt.Details).HasMaxLength(500);


            builder.Property(pt => pt.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(5);

            builder.HasOne(pt => pt.Language).WithMany(l => l.ProductTranslations).HasForeignKey(pt => pt.LanguageId);

            builder.HasOne(pt => pt.Product).WithMany(p => p.ProductTranslations).HasForeignKey(pt => pt.ProductId);

        }
    }
}

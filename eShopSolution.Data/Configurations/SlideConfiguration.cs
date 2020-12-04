using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).UseIdentityColumn();

            builder.Property(s => s.Name).HasMaxLength(200).IsRequired();

            builder.Property(s => s.Description).HasMaxLength(200).IsRequired();
            builder.Property(s => s.Url).HasMaxLength(200).IsRequired();
            builder.Property(s => s.Image).HasMaxLength(200).IsRequired();
        }
    }
}

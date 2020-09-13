using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Dob).IsRequired();

        }
    }
}

using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(cu => cu.Id);

            builder.Property(cu => cu.Id).UseIdentityColumn();

            builder.Property(cu => cu.Name).HasMaxLength(200).IsRequired();

            builder.Property(cu => cu.Email).HasMaxLength(200).IsRequired();
            builder.Property(cu => cu.PhoneNumber).HasMaxLength(200).IsRequired();
            builder.Property(cu => cu.Message).IsRequired();


        }
    }
}

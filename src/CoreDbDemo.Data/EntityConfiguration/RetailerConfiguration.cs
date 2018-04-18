using System;
using System.Collections.Generic;
using System.Text;
using CoreDbDemo.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreDbDemo.Data.EntityConfiguration
{
    public class RetailerConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            //EF Core reference for fluentAPI:  http://ef.readthedocs.io/en/latest/entity-framework/core/modeling/keys.html
            //fluentAPI reference:  http://ef.readthedocs.io/en/latest/entity-framework/core/modeling/relationships.html

            // ENSURE THAT this configuration is registered in CoreDbDemo.Data.Context/CoreDbDemoContext/OnModelCreating

            modelBuilder.Entity<Retailer>(x =>
                {
                    // Relationships

                    x.HasKey(y => y.Id);
                    x.HasMany(y => y.StaffMembers)
                        .WithOne(y => y.Retailer)
                        // if a retailer is deleted, then dependant staff members can't exist without a parent retailer.
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();


                    // Base Entity Common Properties

                    x.Property(y => y.Id)
                        .IsRequired();

                    x.Property(y => y.Created)
                        .IsRequired();

                    // Properties

                    x.Property(y => y.Address1)
                        .IsRequired()
                        .HasMaxLength(200);

                    x.Property(y => y.Address2)
                        .HasMaxLength(200);

                    x.Property(y => y.Address3)
                        .HasMaxLength(200);

                    x.Property(y => y.Town)
                        .IsRequired()
                        .HasMaxLength(200);

                    x.Property(y => y.County)
                        .HasMaxLength(100);
                }
            );
        }
    }
}
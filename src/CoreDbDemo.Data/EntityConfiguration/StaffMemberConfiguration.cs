using System;
using System.Collections.Generic;
using System.Text;
using CoreDbDemo.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreDbDemo.Data.EntityConfiguration
{
    public class StaffMemberConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            //EF Core reference for fluentAPI:  http://ef.readthedocs.io/en/latest/entity-framework/core/modeling/keys.html
            //fluentAPI reference:  http://ef.readthedocs.io/en/latest/entity-framework/core/modeling/relationships.html

            // ENSURE THAT this configuration is registered in CoreDbDemo.Data.Context/CoreDbDemoContext/OnModelCreating

            modelBuilder.Entity<StaffMember>(x =>
                {
                    // Relationships

                    x.HasKey(y => y.Id);

                    x.HasMany(y => y.Requests)
                        .WithOne(y => y.StaffMember);

                    x.HasOne(y => y.Retailer);


                    // Base Entity Common Properties

                    x.Property(y => y.Id)
                        .IsRequired();

                    x.Property(y => y.Created)
                        .IsRequired();

                    x.Property(y => y.Modified)
                        .IsRequired();

                    // Properties

                    x.Property(y => y.Firstname)
                        .IsRequired()
                        .HasMaxLength(100);
                }
            );
        }
    }
}

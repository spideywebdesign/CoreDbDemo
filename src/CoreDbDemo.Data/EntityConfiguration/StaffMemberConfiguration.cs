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
                        .WithOne(y => y.StaffMember)
                        .IsRequired();

                    x.HasOne(y => y.Retailer)
                        .WithMany(y => y.StaffMembers)
                        .IsRequired();


                    // Base Entity Common Properties
                    // If using a common model everywhere, does it make more sense to add required & max length etc. at model level as attributes?
                    // Else we have to re-define these attributes in more than one place..

                    x.Property(y => y.Id)
                        .IsRequired();

                    x.Property(y => y.Created)
                        .IsRequired();

                    // Properties

                    x.Property(y => y.Firstname)
                        .IsRequired()
                        .HasMaxLength(100);

                    x.Property(y => y.Surname)
                        .IsRequired()
                        .HasMaxLength(100);

                    x.Property(y => y.Email)
                        .IsRequired()
                        .HasMaxLength(255);
                }
            );
        }
    }
}

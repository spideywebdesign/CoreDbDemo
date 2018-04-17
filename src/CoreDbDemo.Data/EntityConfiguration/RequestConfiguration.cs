using System;
using System.Collections.Generic;
using System.Text;
using CoreDbDemo.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreDbDemo.Data.EntityConfiguration
{
    public class RequestConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            //EF Core reference for fluentAPI:  http://ef.readthedocs.io/en/latest/entity-framework/core/modeling/keys.html
            //fluentAPI reference:  http://ef.readthedocs.io/en/latest/entity-framework/core/modeling/relationships.html

            // ENSURE THAT this configuration is registered in CoreDbDemo.Data.Context/CoreDbDemoContext/OnModelCreating

            modelBuilder.Entity<Request>(x =>
            {
                // Relationships

                x.HasKey(y => y.Id);

                x.HasOne(y => y.StaffMember)
                    .WithMany(y => y.Requests)
                    .IsRequired();

                x.HasOne(y => y.ExternalSystem)
                    .WithMany(y => y.Requests)
                    // We don't want all requests to be deleted if a system is removed do we?
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                // Base Entity Common Properties

                x.Property(y => y.Id)
                    .IsRequired();

                x.Property(y => y.Created)
                    .IsRequired();
            });
        }
    }
}
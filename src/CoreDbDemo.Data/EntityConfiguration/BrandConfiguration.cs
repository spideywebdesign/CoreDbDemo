﻿using Microsoft.EntityFrameworkCore;

namespace CoreDbDemo.Data.EntityConfiguration
{
    public class BrandConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            //EF Core reference for fluentAPI:  http://ef.readthedocs.io/en/latest/entity-framework/core/modeling/keys.html
            //fluentAPI reference:  http://ef.readthedocs.io/en/latest/entity-framework/core/modeling/relationships.html

            // ENSURE THAT this configuration is registered in CoreDbDemo.Data.Context/CoreDbDemoContext/OnModelCreating

            modelBuilder.Entity<Model.Entity.BrandDbo>(x =>
            {
                // Relationships

                x.HasKey(y => y.Id);


                // Base Entity Common Properties

                x.Property(y => y.Id)
                    .IsRequired();

                x.Property(y => y.Created)
                    .IsRequired();
            });
        }
    }
}
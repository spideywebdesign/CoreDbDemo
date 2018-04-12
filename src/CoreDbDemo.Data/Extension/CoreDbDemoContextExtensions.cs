using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CoreDbDemo.Data.Helpers;
using CoreDbDemo.Data.Context;

namespace CoreDbDemo.Data.Extension
{
    public static class CoreDbDemoContextExtensions
    {
        public static int EnsureSeedData(this CoreDbDemoContext context)
        {
            var retailerCount = default(int);
            var staffMemberCount = default(int);

            // Because each of the following seed method needs to do a save
            // (the data they're importing is relational), we need to call
            // SaveAsync within each method.
            // So let's keep tabs on the counts as they come back

            var dbSeeder = new DatabaseSeeder(context);
            if (!context.Retailers.Any())
            {
                var pathToSeedData = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "RetailerSeedData.json");
                retailerCount = dbSeeder.SeedRetailerEntitiesFromJson(pathToSeedData).Result;
            }

            return retailerCount;
        }
    }
}

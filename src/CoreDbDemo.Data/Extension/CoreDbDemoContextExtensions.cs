using System.IO;
using System.Linq;
using CoreDbDemo.Data.Helpers;
using CoreDbDemo.Data.Context;

namespace CoreDbDemo.Data.Extension
{
    /// <summary>
    /// Extension of db context so we can easily seed data
    /// </summary>
    public static class CoreDbDemoContextExtensions
    {
        public static int EnsureSeedData(this CoreDbDemoContext context)
        {
            var systemCount = default(int);
            var retailerCount = default(int);

            // Because each of the following seed method needs to do a save
            // (the data they're importing is relational), we need to call
            // SaveAsync within each method.
            // So let's keep tabs on the counts as they come back

            var dbSeeder = new DatabaseSeeder(context);
            if (!context.ExternalSystems.Any())
            {
                var pathToSeedData = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "SystemSeedData.json");
                systemCount = dbSeeder.SeedSystemEntitiesFromJson(pathToSeedData).Result;
            }
            if (!context.Retailers.Any())
            {
                var pathToSeedData = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "RetailerSeedData.json");
                retailerCount = dbSeeder.SeedRetailerEntitiesFromJson(pathToSeedData).Result;
            }

            return retailerCount + systemCount;
        }
    }
}

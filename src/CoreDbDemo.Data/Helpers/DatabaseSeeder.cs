using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CoreDbDemo.Data.Context;
using CoreDbDemo.Model.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoreDbDemo.Data.Helpers
{
    public class DatabaseSeeder
    {
        private readonly CoreDbDemoContext _context;
        public DatabaseSeeder(CoreDbDemoContext context)
        {
            _context = context;
        }

        public async Task<int> SeedRetailerEntitiesFromJson(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException($"Value of {filePath} must be supplied to {nameof(SeedRetailerEntitiesFromJson)}");
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"The file '{filePath}' does not exist");
            }

            var dataSet = File.ReadAllText(filePath);
            var seedData = JsonConvert.DeserializeObject<List<Retailer>>(dataSet, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

            _context.Retailers.AddRange(seedData);

            return await _context.SaveChangesAsync();
        }
    }
}

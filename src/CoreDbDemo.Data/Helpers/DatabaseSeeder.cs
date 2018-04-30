﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CoreDbDemo.Data.Context;
using CoreDbDemo.Model.Entity;
using Microsoft.EntityFrameworkCore;
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
            var seedData = JsonConvert.DeserializeObject<List<RetailerDbo>>(dataSet, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            // When seeding objects with links to a reference table, we need to ensure we can pass in just the id of the referenced table (in this instance: ExternalSystemId)
            // Creating an object of the referenced entity will unsurprisingly create a new record in the database, breaking our intended references.

            _context.Retailers.AddRange(seedData);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> SeedSystemEntitiesFromJson(string filePath)
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
            var seedData = JsonConvert.DeserializeObject<List<ExternalSystemDbo>>(dataSet);

            _context.ExternalSystems.AddRange(seedData);

            // As we are seeding some reference data, lets turn on Identity insert, else we would have to continually update the seed data referencing this table.
            _context.Database.OpenConnection();
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.[ExternalSystems] ON");

            var resultsCount = await _context.SaveChangesAsync();
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.[ExternalSystems] OFF");
            return resultsCount;
        }
    }
}

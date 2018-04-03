using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CoreDbDemo.Data.Context
{
    // required when local database does not exist or was deleted
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoreDbDemoContext>
    {
        public CoreDbDemoContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CoreDbDemoContext>();
            var connectionString = configuration.GetConnectionString("CoreDbDemoDB");
            builder.UseSqlServer(connectionString);
            return new CoreDbDemoContext(builder.Options);
        }
    }
}

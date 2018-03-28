using System;
using System.Collections.Generic;
using System.Text;
using CoreDbDemo.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreDbDemo.Data
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("CoreDbDemoDB");
            services.AddDbContext<CoreDbDemoContext>(options => options.UseSqlServer(connection));
        }
    }
}
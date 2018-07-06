using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDbDemo.API.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CoreDbDemo.Data.Extension;
using CoreDbDemo.Data.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CoreDbDemo.API.Mappers;
using CoreDbDemo.Strategy.Interfaces;
using CoreDbDemo.Strategy;
using CoreDbDemo.Repository.Interfaces;
using CoreDbDemo.Repository;
using NLog.Extensions.Logging;
using NLog.Web;

namespace CoreDbDemo.API
{
    public class Startup
    {
        private MapperConfiguration MapperConfiguration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Error;
                })
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            var connection = Configuration.GetConnectionString("CoreDbDemoDB");
            services.AddDbContext<CoreDbDemoContext>(options => options.UseSqlServer(connection));

            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityMapperConfig());
            });

            // Add our mappers
            services.AddScoped(sp => MapperConfiguration.CreateMapper());

            // Add our strategies
            services.AddScoped<IRetailerStrategy, RetailerStrategy>();
            services.AddScoped<IStaffMemberStrategy, StaffMemberStrategy>();
            services.AddScoped<IExternalSystemStrategy, ExternalSystemStrategy>();
            services.AddScoped<IRequestStrategy, RequestStrategy>();
            services.AddScoped<IBrandStrategy, BrandStrategy>();
            services.AddScoped<IAreaManagerStrategy, AreaManagerStrategy>();

            // Add our repositories
            services.AddScoped<IRetailerRepository, RetailerRepository>();
            services.AddScoped<IStaffMemberRepository, StaffMemberRepository>();
            services.AddScoped<IExternalSystemRepository, ExternalSystemRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IAreaManagerRepository, AreaManagerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddNLog();
            loggerFactory.AddAzureWebAppDiagnostics();
            // 4/7/2018: Nlog not currently working on core 2.1
            //app.AddNLogWeb();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.EnsureDatabaseIsSeeded(false).GetAwaiter().GetResult();
            }

            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}

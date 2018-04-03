using CoreDbDemo.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDbDemo.API.Extension
{
    /// <summary>
    /// This class is based on some of the suggestions bty K. Scott Allen in
    /// his NDC 2017 talk https://www.youtube.com/watch?v=6Fi5dRVxOvc
    /// </summary>
    public static class ConfigureHttpPipelineExtensions
    {
        public static int EnsureDatabaeIsSeeded(this IApplicationBuilder applicationBuilder, bool autoMigrateDatabase)
        {
            using (var erviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = IServiceScope.ServiceProvider.GetService<CoreDbDemoContext>();
                if(autoMigrateDatabase)
                {
                    //context.Database.Migrate();
                }
                return context.EnsureSeedData();
            }
        }
    }
}

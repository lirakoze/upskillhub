using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTreeMVCWebApplication.Extensions
{
    public static class MigrationExtension
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder, int? retry = 0) where TContext : DbContext
        {
            int retryForAvailability = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();
                var logger = services.GetRequiredService<ILogger<TContext>>();
                try
                {
                    logger.LogInformation($"Migrating SQL Database With Context Name {typeof(TContext).Name}");
                    InvokeSeeder(seeder, context, services);

                    logger.LogInformation($"Migrated SQL Database With Context Name {typeof(TContext).Name}");


                }
                catch (SqlException ex)
                {

                    logger.LogInformation($"An Error Occured while Migrating the SQL Server Database used on {typeof(TContext).Name}");
                    logger.LogInformation($"ERROR MSG: {ex.Message} \n\n");
                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, seeder, retryForAvailability);
                    }
                }
                return host;
            }

        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services) where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }
}

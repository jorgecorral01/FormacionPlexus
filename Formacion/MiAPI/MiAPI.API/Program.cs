using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using MiAPI.Migrations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MiAPI.API {
    public class Program {
        public static void Main(string[] args) {
            try {

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddEnvironmentVariables()
                    .AddJsonFile("appsettings.json", optional: false)
                    //.AddUserSecrets<Startup>()
                    .Build();

                ApplyMigrations(configuration);

                CreateWebHostBuilder(args).Build().Run();

            }
            catch(Exception e) {
                Console.WriteLine(e);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        private static void ApplyMigrations(IConfigurationRoot configuration) {
            var serviceProvider = CreateMigrationServices(configuration.GetConnectionString("SqlFormacion"));

            try {


                using(var scope = serviceProvider.CreateScope())
                    scope.ServiceProvider
                        .GetRequiredService<IMigrationRunner>()
                    .MigrateUp();
            }
            catch(Exception e) {
                Console.WriteLine(e);
            }
        }

        private static IServiceProvider CreateMigrationServices(string connectionString) =>
        new ServiceCollection()
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
        .AddSqlServer()
        .WithGlobalConnectionString(connectionString)
        .ScanIn(typeof(MigrationsLocator).Assembly).For.Migrations())
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        .BuildServiceProvider(false);
    }
}
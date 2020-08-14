using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using FluentMigrator.Runner;
using MiAPI.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MiAPI.Infrastucture.SqlMigrations.Test {

    public class SqlTest {
        public static readonly string ConnectionString;

        static SqlTest() {
            var localPath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(localPath)
                //.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            ConnectionString = configuration.GetConnectionString("SqlFormacion");

            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new Exception("The connection string has been lost");
            }
            LaunchMigrations();
        }

        private static void LaunchMigrations() {
            var serviceProvider = new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(ConnectionString)
                    .ScanIn(typeof(MigrationsLocator).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
            using(var scope = serviceProvider.CreateScope())
                scope.ServiceProvider
                    .GetRequiredService<IMigrationRunner>()
                    .MigrateUp();
        }
    }
}

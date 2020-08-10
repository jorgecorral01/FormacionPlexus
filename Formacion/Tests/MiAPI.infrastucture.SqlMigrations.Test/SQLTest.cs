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
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            ConnectionString = configuration.GetConnectionString("SqlFormacion");
            //ConnectionString =
            //    "Persist Security Info = False; Integrated Security = false; database = VideoClub; server =.\\Formacion; User ID = Formacion; pwd = Pruebas2019..";

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

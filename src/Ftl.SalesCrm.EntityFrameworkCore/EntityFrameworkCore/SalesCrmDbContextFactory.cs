using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ftl.SalesCrm.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SalesCrmDbContextFactory : IDesignTimeDbContextFactory<SalesCrmDbContext>
{
    public SalesCrmDbContext CreateDbContext(string[] args)
    {
        SalesCrmEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SalesCrmDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new SalesCrmDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Ftl.SalesCrm.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}

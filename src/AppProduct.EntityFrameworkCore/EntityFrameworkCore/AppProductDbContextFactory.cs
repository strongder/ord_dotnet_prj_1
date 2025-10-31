using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AppProduct.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AppProductDbContextFactory : IDesignTimeDbContextFactory<AppProductDbContext>
{
    public AppProductDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        AppProductEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<AppProductDbContext>()
            .UseMySQL(configuration.GetConnectionString("Default"));
        
        return new AppProductDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AppProduct.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}

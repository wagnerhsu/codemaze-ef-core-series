using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WindowsServiceDemo.Models
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        var _configuration = BuildConfiguration();
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        return new AppDbContext(optionsBuilder.Options);

        IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
}
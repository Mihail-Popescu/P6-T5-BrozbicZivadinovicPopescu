using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProiectOBS.Data
{
    public class ProiectOBSDbContextFactory : IDesignTimeDbContextFactory<ProiectOBSDbContext>
    {
        public ProiectOBSDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ProiectOBSDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ProiectOBSDbContext"));

            return new ProiectOBSDbContext(optionsBuilder.Options, configuration);
        }
    }
}
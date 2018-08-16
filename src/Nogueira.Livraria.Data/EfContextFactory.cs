using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Nogueira.Livraria.Data
{
    public class EfContextFactory : IDesignTimeDbContextFactory<EfContext>
    {
        public EfContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EfContext>();

            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("Livraria"));

            return new EfContext(optionsBuilder.Options);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PierrsTreatFlavor.Models
{
  public class TreatFlavorContextFactory : IDesignTimeDbContextFactory<TreatFlavorContextDB>
  {

    TreatFlavorContextDB IDesignTimeDbContextFactory<TreatFlavorContextDB>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<TreatFlavorContextDB>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new TreatFlavorContextDB(builder.Options);
    }
  }
}
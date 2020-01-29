using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace PierrsTreatFlavor.Models
{
    public class TreatFlavorContextDB
    {
        public virtual DbSet<Treat> Treats {get;set;}
        public DbSet<Flavor> Flavors {get;set;}
        public DbSet<TreatFlavor> TreatFlavors {get;set;}
        public TreatFlavorContextDB(DbContextOption options):base(options){}
    }
}
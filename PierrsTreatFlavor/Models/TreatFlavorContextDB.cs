using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace PierrsTreatFlavor.Models
{
    public class TreatFlavorContextDB: IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Treat> Treats {get;set;}
        public DbSet<Flavor> Flavors {get;set;}
        public DbSet<TreatFlavor> TreatFlavors {get;set;}
        public TreatFlavorContextDB(DbContextOptions options):base(options)
        {

        }
    }
}
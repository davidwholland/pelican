using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Pelican.Models
{
    public class PelicanContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }

        public PelicanContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
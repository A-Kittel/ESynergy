using System.Data.Entity;
using ESynergy.Migrations;
using ESynergy.Model;

namespace ESynergy
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("name=ProductContext")
        {
            Database.SetInitializer<ProductContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductContext, Configuration>());
        }
        public DbSet<Product> Products { set; get; }
    }
}
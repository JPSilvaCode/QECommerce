using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace QECommerce.Models
{
    public class QECommerceContext : DbContext
    {
        public QECommerceContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<QECommerce.Models.Departaments> Departaments { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.City> Cities { get; set; }

        //DESABILITAR CASCATAS
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<QECommerce.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.Tax> Taxes { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.WareHouse> WareHouses { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.Inventory> Inventories { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.State> States { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.Orders> Orders { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.OrderDetails> OrderDetail { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.OrderDetailTmp> OrderDetailTmp { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.CompanyCustomer> CompanyCustomers { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.Provider> Providers { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.CompanyProvider> CompanyProviders { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.Purchase> Purchase { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.PurchaseDetails> PurchaseDetails { get; set; }

        public System.Data.Entity.DbSet<QECommerce.Models.PurchaseDetailTmp> PurchaseDetailTmps { get; set; }
    }
}
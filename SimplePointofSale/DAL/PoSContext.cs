using SimplePointofSale.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace SimplePointofSale.DAL
{
    public class PoSContext : DbContext
    {
        public PoSContext() : base("PoSContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
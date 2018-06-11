using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace J_Market.Models
{
    public class J_MarketContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public J_MarketContext() : base("name=J_MarketContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // no me permite borrar en cascada
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public System.Data.Entity.DbSet<J_Market.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<J_Market.Models.DocumentType> DocumentTypes { get; set; }

        public System.Data.Entity.DbSet<J_Market.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<J_Market.Models.SupplierProduct> SupplierProducts { get; set; }

        public System.Data.Entity.DbSet<J_Market.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<J_Market.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<J_Market.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<J_Market.Models.OrderDetail> orderDetails { get; set; }

        public System.Data.Entity.DbSet<J_Market.Models.Category> Categories { get; set; }
    }
}

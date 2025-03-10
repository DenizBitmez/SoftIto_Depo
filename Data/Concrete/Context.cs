using Entity;
using Entity.Concrete1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class Context:DbContext
    {
       public DbSet<User> Users {  get; set; }

       public DbSet<Supplier> Supplies { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<StockDetails> StockDetails { get; set; }

        public DbSet<Barcode> Barcodes { get; set; }
    }
}

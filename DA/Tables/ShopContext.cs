using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Tables
{
    public class ShopContext : DbContext
    {
        public ShopContext()
            //:base("Shop")
        {
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Product> Products { get; set; }
    }
}

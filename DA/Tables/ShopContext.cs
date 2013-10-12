using ApiSample.Utility.Hooks.Audit;
using EFHooks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Tables
{
    public class ShopContext : HookedDbContext, IAuditableContext
    {
        /// <summary>
        /// For update-database by package management console
        /// </summary>
        public ShopContext()
        {
        }

        /// <summary>
        /// For runtime
        /// </summary>
        /// <param name="hooks"></param>
        public ShopContext(IEnumerable<IPreActionHook> hooks)
        {
            foreach (var hook in hooks)
            {
                this.RegisterHook(hook);
            }
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Gift> Gifts { get; set; }

        public IDbSet<AuditLog> AuditLogs { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Group> Groups { get; set; }
    }
}

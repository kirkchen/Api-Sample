using ApiSample.DA.Interfaces;
using ApiSample.DA.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSample.Utility.Hooks.ValidFlag;

namespace ApiSample.DA.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public ShopContext ShopContext { get; set; }

        public CategoryRepository(ShopContext context)
        {
            this.ShopContext = context;
        }

        public bool IsCategoryExist(int categoryId)
        {
            var isExist = this.ShopContext.Categories.Valids()
                                                     .Any(i => i.Id == categoryId);

            return isExist;
        }
    }
}

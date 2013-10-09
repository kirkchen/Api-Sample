using ApiSample.Models;
using ApiSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductForCategoryModel> GetProductByCategoryId(int categoryId);

        void InsertProduct(InsertProductModel insertProductModel);
    }
}

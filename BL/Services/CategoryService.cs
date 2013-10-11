using ApiSample.BL.Interfaces;
using ApiSample.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Services
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository CategoryRepository { get; set; }

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.CategoryRepository = categoryRepository;
        }

        public bool IsCategoryExist(int categoryId)
        {
            return this.CategoryRepository.IsCategoryExist(categoryId);
        }
    }
}

using ApiSample.BL.Interfaces;
using ApiSample.DA.Interfaces;
using ApiSample.Models;
using ApiSample.Utility.Extensions.Aop;
using ApiSample.ViewModels;
using Autofac.Extras.DynamicProxy2;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Services
{
    //[Intercept("RequireAdmin")]
    //[Intercept(typeof(LogInterceptor))]        
    public class ProductService : IProductService
    {
        public IProductRepository ProductRepository { get; set; }

        public ProductService(IProductRepository productRepository)
        {
            this.ProductRepository = productRepository;
        }
        
        public IEnumerable<ProductForCategoryModel> GetProductByCategoryId(int categoryId)
        {
            return this.ProductRepository.GetProductByCategoryId(categoryId);
        }

        public void InsertProduct(InsertProductModel insertProductModel)
        {
            var productModel = Mapper.Map<ProductModel>(insertProductModel);                       

            this.ProductRepository.InsertProduct(productModel);
        }
    }
}

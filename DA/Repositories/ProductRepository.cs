using ApiSample.DA.Interfaces;
using ApiSample.DA.Tables;
using ApiSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSample.Utility.Hooks.ValidFlag;
using AutoMapper;

namespace ApiSample.DA.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ShopContext ShopContext { get; set; }

        public ProductRepository(ShopContext context)
        {
            this.ShopContext = context;
        }

        public IEnumerable<ProductForCategoryModel> GetProductByCategoryId(int categoryId)
        {
            var result = this.ShopContext.Products
                                         .Valids()
                                         .Where(i => i.ListingStartTime < DateTime.Now &&
                                                     i.ListingEndTime >= DateTime.Now &&
                                                     i.Category.Id == categoryId)
                                         .Select(i => new ProductForCategoryModel()
                                         {
                                             Id = i.Id,
                                             Name = i.Name,
                                             Price = i.Price
                                         });

            return result;
        }

        public void InsertProduct(ProductModel productModel)
        {
            var prodcut = Mapper.Map<Product>(productModel);
            prodcut.Gifts = Mapper.Map<List<Gift>>(productModel.Gifts);

            //var prodcut = new Product();
            //prodcut.Name = productModel.Name;
            //prodcut.Price = productModel.Price;
            //prodcut.Cost = productModel.Cost;
            //prodcut.Description = productModel.Description;
            //prodcut.ListingStartTime = productModel.ListingStartTime;
            //prodcut.ListingEndTime = productModel.ListingEndTime;
            //prodcut.SellingStartTime = productModel.SellingStartTime;
            //prodcut.SellingEndTime = productModel.SellingEndTime;
            //prodcut.CategoryId = productModel.CategoryId;

            //prodcut.Gifts = new List<Gift>();
            //foreach (var giftModel in productModel.Gifts)
            //{
            //    var gift = new Gift();
            //    gift.Name = giftModel.Name;
            //    gift.Description = giftModel.Description;

            //    prodcut.Gifts.Add(gift);
            //}

            this.ShopContext.Products.Add(prodcut);
            this.ShopContext.SaveChanges();
        }
    }
}

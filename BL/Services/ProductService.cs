using ApiSample.BL.Interfaces;
using ApiSample.DA.Interfaces;
using ApiSample.Models;
using ApiSample.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Services
{
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

            if (!string.IsNullOrWhiteSpace(insertProductModel.Gifts))
            {
                productModel.Gifts = Mapper.Map<IEnumerable<GiftModel>>(insertProductModel.Gifts);
            }

            ////// Product
            //ProductModel productModel = new ProductModel();
            //productModel.Name = insertProductModel.Name;
            //productModel.Price = insertProductModel.Price;
            //productModel.Cost = insertProductModel.Cost;
            //productModel.Description = insertProductModel.Introduction;
            //productModel.ListingStartTime = insertProductModel.StartListingAt;
            //productModel.ListingEndTime = insertProductModel.FinishListingAt;
            //productModel.SellingStartTime = insertProductModel.StartSellAt;
            //productModel.SellingEndTime = insertProductModel.FinishSellAt;
            //productModel.CategoryId = insertProductModel.CategoryId;

            ////// Gift
            //var giftList = new List<GiftModel>();
            //if (!string.IsNullOrWhiteSpace(insertProductModel.Gifts))
            //{
            //    var giftStringList = insertProductModel.Gifts.Split(';');
            //    foreach (var giftString in giftStringList)
            //    {
            //        var giftData = giftString.Split(':');
            //        var gift = new GiftModel();
            //        gift.Name = giftData[0];
            //        gift.Description = giftData[1];

            //        giftList.Add(gift);
            //    }

            //    productModel.Gifts = giftList;
            //}

            this.ProductRepository.InsertProduct(productModel);
        }
    }
}

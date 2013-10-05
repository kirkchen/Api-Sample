using ApiSample.DA.Tables;
using ApiSample.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApiSample.DA.Repositories.Test
{
    [Binding]
    public class 分類商品查詢功能步驟
    {
        private ShopContext shopContext;

        private int queryCategoryId;

        private IEnumerable<ProductForCategoryModel> productResult;

        private ProductRepository productRepository;

        [BeforeScenario]
        public void ScenarioSetup()
        {
            this.shopContext = new ShopContext();
            this.shopContext.Database.Delete();
        }

        [AfterScenario]
        public void SecnarioTeardown()
        {
            this.shopContext.Dispose();
        }

        [Given(@"資料庫中有分類資料")]
        public void 假設資料庫中有分類資料(Table table)
        {
            var categories = table.CreateSet<Category>();

            foreach (var category in categories)
            {
                this.shopContext.Categories.Add(category);
            }

            this.shopContext.SaveChanges();
        }

        [Given(@"資料庫中有產品資料")]
        public void 假設資料庫中有產品資料(Table table)
        {
            var products = table.CreateSet<Product>();

            foreach (var product in products)
            {
                this.shopContext.Products.Add(product);
            }

            this.shopContext.SaveChanges();
        }

        [Given(@"當查詢分類(.*)的商品時")]
        public void 假設當查詢分類的商品時(int categoryId)
        {
            this.queryCategoryId = categoryId;
        }

        [When(@"執行分類商品查詢")]
        public void 當執行分類商品查詢()
        {
            if (this.productRepository == null)
            {
                this.productRepository = new ProductRepository(this.shopContext);
            }

            this.productResult = this.productRepository.GetProductByCategoryId(this.queryCategoryId).ToList();
        }

        [Then(@"得到商品")]
        public void 那麼得到商品(Table table)
        {
            table.CompareToSet<ProductForCategoryModel>(this.productResult);
        }

    }
}

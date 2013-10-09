using ApiSample.Models;
using ApiSample.ViewModels;
using AutoMapper;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApiSample.BL.Mappings.Test
{
    [Binding]
    public class InsertProductModel轉換為ProductModel功能步驟
    {
        private InsertProductModel inputModel;

        private ProductModel model;

        [Given(@"使用ProductModelMappingProfile")]
        public void 假設使用ProductModelMappingProfile()
        {
            Mapper.AddProfile<ProductModelMappingProfile>();
            Mapper.AssertConfigurationIsValid();
        }

        [Given(@"輸入資料為")]
        public void 假設輸入資料為(Table table)
        {
            this.inputModel = table.CreateInstance<InsertProductModel>();
        }

        [When(@"執行轉換為Product Model")]
        public void 當執行轉換為ProductModel()
        {
            this.model = Mapper.Map<ProductModel>(this.inputModel);
        }

        [Then(@"Product Model為")]
        public void 那麼ProductModel為(Table table)
        {
            table.CompareToInstance(this.model);
        }

        [Then(@"包含Gift List")]
        public void 那麼包含GiftList(Table table)
        {
            table.CompareToSet(this.model.Gifts);
        }
    }
}

using ApiSample.BL.Interfaces;
using ApiSample.ViewModels;
using FluentValidation.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ApiSample.BL.Validators.Test
{
    [Binding]
    public class InsertProductModel驗證功能步驟
    {
        private InsertProductModel model;

        private ICategoryService service;

        private ValidationResult result;

        [Given(@"使用者輸入InsertProductModel資料")]
        public void 假設使用者輸入InsertProductModel資料(Table table)
        {
            this.model = table.CreateInstance<InsertProductModel>();
        }
        
        [Given(@"資料庫存在分類序號(.*)")]
        public void 假設資料庫存在分類序號(int categoryId)
        {
            this.service = MockRepository.GenerateStub<ICategoryService>();
            this.service.Stub(i => i.IsCategoryExist(Arg<int>.Is.Equal(categoryId)))
                        .Return(true);
        }

        [Given(@"資料庫不存在分類序號(.*)")]
        public void 假設資料庫不存在分類序號(int categoryId)
        {
            this.service = MockRepository.GenerateStub<ICategoryService>();
            this.service.Stub(i => i.IsCategoryExist(Arg<int>.Is.Equal(categoryId)))
                        .Return(false);
        }


        [Given(@"姓名長度超過(.*)")]
        public void 假設姓名長度超過(int length)
        {
            for (int i = 0; i <= length; i++)
			{
                this.model.Name += "A";
			}
        }

        [Given(@"介紹長度超過(.*)")]
        public void 假設介紹長度超過(int length)
        {
            for (int i = 0; i <= length; i++)
            {
                this.model.Introduction+= "A";
            }
        }


        [When(@"執行InsertProductModel驗證")]
        public void 當執行InsertProductModel驗證()
        {
            InsertProductModelValidator validator = new InsertProductModelValidator(this.service);
            this.result = validator.Validate(this.model);
        }
        
        [Then(@"驗證成功")]
        public void 那麼驗證成功()
        {
            Assert.IsTrue(this.result.IsValid);
        }

        [Then(@"驗證失敗")]
        public void 那麼驗證失敗()
        {
            Assert.IsFalse(this.result.IsValid);
        }

    }
}

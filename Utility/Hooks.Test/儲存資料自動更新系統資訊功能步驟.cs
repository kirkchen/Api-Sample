using ApiSample.DA.Tables;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using EFHooks;
using System.Web;
using Rhino.Mocks;
using System.Security.Principal;
using ApiSample.Utility.Hooks.UpdateSystemInfo;

namespace ApiSample.Utility.Hooks.Test
{
    [Binding]
    public class 分類商品查詢功能步驟
    {
        private HttpContextBase httpContext;

        private ShopContext shopContext;

        private int queryCategoryId;

        [BeforeScenario]
        public void ScenarioSetup()
        {
            this.shopContext = new ShopContext(new List<IPreActionHook>());
            this.shopContext.Database.Delete();
        }

        [AfterScenario]
        public void SecnarioTeardown()
        {
            this.shopContext.Dispose();
        }

        [Given(@"目前登入的使用者為(.*)")]
        public void 假設目前登入的使用者為(string name)
        {
            this.httpContext = MockRepository.GenerateStub<HttpContextBase>();
            this.httpContext.User = MockRepository.GenerateStub<IPrincipal>();
            this.httpContext.User.Stub(i => i.Identity)
                                 .Return(MockRepository.GenerateStub<IIdentity>());
            this.httpContext.User.Identity.Stub(i => i.Name)
                                          .Return(name);
        }

        [Given(@"ShopContext當更新時會自動更新系統資訊")]
        public void 假設ShopContext當更新時會自動更新系統資訊()
        {
            List<IPreActionHook> hooks = new List<IPreActionHook>();
            hooks.Add(new UpdateSystemInfoPreUpdateHook(this.httpContext));
            hooks.Add(new UpdateSystemInfoPreInsertHook(this.httpContext));

            this.shopContext = new ShopContext(hooks);
        }        

        [Given(@"新增分類資料")]
        public void 假設新增分類資料(Table table)
        {
            var categories = table.CreateSet<Category>();

            foreach (var category in categories)
            {
                this.shopContext.Categories.Add(category);
            }

            this.shopContext.SaveChanges();
        }

        [When(@"新增完畢")]
        public void 當新增完畢()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"資料庫中包含資料")]
        public void 那麼資料庫中包含資料(Table table)
        {
            var categories = this.shopContext.Categories.ToList();

            table.CompareToSet(categories);
        }

        [When(@"更新分類名字為(.*)")]
        public void 當更新分類資料(string name)
        {
            var category = this.shopContext.Categories.First();

            category.Name = name;

            this.shopContext.SaveChanges();
        }

        [Given(@"更換使用者為(.*)")]
        public void 假設更換使用者為(string name)
        {
            this.httpContext.User.Identity.BackToRecord();
            this.httpContext.User.Identity.Replay();

            this.httpContext.User.Identity.Stub(i => i.Name)
                                          .Return(name);
        }


    }
}

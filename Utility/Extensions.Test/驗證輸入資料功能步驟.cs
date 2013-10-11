using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TechTalk.SpecFlow;

namespace ApiSample.Utility.Extensions.Test
{
    [Binding]
    public class 驗證輸入資料功能步驟
    {
        private ActionExecutingContext context;

        [Given(@"使用者輸入資料驗證失敗")]
        public void 假設使用者輸入資料驗證失敗()
        {
            HttpContextBase httpContext = MockRepository.GenerateStub<HttpContextBase>();
            ControllerBase controller = MockRepository.GenerateStub<ControllerBase>();
            controller.ViewData = new ViewDataDictionary();
            controller.ViewData.ModelState.AddModelError("Error", "Error");

            ControllerContext controllerContext = new ControllerContext(httpContext, new RouteData(), controller);

            this.context = new ActionExecutingContext(controllerContext, MockRepository.GenerateStub<ActionDescriptor>(), new Dictionary<string, object>());
        }

        [Given(@"使用者輸入資料驗證成功")]
        public void 假設使用者輸入資料驗證成功()
        {
            HttpContextBase httpContext = MockRepository.GenerateStub<HttpContextBase>();
            ControllerBase controller = MockRepository.GenerateStub<ControllerBase>();
            controller.ViewData = new ViewDataDictionary();

            ControllerContext controllerContext = new ControllerContext(httpContext, new RouteData(), controller);

            this.context = new ActionExecutingContext(controllerContext, MockRepository.GenerateStub<ActionDescriptor>(), new Dictionary<string, object>());
        }

        [When(@"觸發驗證使用者傳入資料時")]
        public void 當觸發驗證使用者傳入資料時()
        {
            ValidateRequestEntityAttribute attribute = new ValidateRequestEntityAttribute();
            attribute.OnActionExecuting(this.context);
        }

        [Then(@"回傳驗證失敗訊息")]
        public void 那麼回傳驗證失敗訊息()
        {
            Assert.IsFalse(this.context.Controller.ViewData.ModelState.IsValid);
            Assert.IsNotNull(this.context.Result);
        }        

        [Then(@"繼續執行Action")]
        public void 那麼繼續執行Action()
        {
            Assert.IsTrue(this.context.Controller.ViewData.ModelState.IsValid);
            Assert.IsNull(this.context.Result);
        }

    }
}

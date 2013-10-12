using ApiSample.BL.Interfaces;
using ApiSample.Utility.Extensions.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite.ActionFilters
{
    public class ValidateTokenAttribute : AuthorizeAttribute
    {
        public IUserService UserService { get; set; }

        public IChiperTextHelper ChiperTextHelper { get; set; }

        public ValidateTokenAttribute(IUserService userService, IChiperTextHelper chiperTextHelper)
        {
            this.UserService = userService;
            this.ChiperTextHelper = chiperTextHelper;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var token = filterContext.Controller.ValueProvider.GetValue("t").AttemptedValue;
            var timeStamp = filterContext.Controller.ValueProvider.GetValue("ts").AttemptedValue;
            var signature = filterContext.Controller.ValueProvider.GetValue("s").AttemptedValue;
            var data = filterContext.Controller.ValueProvider.GetValue("data").AttemptedValue;

            if (string.IsNullOrWhiteSpace(token) ||
                string.IsNullOrWhiteSpace(timeStamp) ||
                string.IsNullOrWhiteSpace(signature) ||
                string.IsNullOrWhiteSpace(data))
            {
                throw new ApplicationException("Input data not valid!");
            }

            if (!this.ChiperTextHelper.CheckTimestampInRange(timeStamp, 86400))
            {
                throw new ApplicationException("Timestamp not valid!");
            }

            var userData = this.UserService.GetUserByToken(token);
            var expectSignature = this.ChiperTextHelper
                                      .GetSignature(userData.EncryptKey, userData.SaltKey, timeStamp, data);

            if (signature != expectSignature)
            {
                throw new ApplicationException("Signature not valid!");
            }

            var identity = new GenericIdentity(userData.Name, "Basic");
            var principal = new GenericPrincipal(identity, userData.Groups.ToArray());
            filterContext.HttpContext.User = principal;
            Thread.CurrentPrincipal = principal;
        }
    }
}
using ApiSample.BL.Interfaces;
using ApiSample.Models;
using ApiSample.Utility.Extensions.Authentication;
using ApiSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite.ActionFilters
{
    public class AuthorizeByTokenAttribute : AuthorizeAttribute
    {
        public IUserService UserService { get; set; }

        public IChiperTextHelper ChiperTextHelper { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //// Get request data
            var requestData = this.GetApiRequestEntity(filterContext);

            //// Check TimeStamp
            this.CheckIsTimeStampValid(requestData);

            //// Check Signature
            var userData = this.UserService.GetUserByToken(requestData.Token);
            this.CheckIsSignatureValid(requestData, userData);

            //// Assign User Identity
            this.AssignUserIdentity(filterContext, userData);

            //// Chekc user and group
            base.OnAuthorization(filterContext);

            //// Override unauthorized behavior
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                throw new AuthorizeTokenFailureException("Unauthorized!");
            }
        }

        private void AssignUserIdentity(AuthorizationContext filterContext, UserModel userData)
        {
            var identity = new GenericIdentity(userData.Name, "Basic");
            var principal = new GenericPrincipal(identity, userData.Groups.ToArray());
            filterContext.HttpContext.User = principal;
            Thread.CurrentPrincipal = principal;
        }

        private void CheckIsSignatureValid(ApiRequestEntity requestData, UserModel userData)
        {
            var expectSignature = this.ChiperTextHelper
                                      .GetSignature(userData.EncryptKey, userData.SaltKey, requestData.TimeStamp, requestData.Data);

            if (requestData.Signature != expectSignature)
            {
                throw new AuthorizeTokenFailureException("Signature not valid!");
            }
        }

        private void CheckIsTimeStampValid(ApiRequestEntity requestData)
        {
            //// Check is timestamp valid
            if (!this.ChiperTextHelper.CheckTimestampInRange(requestData.TimeStamp, 86400 * 30))
            {
                throw new AuthorizeTokenFailureException("Timestamp not valid!");
            }
        }

        private ApiRequestEntity GetApiRequestEntity(AuthorizationContext filterContext)
        {
            ApiRequestEntity entity = new ApiRequestEntity();

            entity.Token = this.GetDataFromValueProvider(filterContext, "token");
            entity.TimeStamp = this.GetDataFromValueProvider(filterContext, "timestamp");
            entity.Signature = this.GetDataFromValueProvider(filterContext, "signature");
            entity.Data = this.GetDataFromValueProvider(filterContext, "data");

            return entity;
        }

        private string GetDataFromValueProvider(AuthorizationContext filterContext, string key)
        {
            if (filterContext.Controller.ValueProvider.GetValue(key) != null)
            {
                return filterContext.Controller.ValueProvider.GetValue(key).AttemptedValue;
            }
            else
            {
                throw new AuthorizeTokenFailureException(string.Format("{0} can't not be null!", key));
            }
        }
    }
}
using ApiSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite.ActionFilters
{
    public class ApiErrorHandleAttribute : HandleErrorAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //If message is null or empty, then fill with generic message
            var errorMessage = filterContext.Exception.Message;           

            //Set the response status code to 500
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //Needed for IIS7.0
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            var result = new ApiResultEntity()
            {
                Status = ApiStatusEnum.Failure.ToString(),
                ErrorMessage = errorMessage
            };

            filterContext.Result = new JsonResult
            {
                Data = result,
                ContentEncoding = System.Text.Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            //Let the system know that the exception has been handled
            filterContext.ExceptionHandled = true;
        }
    }
}
using ApiSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite.ActionFilters
{
    public class ApiResultAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.Result is JsonResult)
            {
                var result = filterContext.Result as JsonResult;
                var data = result.Data;

                ApiResultEntity entity = new ApiResultEntity();
                entity.Status = ApiStatusEnum.Success.ToString();
                entity.Data = data;

                result.Data = entity;
            }            
        }
    }
}
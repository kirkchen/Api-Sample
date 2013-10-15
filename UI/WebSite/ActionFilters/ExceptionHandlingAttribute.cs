using ApiSample.ViewModels;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite.ActionFilters
{
    public class ExceptionHandlingAttribute : HandleErrorAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            try
            {
                ExceptionPolicy.HandleException(filterContext.Exception, "Policy");
            }           
            catch (Exception ex)
            {
                filterContext.Exception = ex;
                base.OnException(filterContext);
            }               
        }
    }
}
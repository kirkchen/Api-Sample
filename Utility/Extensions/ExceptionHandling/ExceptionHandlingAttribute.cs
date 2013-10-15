using ApiSample.ViewModels;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.Utility.Extensions.ExceptionHandling
{
    public class ExceptionHandlingAttribute : HandleErrorAttribute, IExceptionFilter
    {
        private string policyName;

        public ExceptionHandlingAttribute()
            : this("Policy")
        {
        }

        public ExceptionHandlingAttribute(string policyName)
        {
            this.policyName = policyName;
        }

        public void OnException(ExceptionContext filterContext)
        {
            try
            {
                ExceptionPolicy.HandleException(filterContext.Exception, this.policyName);
            }           
            catch (Exception ex)
            {
                filterContext.Exception = ex;
                base.OnException(filterContext);
            }               
        }
    }
}
using ApiSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApiSample.Utility.Extensions
{
    public class ValidateRequestEntityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState;
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                string errorMessages = string.Join("; ", modelState.Values
                                                              .SelectMany(x => x.Errors)
                                                              .Select(x => x.ErrorMessage));

                throw new ValidateEntityFailureException(errorMessages);                
            }
        }
    }
}

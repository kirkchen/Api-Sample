using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utility.Logging;

namespace ApiSample.Utility.Extensions.Nlog
{
    public class LogRequestAttribute : ActionFilterAttribute
    {
        public ILogger Logger { get; set; }

        public LogRequestAttribute(ILogger logger)
        {
            this.Logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {            
            var formData = JsonConvert.SerializeObject(filterContext.ActionParameters);

            this.Logger.Trace(string.Format("OnActionExcuting | {0} ", formData));
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {            
            var result = string.Empty;
            if (filterContext.Result is JsonResult)
            {
                result = JsonConvert.SerializeObject((filterContext.Result as JsonResult).Data);
            }

            if (filterContext.Exception != null)
            {
                result = filterContext.Exception.Message;
            }

            this.Logger.Trace(string.Format("OnActionExcuted | {0} ", result));
        }
    }
}

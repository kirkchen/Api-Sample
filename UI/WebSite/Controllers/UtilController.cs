using ApiSample.Utility.Extensions.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite.Controllers
{
    public class UtilController : Controller
    {
        public IChiperTextHelper ChiperTextHelper { get; set; }

        public UtilController(IChiperTextHelper chiperTextHelper)
        {
            this.ChiperTextHelper = chiperTextHelper;
        }

        public string GetTimeStamp()
        {
            return this.ChiperTextHelper.GetTimeStamp();
        }

        public string GetSignature(string key, string saltKey, string timeStamp, string data)
        {
            return this.ChiperTextHelper.GetSignature(key, saltKey, timeStamp, data);
        }

    }
}

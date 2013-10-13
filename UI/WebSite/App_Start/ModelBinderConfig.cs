using ApiSample.Utility.Extensions.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite
{
        public class ModelBinderConfig
        {
            public static void Initialize()
            {
                ModelBinders.Binders.DefaultBinder = new ApiModelBinder();
            }
        }
}
using ApiSample.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite
{
    public class ValueProviderConfig
    {
        public static void Initialize()
        {
            ValueProviderFactories.Factories.Remove(ValueProviderFactories.Factories
                                                                          .OfType<JsonValueProviderFactory>()
                                                                          .FirstOrDefault());
            ValueProviderFactories.Factories.Add(new JsonNetValueProviderFactory());
        }
    }
}
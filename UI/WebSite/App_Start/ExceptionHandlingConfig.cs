using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiSample.UI.WebSite
{
    public class ExceptionHandlingConfig
    {
        public static void Initialize()
        {
            //抓取Config檔案中的設定，作為configurationSource
            IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
            //以Config檔案中的設定，建立ExceptionManager
            ExceptionPolicy.SetExceptionManager(new ExceptionPolicyFactory(configurationSource).CreateManager(), true);
        }
    }
}
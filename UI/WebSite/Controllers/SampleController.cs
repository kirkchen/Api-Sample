using ApiSample.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite.Controllers
{
    public class SampleController : Controller
    {
        public ISampleService SampleService { get; set; }        

        public SampleController(ISampleService sampleService)
        {
            this.SampleService = sampleService;
        }

        public ActionResult Index()
        {
            var data = this.SampleService.GetSamples();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}

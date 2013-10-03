using ApiSample.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite.Controllers
{
    public class ProductController : Controller
    {
        public IProductService ProductService { get; set; }

        public ProductController(IProductService productService)
        {
            this.ProductService = productService;
        }

        public ActionResult GetProductByCategory(int id)
        {
            var result = this.ProductService.GetProductByCategoryId(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

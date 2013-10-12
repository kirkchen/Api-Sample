using ApiSample.BL.Interfaces;
using ApiSample.Models;
using ApiSample.UI.WebSite.ActionFilters;
using ApiSample.Utility.Extensions;
using ApiSample.ViewModels;
using FluentValidation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite.Controllers
{
    public class ProductController : JsonNetController
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

        [HttpPost]
        //[ValidateTokenAttribute]   
        [Authorize(Roles="Administrator")]
        [ValidateRequestEntity]
        public ActionResult Create(InsertProductModel product)
        {
            this.ProductService.InsertProduct(product);

            return Json(ApiStatusEnum.Success.ToString());
        }
    }
}

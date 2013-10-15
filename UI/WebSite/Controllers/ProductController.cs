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
using Utility.Logging;

namespace ApiSample.UI.WebSite.Controllers
{
    public class ProductController : JsonNetController
    {
        public IProductService ProductService { get; set; }

        public ILogger Logger { get; set; }

        public ProductController(IProductService productService, ILogger logger)
        {
            this.ProductService = productService;
            this.Logger = logger;
        }

        [AuthorizeByToken(Roles = "Administrator")]        
        public ActionResult GetProductByCategory(int id)
        {
            this.Logger.Debug("Execute GetProductByCategory - {0}", id);

            var result = this.ProductService.GetProductByCategoryId(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AuthorizeByToken(Roles = "Administrator")]
        [ValidateRequestEntity]
        public ActionResult Create(InsertProductModel product)
        {
            this.ProductService.InsertProduct(product);

            return Json(ApiStatusEnum.Success.ToString());
        }        
    }
}

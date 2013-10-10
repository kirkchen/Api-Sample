using ApiSample.BL.Interfaces;
using ApiSample.Models;
using ApiSample.ViewModels;
using FluentValidation.Mvc;
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

        [HttpPost]
        public ActionResult Create(InsertProductModel product)
        {
            if (this.ModelState.IsValid)
            {
                this.ProductService.InsertProduct(product);

                return Json(ApiStatusEnum.Success.ToString());
            }
            else
            {
                string messages = string.Join("; ", this.ModelState.Values
                                                        .SelectMany(x => x.Errors)
                                                        .Select(x => x.ErrorMessage));

                return Json(messages);
            }
        }
    }
}

using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel {
                Products = _productService.GetAll(),
            };
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId=1,
                ProductName="GSM",
                QuantityPerUnit="1",
                UnitPrice=12
            });
            return  "added";
            
        }
    }
}
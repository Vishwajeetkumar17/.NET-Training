using Microsoft.AspNetCore.Mvc;
using MvcAjaxDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcAjaxDemo.Controllers
{
    public class ProductController : Controller
    {
        // In-memory storage (for demo purposes)
        private static List<Product> products = new List<Product>();

        // Load main page
        public IActionResult Index()
        {
            return View();
        }

        // Get all products (AJAX GET)
        [HttpGet]
        public JsonResult GetProducts()
        {
            return Json(products);
        }

        // Add product (AJAX POST)
        [HttpPost]
        public JsonResult AddProduct([FromBody] Product product)
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name))
            {
                return Json(new { success = false, message = "Invalid product data." });
            }

            product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;

            products.Add(product);

            return Json(new { success = true, data = product });
        }
    }
}

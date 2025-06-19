using LAB3.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details()
        {
            // Truyền 1 sản phẩm demo
            var product = new Product
            {
                Id = 101,
                Name = "Laptop X1 Carbon",
                Price = 2999.99M
            };

            return View(product);
        }
    }
}

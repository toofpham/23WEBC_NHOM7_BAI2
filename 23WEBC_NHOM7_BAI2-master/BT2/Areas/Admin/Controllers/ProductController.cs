using BT2.Models;
using BT2.Services;
using Microsoft.AspNetCore.Mvc;

namespace BT2.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService productService, IWebHostEnvironment env)
        {
            _productService = productService;
            _env = env;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Danh sách sản phẩm";

            var filePath = Path.Combine(_env.ContentRootPath, "Data", "db.json");
            var products = ReadProducts(filePath);

            _productService.SetProducts(products);

            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {

                _productService.AddProduct(product);

                var filePath = Path.Combine(_env.ContentRootPath, "Data", "db.json");
                _productService.SaveToFile(filePath);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        private List<Product> ReadProducts(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return new List<Product>();
            }

            var json = System.IO.File.ReadAllText(filePath);
            return System.Text.Json.JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

    }
}

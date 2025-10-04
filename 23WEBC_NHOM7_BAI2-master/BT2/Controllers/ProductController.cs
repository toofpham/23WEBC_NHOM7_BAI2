using Microsoft.AspNetCore.Mvc;
using BT2.Services;

namespace BT2.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Sản phẩm";
            ViewData["PageName"] = "Products";

            var products = _productService.GetAll(); // List<Product>
            return View("Index", products);
        }

        [HttpGet("{id}")]
        public IActionResult Details(string id)   
        {
            ViewData["Title"] = "Chi tiết sản phẩm";
            ViewData["PageName"] = "ProductDetails";

            var product = _productService.GetById(id);
            if (product == null) return NotFound();

            return View("Details", product);
        }
    }
}

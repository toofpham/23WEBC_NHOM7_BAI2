using BT2.Models;
using BT2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BT2.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        // ✅ Gộp vào 1 constructor
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Trang chủ";
            ViewData["PageName"] = "Home";

            var products = _productService.GetAll(); 
            return View(products); 
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewData["Title"] = "About";
            ViewData["PageName"] = "About";

            return View("About");
        }

        public IActionResult Checkout()
        {
            ViewData["Title"] = "Checkout";
            ViewData["PageName"] = "Checkout";

            return View("Checkout");
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact";
            ViewData["PageName"] = "Contact";

            return View("Contact");
        }

        [HttpGet("faqs")]
        public IActionResult Faqs()
        {
            ViewData["Title"] = "Faqs";
            ViewData["PageName"] = "Faqs";

            return View("Faqs");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

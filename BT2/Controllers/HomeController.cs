using System.Diagnostics;
using BT2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BT2.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Trang chủ";
            return View("Index", "Home");
        }
        [HttpGet("about")]
        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View("About", "About");
        }

        //public IActionResult Products() 
        //{
        //    ViewData["Title"] = "Sản phẩm";
        //    return View("Products", "Products");
        //}

        public IActionResult Checkout() 
        {
            ViewData["Title"] = "Checkout";
            return View("Checkout", "Checkout");
        }
        [HttpGet("contact")]
        public IActionResult Contact() 
        {
            ViewData["Title"] = "Contact";
            return View("Contact", "Contact");
        }
        [HttpGet("faqs")]
        public IActionResult Faqs() 
        {
            ViewData["Title"] = "Faqs";
            return View("Faqs", "Faqs");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
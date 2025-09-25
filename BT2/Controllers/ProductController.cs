using Microsoft.AspNetCore.Mvc;

namespace BT2.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Sản phẩm";
            return View("Index", "Products");
        }

        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            ViewData["Title"] = "Chi tiết sản phẩm";
            ViewData["ProductId"] = id;
            return View("Details","Details");
        }
    }
}

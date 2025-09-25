using Microsoft.AspNetCore.Mvc;

namespace BT2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            ViewData["Title"] = "Danh sách sản phẩm";
            return View();
        }
    }
}

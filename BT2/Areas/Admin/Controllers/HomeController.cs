using Microsoft.AspNetCore.Mvc;

namespace BT2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Quản trị";
            return View();
            
        }
    }
}

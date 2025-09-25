using Microsoft.AspNetCore.Mvc;

namespace BT2.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Cart";
            return View("Index","Cart");
        }
    }
}

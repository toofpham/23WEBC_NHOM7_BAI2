using Microsoft.AspNetCore.Mvc;

namespace BT2.Controllers
{
    [Route("checkout")]
    public class CheckoutController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Checkout";
            return View("Index","Index");
        }
    }
}

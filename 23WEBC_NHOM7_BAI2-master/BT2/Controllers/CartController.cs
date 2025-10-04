using BT2.Models;
using BT2.Services;
using BT2.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BT2.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("add/{id}")]
        public IActionResult Add(string id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound();

            var cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            var cartItem = cart.FirstOrDefault(c => c.MaSP == id);

            if (cartItem == null)
            {
                cart.Add(new CartItemModel(product));
            }
            else
            {
                cartItem.SoLuong += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            return RedirectToAction("Index");
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            return View("Index", cart);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RetinaTicari.Business.Abstract;
using RetinaTicari.Entities.Concrate;
using RetinaTicari.WebApp.Models;
using RetinaTicari.WebApp.Services;

namespace RetinaTicari.WebApp.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductServise _productServise;
        public CartController(ICartService cartService, ICartSessionService sessionService, IProductServise productServise)
        {
            _cartService = cartService;
            _cartSessionService = sessionService;
            _productServise = productServise;
        }

        public IActionResult AddToCart(int productId)
        {
            var produtToBeAdded = _productServise.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, produtToBeAdded);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your product, {0}, was successfully added to the cart", produtToBeAdded.ProductName));
            return RedirectToAction("Index", "Product");
        }

        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart,
            };
            return View(cartListViewModel);
        }

        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your product was successfully removed from the cart"));
            return RedirectToAction("List");
        }

        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }

        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", String.Format("Thank you {0} , you order is in process", shippingDetails.FirstName));
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RetinaTicari.WebApp.Models;
using RetinaTicari.WebApp.Services;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace RetinaTicari.WebApp.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private ICartSessionService _sessionService;

        public CartSummaryViewComponent(ICartSessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CartListViewModel 
            {
                Cart = _sessionService.GetCart()
            };
            return View(model);
        }
    }
}

using RetinaTicari.Entities.Concrate;
using RetinaTicari.WebApp.ExtensionMethods;

namespace RetinaTicari.WebApp.Services
{
    public class CartSessionService : ICartSessionService
    {   /// <summary>
        /// Session nesnesi Control odaklı bir nesnedir. yani Control classlarında default olarak kullanabiliriz. 
        /// biz class seviyesinde Session nesnesine erişmek istersek IHttpContextAccessor interfacesinden implement etmeliyiz.
        /// </summary>
        private IHttpContextAccessor _contextAccessor;
        public CartSessionService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Cart GetCart()
        {
            Cart cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck == null)
            {
                _contextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _contextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}

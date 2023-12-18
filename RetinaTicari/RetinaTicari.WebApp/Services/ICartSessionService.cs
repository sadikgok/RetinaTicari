using RetinaTicari.Entities.Concrate;

namespace RetinaTicari.WebApp.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}

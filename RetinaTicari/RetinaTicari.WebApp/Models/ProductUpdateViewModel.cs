using RetinaTicari.Entities.Concrate;

namespace RetinaTicari.WebApp.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
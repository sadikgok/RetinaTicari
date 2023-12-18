using RetinaTicari.Entities.Concrate;

namespace RetinaTicari.WebApp.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; internal set; }
    }
}

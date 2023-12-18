using RetinaTicari.Entities.Concrate;

namespace RetinaTicari.WebApp.Models 
{
    internal class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; internal set; }
    }
}
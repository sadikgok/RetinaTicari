using Microsoft.AspNetCore.Mvc;
using RetinaTicari.Business.Abstract;
using RetinaTicari.WebApp.Models;

namespace RetinaTicari.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServise _productService;

        public ProductController(IProductServise productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int page = 1, int categoryId = 0)
        {
            int pageSize = 10;
            var products = _productService.GetByCategory(categoryId);
            ProductListViewModel model = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = categoryId,
                CurrentPage = page
            };
            return View(model);
        }

    }
}

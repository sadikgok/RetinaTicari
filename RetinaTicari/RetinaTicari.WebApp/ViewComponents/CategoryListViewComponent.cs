using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using RetinaTicari.Business.Abstract;
using RetinaTicari.WebApp.Models;

namespace RetinaTicari.WebApp.ViewComponents 
{
    public class CategoryListViewComponent:ViewComponent 
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetAll(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["categoryId"])
            };
            return View(model);
        }
    }
}

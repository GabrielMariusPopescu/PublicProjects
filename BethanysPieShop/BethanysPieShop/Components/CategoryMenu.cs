using System.Linq;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        public CategoryMenu(ICategoryRepository categoryRepository) => this.categoryRepository = categoryRepository;

        public IViewComponentResult Invoke()
        {
            var categories = categoryRepository.AllCategories.OrderBy(c => c.CategoryName);
            return View(categories);
        }

        //

        private readonly ICategoryRepository categoryRepository;
    }
}

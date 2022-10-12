using System.Collections.Generic;

namespace BethanysPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) => this.appDbContext = appDbContext;

        public IEnumerable<Category> AllCategories => appDbContext.Categories;

        //

        private readonly AppDbContext appDbContext;
    }
}

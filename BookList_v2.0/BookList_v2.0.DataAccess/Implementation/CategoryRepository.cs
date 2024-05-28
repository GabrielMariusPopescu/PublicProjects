using BookList_v2._0.DataAccess.Contracts;
using BookList_v2._0.DataAccess.Data;
using BookList_v2._0.Models;
using System.Linq;

namespace BookList_v2._0.DataAccess.Implementation;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Update(Category category)
    {
        var categoryFromDb = dbContext.Categories.FirstOrDefault(it => it.Id == category.Id);
        if (categoryFromDb == null)
            return;

        categoryFromDb.Name = category.Name;
    }

    //

    private readonly ApplicationDbContext dbContext;
}
using BookList_v2._0.Models;

namespace BookList_v2._0.DataAccess.Contracts;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category category);
}
using BookList_v2._0.Models;

namespace BookList_v2._0.DataAccess.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}

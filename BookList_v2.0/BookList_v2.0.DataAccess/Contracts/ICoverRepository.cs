using BookList_v2._0.Models;

namespace BookList_v2._0.DataAccess.Contracts
{
    public interface ICoverRepository : IRepository<Cover>
    {
        void Update(Cover cover);
    }
}

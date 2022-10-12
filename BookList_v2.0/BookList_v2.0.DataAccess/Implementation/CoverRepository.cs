using BookList_v2._0.DataAccess.Contracts;
using BookList_v2._0.DataAccess.Data;
using BookList_v2._0.Models;
using System.Linq;

namespace BookList_v2._0.DataAccess.Implementation
{
    public class CoverRepository : Repository<Cover>, ICoverRepository
    {
        public CoverRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Update(Cover cover)
        {
            var coverFromDb = dbContext.Covers.FirstOrDefault(it => it.Id == cover.Id);
            if (coverFromDb == null)
                return;

            coverFromDb.Name = cover.Name;
        }

        //

        private readonly ApplicationDbContext dbContext;
    }
}

using BookList_v2._0.DataAccess.Contracts;
using BookList_v2._0.DataAccess.Data;
using BookList_v2._0.Models;

namespace BookList_v2._0.DataAccess.Implementation
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        //

        private readonly ApplicationDbContext dbContext;
    }
}

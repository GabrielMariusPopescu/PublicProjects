using BookList_v2._0.DataAccess.Contracts;
using BookList_v2._0.DataAccess.Data;

namespace BookList_v2._0.DataAccess.Implementation;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
        CategoryRepository = new CategoryRepository(dbContext);
        CoverRepository = new CoverRepository(dbContext);
        ProductRepository = new ProductRepository(dbContext);
        CompanyRepository = new CompanyRepository(dbContext);
        UserRepository = new ApplicationUserRepository(dbContext);
    }

    public ICategoryRepository CategoryRepository { get; }

    public ICoverRepository CoverRepository { get; }

    public IProductRepository ProductRepository { get; }

    public ICompanyRepository CompanyRepository { get; }

    public IUserRepository UserRepository { get; }

    public void Dispose() => dbContext.Dispose();

    public void Save() => dbContext.SaveChanges();

    //

    private readonly ApplicationDbContext dbContext;
}
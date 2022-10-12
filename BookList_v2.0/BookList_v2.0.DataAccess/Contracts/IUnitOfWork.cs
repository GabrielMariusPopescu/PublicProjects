using System;

namespace BookList_v2._0.DataAccess.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }

        ICoverRepository CoverRepository { get; }

        IProductRepository ProductRepository { get; }

        ICompanyRepository CompanyRepository { get; }

        IUserRepository UserRepository { get; }


        void Save();
    }
}

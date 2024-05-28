using BookList_v2._0.DataAccess.Contracts;
using BookList_v2._0.DataAccess.Data;
using BookList_v2._0.Models;
using System.Linq;

namespace BookList_v2._0.DataAccess.Implementation;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Update(Company company)
    {
        var companyFromDb = dbContext.Companies.FirstOrDefault(it => it.Id == company.Id);
        if (companyFromDb == null)
            return;

        companyFromDb.StreetAddress = company.StreetAddress;
        companyFromDb.City = company.City;
        companyFromDb.State = company.State;
        companyFromDb.PostalCode = company.PostalCode;
        companyFromDb.PhoneNumber = company.PhoneNumber;
        companyFromDb.IsAuthorizedCompany = company.IsAuthorizedCompany;
    }

    //

    private readonly ApplicationDbContext dbContext;
}
using BookList_v2._0.DataAccess.Contracts;
using BookList_v2._0.DataAccess.Data;
using BookList_v2._0.Models;
using System.Linq;

namespace BookList_v2._0.DataAccess.Implementation;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext) => this.dbContext = dbContext;

    public void Update(Product product)
    {
        var productFromDb = dbContext.Products.FirstOrDefault(it => it.Id == product.Id);
        if (productFromDb == null)
            return;

        if (productFromDb.ImageUrl != null)
            productFromDb.ImageUrl = product.ImageUrl;

        productFromDb.Name = product.Name;
        productFromDb.Author = product.Author;
        productFromDb.CategoryId = product.CategoryId;
        productFromDb.CoverId = product.CoverId;
        productFromDb.Description = product.Description;
        productFromDb.Isbn = product.Isbn;
        productFromDb.ListPrice = product.ListPrice;
        productFromDb.Price = product.Price;
        productFromDb.PriceFor50 = product.PriceFor50;
        productFromDb.PriceFor100 = product.PriceFor100;
    }

    //

    private readonly ApplicationDbContext dbContext;
}
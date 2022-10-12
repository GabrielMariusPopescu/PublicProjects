namespace CarRentalManagement.Server.Repositories.Contracts;

public interface IUnitOfWork : IDisposable
{
    Task SaveAsync(HttpContext httpContext);

    IRepository<Brand> Brand { get; }

    IRepository<Color> Color { get; }

    IRepository<Customer> Customer { get; }

    IRepository<Model> Model { get; }

    IRepository<Rental> Rental { get; }

    IRepository<Vehicle> Vehicle { get; }
}
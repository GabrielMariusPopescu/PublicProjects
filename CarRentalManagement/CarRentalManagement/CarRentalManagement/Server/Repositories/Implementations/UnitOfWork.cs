namespace CarRentalManagement.Server.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ApplicationDbContext context) => _context = context;

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task SaveAsync(HttpContext httpContext)
    {
        var userId = httpContext.User.GetUserId();

        var records = _context
            .ChangeTracker
            .Entries()
            .Where(it => it.State is EntityState.Modified or EntityState.Added);

        foreach (var record in records)
        {
            ((Base)record.Entity).UpdatedBy = userId;
            ((Base)record.Entity).DateUpdated = DateTime.Now;
            if (record.State != EntityState.Added)
                continue;

            ((Base)record.Entity).CreatedBy = userId;
            ((Base)record.Entity).DateCreated = DateTime.Now;
        }

        await _context.SaveChangesAsync();
    }

    public IRepository<Brand> Brand => _brand ??= new Repository<Brand>(_context);

    public IRepository<Color> Color => _color ??= new Repository<Color>(_context);

    public IRepository<Customer> Customer => _customer ??= new Repository<Customer>(_context);

    public IRepository<Model> Model => _model ??= new Repository<Model>(_context);

    public IRepository<Rental> Rental => _rental ??= new Repository<Rental>(_context);

    public IRepository<Vehicle> Vehicle => _vehicle ??= new Repository<Vehicle>(_context);

    private readonly ApplicationDbContext _context;

    private IRepository<Brand> _brand;
    private IRepository<Color> _color;
    private IRepository<Customer> _customer;
    private IRepository<Model> _model;
    private IRepository<Rental> _rental;
    private IRepository<Vehicle> _vehicle;
}
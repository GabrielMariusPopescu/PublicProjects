namespace CarRentalManagement.Client.Pages.Customers;

public partial class View : IDisposable
{
    [Inject]
    public IHttpRepository<Customer> CustomerRepository { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => CustomerRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _customer = await CustomerRepository.Get(Endpoints.CustomerEndpoint, Id);

    private Customer _customer = new();
}
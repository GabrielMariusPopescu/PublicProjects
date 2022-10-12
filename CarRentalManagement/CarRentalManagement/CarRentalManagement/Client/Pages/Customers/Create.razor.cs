namespace CarRentalManagement.Client.Pages.Customers;

public partial class Create : IDisposable
{
    [Inject]
    public IHttpRepository<Customer> CustomerRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public void Dispose() => CustomerRepository.Dispose();

    private readonly Customer _customer = new();

    private async Task CreateCustomer()
    {
        await CustomerRepository.Create(Endpoints.CustomerEndpoint, _customer);
        NavigationManager.NavigateTo("/customers");
    }
}
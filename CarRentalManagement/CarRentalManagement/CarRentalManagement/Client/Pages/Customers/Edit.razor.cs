namespace CarRentalManagement.Client.Pages.Customers;

public partial class Edit : IDisposable
{
    [Inject]
    public IHttpRepository<Customer> CustomerRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => CustomerRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _customer = await CustomerRepository.Get(Endpoints.CustomerEndpoint, Id);

    private Customer _customer = new();

    private async Task EditCustomer()
    {
        await CustomerRepository.Update(Endpoints.CustomerEndpoint, _customer, Id);
        NavigationManager.NavigateTo("/customers");
    }
}
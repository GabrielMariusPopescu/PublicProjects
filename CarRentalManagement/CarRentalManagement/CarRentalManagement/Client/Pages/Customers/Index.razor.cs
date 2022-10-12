namespace CarRentalManagement.Client.Pages.Customers;

public partial class Index : IDisposable
{
    [Inject]
    public IHttpRepository<Customer> CustomerRepository { get; set; }

    public void Dispose() =>
        CustomerRepository.Invoke("RemoveDataTable", "#customerTable");

    protected override async Task OnInitializedAsync() =>
        Customers = await CustomerRepository.Get(Endpoints.CustomerEndpoint);

    protected override async Task OnAfterRenderAsync(bool firstRender) =>
        await CustomerRepository.Invoke("AddDataTable", "#customerTable");

    private List<Customer> Customers { get; set; }

    private async Task Delete(Guid id)
    {
        var selectedCustomer = Customers.FirstOrDefault(customer => customer.Id == id);
        if (selectedCustomer == null)
            return;

        var confirm = await CustomerRepository.Confirm("confirm", $"Do you want to delete {selectedCustomer.LastName}, {selectedCustomer.FirstName}?");
        if (!confirm)
            return;

        await CustomerRepository.Delete(Endpoints.CustomerEndpoint, selectedCustomer.Id);
        await OnInitializedAsync();
    }
}
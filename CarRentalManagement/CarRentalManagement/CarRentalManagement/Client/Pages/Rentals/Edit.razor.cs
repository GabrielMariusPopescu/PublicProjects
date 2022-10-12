namespace CarRentalManagement.Client.Pages.Rentals;

public partial class Edit : IDisposable
{
    [Inject]
    public IHttpRepository<Rental> RentalRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => RentalRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _rental = await RentalRepository.Get(Endpoints.RentalEndpoint, Id);

    private Rental _rental = new();

    private async Task EditRental()
    {
        await RentalRepository.Update(Endpoints.RentalEndpoint, _rental, Id);
        NavigationManager.NavigateTo("/rentals");
    }
}
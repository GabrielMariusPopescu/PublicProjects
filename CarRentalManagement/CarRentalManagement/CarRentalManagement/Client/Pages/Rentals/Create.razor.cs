namespace CarRentalManagement.Client.Pages.Rentals;

public partial class Create : IDisposable
{
    [Inject]
    public IHttpRepository<Rental> RentalRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public void Dispose() => RentalRepository.Dispose();

    private readonly Rental _rental = new() { DateOut = DateTime.Now.Date };

    private async Task CreateRental()
    {
        await RentalRepository.Create(Endpoints.RentalEndpoint, _rental);
        NavigationManager.NavigateTo("/rentals");
    }
}
namespace CarRentalManagement.Client.Pages.Rentals;

public partial class View : IDisposable
{
    [Inject]
    public IHttpRepository<Rental> RentalRepository { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => RentalRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _rental = await RentalRepository.GetDetails(Endpoints.RentalEndpoint, Id);

    private Rental _rental = new();
}
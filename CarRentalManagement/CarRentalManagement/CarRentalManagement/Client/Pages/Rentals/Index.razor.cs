namespace CarRentalManagement.Client.Pages.Rentals;

public partial class Index : IDisposable
{
    [Inject]
    public IHttpRepository<Rental> RentalRepository { get; set; }

    public void Dispose() =>
        RentalRepository.Invoke("RemoveDataTable", "#rentalsTable");

    protected override async Task OnInitializedAsync() =>
        Rentals = await RentalRepository.Get(Endpoints.RentalEndpoint);

    protected override async Task OnAfterRenderAsync(bool firstRender) =>
        await RentalRepository.Invoke("AddDataTable", "#rentalsTable");

    private List<Rental> Rentals { get; set; }

    private async Task Delete(Guid id)
    {
        var selectedRental = Rentals.FirstOrDefault(rental => rental.Id == id);
        if (selectedRental == null)
            return;

        var confirm = await RentalRepository.Confirm("confirm", $"Do you want to delete {selectedRental.Id}?");
        if (!confirm)
            return;

        await RentalRepository.Delete(Endpoints.RentalEndpoint, selectedRental.Id);
        await OnInitializedAsync();
    }
}
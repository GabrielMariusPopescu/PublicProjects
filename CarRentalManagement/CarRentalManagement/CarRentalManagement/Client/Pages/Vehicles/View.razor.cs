namespace CarRentalManagement.Client.Pages.Vehicles;

public partial class View : IDisposable
{
    [Inject]
    public IHttpRepository<Vehicle> VehicleRepository { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => VehicleRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _vehicle = await VehicleRepository.GetDetails(Endpoints.VehicleEndpoint, Id);

    private Vehicle _vehicle = new();
}
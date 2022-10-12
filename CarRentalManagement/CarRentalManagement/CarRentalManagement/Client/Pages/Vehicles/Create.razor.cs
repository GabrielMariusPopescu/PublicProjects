namespace CarRentalManagement.Client.Pages.Vehicles;

public partial class Create : IDisposable
{
    [Inject]
    public IHttpRepository<Vehicle> VehicleRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public void Dispose() => VehicleRepository.Dispose();

    private readonly Vehicle _vehicle = new();

    private async Task CreateVehicle()
    {
        await VehicleRepository.Create(Endpoints.VehicleEndpoint, _vehicle);
        NavigationManager.NavigateTo("/vehicles");
    }
}
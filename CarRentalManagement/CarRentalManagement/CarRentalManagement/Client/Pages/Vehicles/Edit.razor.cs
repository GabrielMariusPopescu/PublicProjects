namespace CarRentalManagement.Client.Pages.Vehicles;

public partial class Edit : IDisposable
{
    [Inject]
    public IHttpRepository<Vehicle> VehicleRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => VehicleRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _vehicle = await VehicleRepository.Get(Endpoints.VehicleEndpoint, Id);

    private Vehicle _vehicle = new();

    private async Task EditVehicle()
    {
        await VehicleRepository.Update(Endpoints.VehicleEndpoint, _vehicle, Id);
        NavigationManager.NavigateTo("/vehicles");
    }
}
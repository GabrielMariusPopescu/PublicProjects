namespace CarRentalManagement.Client.Pages.Vehicles;

public partial class Index : IDisposable
{
    [Inject]
    public IHttpRepository<Vehicle> VehicleRepository { get; set; }

    public void Dispose() =>
        VehicleRepository.Invoke("RemoveDataTable", "#vehicleTable");

    protected override async Task OnInitializedAsync() =>
        Vehicles = await VehicleRepository.Get(Endpoints.VehicleEndpoint);

    protected override async Task OnAfterRenderAsync(bool firstRender) =>
        await VehicleRepository.Invoke("AddDataTable", "#vehicleTable");

    private List<Vehicle> Vehicles { get; set; }

    private async Task Delete(Guid id)
    {
        var selectedVehicle = Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (selectedVehicle == null)
            return;

        var confirm = await VehicleRepository.Confirm("confirm", $"Do you want to delete {selectedVehicle.Id}?");
        if (!confirm)
            return;

        await VehicleRepository.Delete(Endpoints.VehicleEndpoint, selectedVehicle.Id);
        await OnInitializedAsync();
    }
}
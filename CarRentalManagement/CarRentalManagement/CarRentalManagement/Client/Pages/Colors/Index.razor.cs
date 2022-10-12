namespace CarRentalManagement.Client.Pages.Colors;

public partial class Index : IDisposable
{
    [Inject]
    public IHttpRepository<Color> ColorRepository { get; set; }

    public void Dispose() =>
        ColorRepository.Invoke("RemoveDataTable", "#colorTable");

    protected override async Task OnInitializedAsync() =>
        Colors = await ColorRepository.Get(Endpoints.ColorsEndpoint);

    protected override async Task OnAfterRenderAsync(bool firstRender) =>
        await ColorRepository.Invoke("AddDataTable", "#colorTable");

    private List<Color> Colors { get; set; }

    private async Task Delete(Guid id)
    {
        var selectedColors = Colors.FirstOrDefault(color => color.Id == id);
        if (selectedColors == null)
            return;

        var confirm = await ColorRepository.Confirm("confirm", $"Do you want to delete {selectedColors.Name}?");
        if (!confirm)
            return;

        await ColorRepository.Delete(Endpoints.ColorsEndpoint, selectedColors.Id);
        await OnInitializedAsync();
    }
}
namespace CarRentalManagement.Client.Pages.Colors;

public partial class Create : IDisposable
{
    [Inject]
    public IHttpRepository<Color> ColorRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public void Dispose() => ColorRepository.Dispose();

    private readonly Color _color = new();

    private async Task CreateColor()
    {
        await ColorRepository.Create(Endpoints.ColorsEndpoint, _color);
        NavigationManager.NavigateTo("/colors");
    }
}
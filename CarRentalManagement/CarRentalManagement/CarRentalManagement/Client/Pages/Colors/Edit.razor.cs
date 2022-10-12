namespace CarRentalManagement.Client.Pages.Colors;

public partial class Edit : IDisposable
{
    [Inject]
    public IHttpRepository<Color> ColorRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => ColorRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _color = await ColorRepository.Get(Endpoints.ColorsEndpoint, Id);

    private Color _color = new();

    private async Task EditColor()
    {
        await ColorRepository.Update(Endpoints.ColorsEndpoint, _color, Id);
        NavigationManager.NavigateTo("/colors");
    }
}
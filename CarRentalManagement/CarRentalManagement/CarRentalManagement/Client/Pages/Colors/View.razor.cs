namespace CarRentalManagement.Client.Pages.Colors;

public partial class View : IDisposable
{
    [Inject]
    public IHttpRepository<Color> ColorRepository { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => ColorRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _color = await ColorRepository.Get(Endpoints.ColorsEndpoint, Id);

    private Color _color = new();
}
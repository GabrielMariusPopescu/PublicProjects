namespace CarRentalManagement.Client.Pages.Models;

public partial class View : IDisposable
{
    [Inject]
    public IHttpRepository<Model> ModelRepository { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => ModelRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _model = await ModelRepository.Get(Endpoints.ModelEndpoint, Id);

    private Model _model = new();
}
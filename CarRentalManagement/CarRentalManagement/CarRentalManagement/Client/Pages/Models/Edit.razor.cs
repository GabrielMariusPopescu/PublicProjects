namespace CarRentalManagement.Client.Pages.Models;

public partial class Edit : IDisposable
{
    [Inject]
    public IHttpRepository<Model> ModelRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => ModelRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _model = await ModelRepository.Get(Endpoints.ModelEndpoint, Id);

    private Model _model = new();

    private async Task EditModel()
    {
        await ModelRepository.Update(Endpoints.ModelEndpoint, _model, Id);
        NavigationManager.NavigateTo("/models");
    }
}
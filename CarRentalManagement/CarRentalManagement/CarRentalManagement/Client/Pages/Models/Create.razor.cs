namespace CarRentalManagement.Client.Pages.Models;

public partial class Create : IDisposable
{
    [Inject]
    public IHttpRepository<Model> ModelRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public void Dispose() => ModelRepository.Dispose();

    private readonly Model _model = new();

    private async Task CreateModel()
    {
        await ModelRepository.Create(Endpoints.ModelEndpoint, _model);
        NavigationManager.NavigateTo("/models");
    }
}
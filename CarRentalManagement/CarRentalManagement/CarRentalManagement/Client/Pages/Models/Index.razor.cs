namespace CarRentalManagement.Client.Pages.Models;

public partial class Index : IDisposable
{
    [Inject]
    public IHttpRepository<Model> ModelRepository { get; set; }

    public void Dispose() =>
        ModelRepository.Invoke("RemoveDataTable", "#modelTable");

    protected override async Task OnInitializedAsync() =>
        Models = await ModelRepository.Get(Endpoints.ModelEndpoint);

    protected override async Task OnAfterRenderAsync(bool firstRender) =>
        await ModelRepository.Invoke("AddDataTable", "#modelTable");

    private List<Model> Models { get; set; }

    private async Task Delete(Guid id)
    {
        var selectedModel = Models.FirstOrDefault(color => color.Id == id);
        if (selectedModel == null)
            return;

        var confirm = await ModelRepository.Confirm("confirm", $"Do you want to delete {selectedModel.Name}?");
        if (!confirm)
            return;

        await ModelRepository.Delete(Endpoints.ModelEndpoint, selectedModel.Id);
        await OnInitializedAsync();
    }
}
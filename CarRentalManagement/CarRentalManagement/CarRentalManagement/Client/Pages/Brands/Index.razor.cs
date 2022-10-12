namespace CarRentalManagement.Client.Pages.Brands;

public partial class Index : IDisposable
{
    [Inject]
    public IHttpRepository<Brand> BrandRepository { get; set; }

    public void Dispose() =>
        BrandRepository.Invoke("RemoveDataTable", "#brandTable");

    protected override async Task OnInitializedAsync() =>
        Brands = await BrandRepository.Get(Endpoints.BrandEndpoint);

    protected override async Task OnAfterRenderAsync(bool firstRender) =>
        await BrandRepository.Invoke("AddDataTable", "#brandTable");

    private List<Brand> Brands { get; set; }

    private async Task Delete(Guid id)
    {
        var selected = Brands.FirstOrDefault(brand => brand.Id == id);
        if (selected == null)
            return;

        var confirm = await BrandRepository.Confirm("confirm", $"Do you want to delete {selected.Name}?");
        if (!confirm)
            return;

        await BrandRepository.Delete(Endpoints.BrandEndpoint, selected.Id);
        await OnInitializedAsync();
    }
}
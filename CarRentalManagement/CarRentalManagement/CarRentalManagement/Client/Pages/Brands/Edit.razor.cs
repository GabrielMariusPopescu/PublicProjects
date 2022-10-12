namespace CarRentalManagement.Client.Pages.Brands;

public partial class Edit : IDisposable
{
    [Inject]
    public IHttpRepository<Brand> BrandRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => BrandRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _brand = await BrandRepository.Get(Endpoints.BrandEndpoint, Id);

    private Brand _brand = new();

    private async Task EditBrand()
    {
        await BrandRepository.Update(Endpoints.BrandEndpoint, _brand, Id);
        NavigationManager.NavigateTo("/brands");
    }
}
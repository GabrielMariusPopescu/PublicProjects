namespace CarRentalManagement.Client.Pages.Brands;

public partial class Create : IDisposable
{
    [Inject]
    public IHttpRepository<Brand> BrandRepository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public void Dispose() => BrandRepository.Dispose();

    private readonly Brand _brand = new();

    private async Task CreateBrand()
    {
        await BrandRepository.Create(Endpoints.BrandEndpoint, _brand);
        NavigationManager.NavigateTo("/brands");
    }
}
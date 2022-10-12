namespace CarRentalManagement.Client.Pages.Brands;

public partial class View : IDisposable
{
    [Inject]
    public IHttpRepository<Brand> BrandRepository { get; set; }

    [Parameter]
    public Guid Id { get; set; }

    public void Dispose() => BrandRepository.Dispose();

    protected override async Task OnParametersSetAsync() =>
        _brand = await BrandRepository.Get(Endpoints.BrandEndpoint, Id);

    private Brand _brand = new();
}
namespace CarRentalManagement.Client.Helpers;

public static class Endpoints
{
    private const string Prefix = "api";

    public const string BrandEndpoint = $"{Prefix}/brands";
    public const string ColorsEndpoint = $"{Prefix}/colors";
    public const string CustomerEndpoint = $"{Prefix}/customers";
    public const string ModelEndpoint = $"{Prefix}/models";
    public const string RentalEndpoint = $"{Prefix}/rentals";
    public const string VehicleEndpoint = $"{Prefix}/vehicles";
}
namespace CarRentalManagement.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        builder.Services.AddHttpClient("CarRentalManagement.Server", (sp, client) =>
        {
            client.EnableIntercept(sp);
            client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
        }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

        builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CarRentalManagement.Server"));
        builder.Services.AddHttpClientInterceptor();
        builder.Services.AddScoped<HttpInterceptorService>();
        builder.Services.AddTransient(typeof(IHttpRepository<>), typeof(HttpRepository<>));
        builder.Services.AddApiAuthorization();

        await builder.Build().RunAsync();
    }
}
namespace CarRentalManagement.Client.Repositories.Implementation;

public class HttpRepository<T> : IDisposable, IHttpRepository<T> where T : class
{
    private readonly HttpClient _httpClient;
    private readonly HttpInterceptorService _httpInterceptorService;
    private readonly IJSRuntime _jsRuntime;

    public HttpRepository(
        HttpClient httpClient,
        HttpInterceptorService httpInterceptorService,
        IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _httpInterceptorService = httpInterceptorService;
        _jsRuntime = jsRuntime;
    }

    public async Task<T> Get(string url, Guid id)
    {
        _httpInterceptorService.MonitorEvent();
        return string.IsNullOrEmpty(_httpInterceptorService.ErrorMessage)
            ? await _httpClient.GetFromJsonAsync<T>($"{url}/{id}")
            : default;
    }

    public async Task<T> GetDetails(string url, Guid id)
    {
        _httpInterceptorService.MonitorEvent();
        return string.IsNullOrEmpty(_httpInterceptorService.ErrorMessage)
            ? await _httpClient.GetFromJsonAsync<T>($"{url}/{id}/details")
            : default;
    }

    public async Task<List<T>> Get(string url)
    {
        _httpInterceptorService.MonitorEvent();
        return string.IsNullOrEmpty(_httpInterceptorService.ErrorMessage)
            ? await _httpClient.GetFromJsonAsync<List<T>>(url)
            : default;
    }

    public async Task Create(string url, T obj)
    {
        _httpInterceptorService.MonitorEvent();
        if (string.IsNullOrEmpty(_httpInterceptorService.ErrorMessage))
            await _httpClient.PostAsJsonAsync(url, obj);
    }

    public async Task Update(string url, T obj, Guid id)
    {
        _httpInterceptorService.MonitorEvent();
        if (string.IsNullOrEmpty(_httpInterceptorService.ErrorMessage))
            await _httpClient.PutAsJsonAsync($"{url}/{id}", obj);
    }

    public async Task Delete(string url, Guid id)
    {
        _httpInterceptorService.MonitorEvent();
        if (string.IsNullOrEmpty(_httpInterceptorService.ErrorMessage))
            await _httpClient.DeleteAsync($"{url}/{id}");
    }

    public async Task Invoke(string action, string tableId)
    {
        switch (action)
        {
            case "AddDataTable":
                _httpInterceptorService.MonitorEvent();
                break;
            case "RemoveDataTable":
                _httpInterceptorService.DisposeEvent();
                break;
            default:
                throw new ArgumentOutOfRangeException(action);
        }
        await _jsRuntime.InvokeVoidAsync(action, tableId);
    }

    public async Task<bool> Confirm(string action, string question) =>
        await _jsRuntime.InvokeAsync<bool>(action, question);

    public void Dispose() => _httpInterceptorService.DisposeEvent();
}
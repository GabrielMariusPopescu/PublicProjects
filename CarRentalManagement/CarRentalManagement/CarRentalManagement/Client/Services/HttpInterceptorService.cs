namespace CarRentalManagement.Client.Services;

public class HttpInterceptorService
{
    private readonly HttpClientInterceptor _httpClientInterceptor;
    private readonly NavigationManager _navigationManager;

    public HttpInterceptorService(HttpClientInterceptor httpClientInterceptor, NavigationManager navigationManager)
    {
        _httpClientInterceptor = httpClientInterceptor;
        _navigationManager = navigationManager;
    }

    public string ErrorMessage { get; private set; }

    public void MonitorEvent() => _httpClientInterceptor.AfterSend += InterceptResponse;

    public void DisposeEvent() => _httpClientInterceptor.AfterSend -= InterceptResponse;

    private void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
    {
        if (e.Response.IsSuccessStatusCode)
        {
            ErrorMessage = string.Empty;
            return;
        }

        var responseCode = e.Response.StatusCode;
        switch (responseCode)
        {
            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
                ErrorMessage = "You are not authorized to access this resource.";
                _navigationManager.NavigateTo("/401");
                break;
            case HttpStatusCode.NotFound:
                ErrorMessage = "The resource you are looking for could not be found.";
                _navigationManager.NavigateTo("/404");
                break;
            default:
                ErrorMessage = "Something went wrong, please contact administrator.";
                _navigationManager.NavigateTo("/500");
                break;
        }
    }
}
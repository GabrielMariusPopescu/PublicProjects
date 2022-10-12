namespace CarRentalManagement.Client.Repositories.Contracts;

public interface IHttpRepository<T> where T : class
{
    Task<T> Get(string url, Guid id);

    Task<T> GetDetails(string url, Guid id);

    Task<List<T>> Get(string url);

    Task Create(string url, T obj);

    Task Update(string url, T obj, Guid id);

    Task Delete(string url, Guid id);

    Task Invoke(string action, string tableId);

    Task<bool> Confirm(string action, string question);

    void Dispose();
}
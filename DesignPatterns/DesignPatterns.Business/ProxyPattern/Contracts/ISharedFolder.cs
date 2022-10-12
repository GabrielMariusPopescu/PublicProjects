namespace DesignPatterns.Business.ProxyPattern.Contracts
{
    public interface ISharedFolder
    {
        string PerformReadOperation();

        string PerformWriteOperation();
    }
}

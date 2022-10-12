using DesignPatterns.Business.ProxyPattern.Contracts;

namespace DesignPatterns.Business.ProxyPattern.Implementation
{
    public class SharedFolder : ISharedFolder
    {
        public string PerformReadOperation() => "Performing read operation on the shared folder";

        public string PerformWriteOperation() => "Performing write operation on the shared folder";
    }
}

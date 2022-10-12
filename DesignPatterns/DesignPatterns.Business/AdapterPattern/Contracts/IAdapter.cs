using System.Collections.Generic;

namespace DesignPatterns.Business.AdapterPattern.Contracts
{
    public interface IAdapter
    {
        List<string> GetEmployees();
    }
}

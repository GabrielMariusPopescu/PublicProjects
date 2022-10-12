using System.Collections.Generic;

namespace DesignPatterns.Business.TemplateMethodPattern.Contracts
{
    public interface IDataMiner<T>
    {
        IEnumerable<string> StartMining(string file);

        IEnumerable<T> Set(IEnumerable<string> lines, char separator);
    }
}

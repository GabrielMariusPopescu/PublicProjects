using System.Collections.Generic;

namespace DesignPatterns.Business.StrategyPattern.Contracts
{
    public interface ISort
    {
        List<string> Sort(List<string> list);
    }
}
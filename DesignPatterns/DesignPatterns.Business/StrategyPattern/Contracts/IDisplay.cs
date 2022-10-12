using System.Collections.Generic;

namespace DesignPatterns.Business.StrategyPattern.Contracts
{
    public interface IDisplay
    {
        List<string> Display(List<string> list);
    }
}
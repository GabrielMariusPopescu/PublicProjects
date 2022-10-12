using DesignPatterns.Business.StrategyPattern.Contracts;
using System.Collections.Generic;

namespace DesignPatterns.Business.StrategyPattern.Services
{
    public class ReversedSort : ISort
    {
        public List<string> Sort(List<string> list)
        {
            list?.Sort();
            list?.Reverse();
            return list;
        }
    }
}

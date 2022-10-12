using DesignPatterns.Business.StrategyPattern.Contracts;
using System.Collections.Generic;

namespace DesignPatterns.Business.StrategyPattern.Services
{
    public class SortedSort : ISort
    {
        public List<string> Sort(List<string> list)
        {
            list?.Sort();
            return list;
        }
    }
}

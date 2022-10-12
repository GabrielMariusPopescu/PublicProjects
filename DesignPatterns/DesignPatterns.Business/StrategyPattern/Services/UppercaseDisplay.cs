using DesignPatterns.Business.StrategyPattern.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Business.StrategyPattern.Services
{
    public class UppercaseDisplay : IDisplay
    {
        public List<string> Display(List<string> list)
        {
            return list.Select(item => item.ToUpper()).ToList();
        }
    }
}

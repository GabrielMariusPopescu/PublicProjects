using DesignPatterns.Business.StrategyPattern.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Business.StrategyPattern.Services
{
    public class LowercaseDisplay : IDisplay
    {
        public List<string> Display(List<string> list)
        {
            return list.Select(item => item.ToLower()).ToList();
        }
    }
}

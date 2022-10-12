using DesignPatterns.Business.StrategyPattern.Contracts;
using System.Collections.Generic;

namespace DesignPatterns.Business.StrategyPattern
{
    public class Context
    {
        public Context(ISort sort, IDisplay display)
        {
            this.sort = sort;
            this.display = display;
        }

        public List<string> Sort(List<string> list)
        {
            return sort.Sort(list);
        }

        public List<string> Display(List<string> list)
        {
            return display.Display(list);
        }

        //

        private readonly ISort sort;
        private readonly IDisplay display;
    }
}

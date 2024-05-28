using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DesignPatterns.Business.StrategyPattern;
using DesignPatterns.Business.StrategyPattern.Contracts;
using DesignPatterns.Business.StrategyPattern.Services;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class StrategyPatternTests
    {
        [SetUp]
        public void Init()
        {
            reversedSort = new ReversedSort();
            sortedSort = new SortedSort();

            uppercaseDisplay = new UppercaseDisplay();
            lowercaseDisplay = new LowercaseDisplay();

            letters = new List<string> { "a", "b", "c", "d" };
        }

        [Test]
        public void ReversedAndUpperStrategies()
        {
            var context = new Context(reversedSort, uppercaseDisplay);
            var sortResult = context.Sort(letters);
            var displayResult = context.Display(letters);
            Assert.Equals("d,c,b,a", string.Join(",", sortResult));
            Assert.Equals("D,C,B,A", string.Join(",", displayResult));
        }

        [Test]
        public void NormalAndLowerStrategies()
        {
            var context = new Context(sortedSort, lowercaseDisplay);
            var sortResult = context.Sort(letters);
            var displayResult = context.Display(letters);
            Assert.Equals("a,b,c,d", string.Join(",", sortResult));
            Assert.Equals("a,b,c,d", string.Join(",", displayResult));
        }

        [Test]
        public void ReversedAndLowerStrategies()
        {
            var context = new Context(reversedSort, lowercaseDisplay);
            var sortResult = context.Sort(letters);
            var displayResult = context.Display(letters);
            Assert.Equals("d,c,b,a", string.Join(",", sortResult));
            Assert.Equals("d,c,b,a", string.Join(",", displayResult));
        }

        [Test]
        public void NormalAndUpperStrategies()
        {
            var context = new Context(sortedSort, uppercaseDisplay);
            var sortResult = context.Sort(letters);
            var displayResult = context.Display(letters);
            Assert.Equals("a,b,c,d", string.Join(",", sortResult));
            Assert.Equals("A,B,C,D", string.Join(",", displayResult));
        }

        //

        private ISort reversedSort;
        private ISort sortedSort;

        private IDisplay uppercaseDisplay;
        private IDisplay lowercaseDisplay;

        private List<string> letters;
    }
}

using DesignPatterns.Business.AdapterPattern;
using DesignPatterns.Business.AdapterPattern.Contracts;
using DesignPatterns.Business.AdapterPattern.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace DesignPatterns.Tests
{
    [TestFixture]
    public class AdapterPatternTests
    {
        [SetUp]
        public void Init()
        {
            adaptee = new Adaptee();
            adapter = new Adapter(adaptee);
        }

        [Test]
        public void AdapteeEmployeesAreInAJaggedArray()
        {
            var employees = adaptee.GetEmployees();
            Assert.IsInstanceOf<string[][]>(employees);
        }

        [Test]
        public void AdapterEmployeesAreInAList()
        {
            var employees = adapter.GetEmployees();
            Assert.IsInstanceOf<List<string>>(employees);
        }

        [Test]
        public void JaggedArrayIsIncompatibleWithList()
        {
            var adapteeEmployees = adaptee.GetEmployees();
            var adapterEmployees = adapter.GetEmployees();

            Assert.IsNotInstanceOf<List<string>>(adapteeEmployees);
            Assert.IsNotInstanceOf<string[][]>(adapterEmployees);
        }

        //

        private Adaptee adaptee;
        private IAdapter adapter;
    }
}

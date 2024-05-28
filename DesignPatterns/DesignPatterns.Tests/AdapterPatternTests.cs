using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DesignPatterns.Business.AdapterPattern;
using DesignPatterns.Business.AdapterPattern.Contracts;
using DesignPatterns.Business.AdapterPattern.Services;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [ExcludeFromCodeCoverage]
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
            Assert.That(employees, Is.InstanceOf<string[][]>());
        }

        [Test]
        public void AdapterEmployeesAreInAList()
        {
            var employees = adapter.GetEmployees();
            Assert.That(employees, Is.InstanceOf<List<string>>());
        }

        [Test]
        public void JaggedArrayIsIncompatibleWithList()
        {
            var adapteeEmployees = adaptee.GetEmployees();
            var adapterEmployees = adapter.GetEmployees();

            Assert.That(adapteeEmployees, Is.InstanceOf<string[][]>());
            Assert.That(adapterEmployees, Is.InstanceOf<List<string>>());
        }

        //

        private Adaptee adaptee;
        private IAdapter adapter;
    }
}

using DesignPatterns.Business.AdapterPattern.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Business.AdapterPattern.Services
{
    public class Adapter : IAdapter
    {
        public Adapter(Adaptee adaptee) => this.adaptee = adaptee;

        public List<string> GetEmployees()
        {
            var employees = adaptee.GetEmployees();
            return employees.SelectMany(employee => employee).ToList();
        }

        //

        private readonly Adaptee adaptee;
    }
}

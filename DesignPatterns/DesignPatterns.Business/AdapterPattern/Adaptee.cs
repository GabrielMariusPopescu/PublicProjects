namespace DesignPatterns.Business.AdapterPattern
{
    public class Adaptee
    {
        public string[][] GetEmployees()
        {
            var employees = new string[2][];
            employees[0] = new[] { "1", "Jon Doe", "CEO" };
            employees[1] = new[] { "2", "Jane Doe", "COO" };

            return employees;
        }
    }
}
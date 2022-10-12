using DesignPatterns.Business.ProxyPattern.Enums;

namespace DesignPatterns.Business.ProxyPattern.Models
{
    public class Employee
    {
        public string Username { get; }

        public RoleType RoleType { get; }

        public Employee(string username, RoleType roleType)
        {
            Username = username;
            RoleType = roleType;
        }
    }
}

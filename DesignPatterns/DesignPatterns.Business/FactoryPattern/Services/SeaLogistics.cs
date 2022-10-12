using DesignPatterns.Business.FactoryPattern.Contracts;
using DesignPatterns.Business.FactoryPattern.Models;

namespace DesignPatterns.Business.FactoryPattern.Services
{
    public class SeaLogistics :ILogistics
    {
        public ITransport CreateTransport() => new Ship();
    }
}
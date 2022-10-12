using System.Reflection;

namespace DesignPatterns.Business.FacadePattern
{
    public class Converter
    {
        public string Format { get; private set; }

        public string Name { get; private set; }

        public void Convert<T>()
            where T : new()
        {
            var format = new T();
            Format = format.GetType().Name;
            var propertyInfo = format.GetType().GetProperty("Filename", BindingFlags.Instance | BindingFlags.Public);
            var value = propertyInfo?.GetValue(format).ToString();
            Name = $"{Format} has been converted with the filename {value}";
        }
    }
}

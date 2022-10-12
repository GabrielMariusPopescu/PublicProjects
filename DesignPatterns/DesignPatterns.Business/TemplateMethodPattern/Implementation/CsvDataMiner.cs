using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DesignPatterns.Business.TemplateMethodPattern.Contracts;
using DesignPatterns.Business.TemplateMethodPattern.Models;

namespace DesignPatterns.Business.TemplateMethodPattern.Implementation
{
    public class CsvDataMiner : IDataMiner<CSV>
    {
        public IEnumerable<string> StartMining(string file)
        {
            var lines = new List<string>();
            using(var fileStream = new FileStream(file, FileMode.Open))
            using(var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                while(!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    lines.Add(line);
                }

            return lines.Select(line => line).ToList();
        }

        public IEnumerable<CSV> Set(IEnumerable<string> lines, char separator) =>
            lines
                .Skip(1)
                .Select(line => line.Split(separator))
                .Select(items => new CSV
                {
                    Id = items[0],
                    Name = items[1],
                    Age = int.Parse(items[2])
                }).ToList();
    }
}

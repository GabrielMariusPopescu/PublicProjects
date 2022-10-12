using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.Business.TemplateMethodPattern.Contracts;
using DesignPatterns.Business.TemplateMethodPattern.Models;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace DesignPatterns.Business.TemplateMethodPattern.Implementation
{
    public class PdfDataMiner : IDataMiner<PDF>
    {
        public IEnumerable<string> StartMining(string file)
        {
            var reader = new PdfReader(file);
            var document = new PdfDocument(reader);
            var lines = new List<string>();
            for(var index = 1; index <= document.GetNumberOfPages(); index++)
            {
                var textFromPage = PdfTextExtractor.GetTextFromPage(document.GetPage(index));
                var items = textFromPage.Split('\n');
                lines.AddRange(items.Select(item => Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(item))).Where(line => !line.Equals(" ")));
            }

            reader.Close();
            return lines;
        }

        public IEnumerable<PDF> Set(IEnumerable<string> lines, char separator) =>
            lines
                .Skip(1)
                .Select(line => line.Split(separator))
                .Select(items => new PDF
                {
                    Id = items[0],
                    Name = items[1],
                    Age = int.Parse(items[2])
                }).ToList();
    }
}

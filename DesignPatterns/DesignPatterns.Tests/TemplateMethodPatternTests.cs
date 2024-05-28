using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DesignPatterns.Business.TemplateMethodPattern.Contracts;
using DesignPatterns.Business.TemplateMethodPattern.Implementation;
using DesignPatterns.Business.TemplateMethodPattern.Models;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class TemplateMethodPatternTests
    {

        [Test]
        public void ReadCsv()
        {
            IDataMiner<CSV> dataMiner = new CsvDataMiner();
            var csv = dataMiner.StartMining(Properties.Resources.CsvFile);
            Assert.Equals(5, csv.Count());
        }

        [Test]
        public void ReadPdf()
        {
            IDataMiner<PDF> dataMiner = new PdfDataMiner();
            var pdf = dataMiner.StartMining(Properties.Resources.PdfFile);
            Assert.Equals(5, pdf.Count());
        }

        [Test]
        public void SetCsv()
        {
            IDataMiner<CSV> dataMiner = new CsvDataMiner();
            var lines = dataMiner.StartMining(Properties.Resources.CsvFile);
            var actual = dataMiner.Set(lines, ',');
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.TypeOf<IEnumerable<CSV>>());
            Assert.Equals(4, actual.Count());
        }

        [Test]
        public void SetPdf()
        {
            IDataMiner<PDF> dataMiner = new PdfDataMiner();
            var lines = dataMiner.StartMining(Properties.Resources.PdfFile);
            var actual = dataMiner.Set(lines, ' ');
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.TypeOf<IEnumerable<PDF>>());
            Assert.Equals(4, actual.Count());
        }
    }
}

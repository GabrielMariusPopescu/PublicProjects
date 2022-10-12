using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Business.TemplateMethodPattern.Contracts;
using DesignPatterns.Business.TemplateMethodPattern.Implementation;
using DesignPatterns.Business.TemplateMethodPattern.Models;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [TestFixture]
    public class TemplateMethodPatternTests
    {

        [Test]
        public void ReadCsv()
        {
            IDataMiner<CSV> dataMiner = new CsvDataMiner();
            var csv = dataMiner.StartMining(Properties.Resources.CsvFile);
            Assert.AreEqual(5, csv.Count());
        }

        [Test]
        public void ReadPdf()
        {
            IDataMiner<PDF> dataMiner = new PdfDataMiner();
            var pdf = dataMiner.StartMining(Properties.Resources.PdfFile);
            Assert.AreEqual(5, pdf.Count());
        }

        [Test]
        public void SetCsv()
        {
            IDataMiner<CSV> dataMiner = new CsvDataMiner();
            var lines = dataMiner.StartMining(Properties.Resources.CsvFile);
            var actual = dataMiner.Set(lines, ',');
            Assert.NotNull(actual);
            Assert.IsInstanceOf<IEnumerable<CSV>>(actual);
            Assert.AreEqual(4, actual.Count());
        }

        [Test]
        public void SetPdf()
        {
            IDataMiner<PDF> dataMiner = new PdfDataMiner();
            var lines = dataMiner.StartMining(Properties.Resources.PdfFile);
            var actual = dataMiner.Set(lines, ' ');
            Assert.NotNull(actual);
            Assert.IsInstanceOf<IEnumerable<PDF>>(actual);
            Assert.AreEqual(4, actual.Count());
        }
    }
}

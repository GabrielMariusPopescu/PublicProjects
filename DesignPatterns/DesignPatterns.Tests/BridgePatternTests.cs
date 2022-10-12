using DesignPatterns.Business.BridgePattern.Contracts;
using DesignPatterns.Business.BridgePattern.Implementation;
using DesignPatterns.Business.BridgePattern.Models;
using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [TestFixture]
    public class BridgePatternTests
    {
        [SetUp]
        public void Init()
        {
            artist = new Artist();
            book = new Book();
        }

        [Test]
        public void ArtistUsingLongView()
        {
            resource = new ArtistResource(artist);
            view = new LongView(resource);
            var actual = view.Show();
            Assert.AreEqual($"This is the long view representation of the {resource.Snippet()}", actual);
        }

        [Test]
        public void ArtistUsingShortView()
        {
            resource = new ArtistResource(artist);
            view = new ShortView(resource);
            var actual = view.Show();
            Assert.AreEqual($"This is the short view representation of the {resource.Snippet()}", actual);
        }

        [Test]
        public void BookUsingLongView()
        {
            resource = new BookResource(book);
            view = new LongView(resource);
            var actual = view.Show();
            Assert.AreEqual($"This is the long view representation of the {resource.Snippet()}", actual);
        }

        [Test]
        public void BookUsingShortView()
        {
            resource = new BookResource(book);
            view = new ShortView(resource);
            var actual = view.Show();
            Assert.AreEqual($"This is the short view representation of the {resource.Snippet()}", actual);
        }

        //

        private View view;
        private IResource resource;

        private Artist artist;
        private Book book;
    }
}

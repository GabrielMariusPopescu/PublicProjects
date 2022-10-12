using DesignPatterns.Business.BridgePattern.Contracts;
using DesignPatterns.Business.BridgePattern.Models;

namespace DesignPatterns.Business.BridgePattern.Implementation
{
    public class BookResource : Book, IResource
    {
        public BookResource(Book book) => this.book = book;

        public string Snippet() => book.GetTitle();

        //

        private readonly Book book;
    }
}

using Doc4Markdown.Library.Implementation;
using System.Collections.Generic;
using System.Linq;

namespace Doc4Markdown
{
    public static class Document
    {
        public static List<string> CreateDefinitions(List<string> lines)
        {
            var definitions = TextDocument.GetDefinitions(lines);
            return TextDocument.EliminateSomeDefinitions(definitions).ToList();
        }

        public static List<string> CreateMarkdown(IEnumerable<string> lines) =>
            MarkdownDocument
               .GetMarkdowns(lines)
               .ToList();

        public static IEnumerable<string> CreateHtml(List<string> lines) =>
            HtmlDocument
               .GetHtml(lines)
               .ToList();

        //

        private static readonly TextDocument TextDocument = new TextDocument();
        private static readonly MarkdownDocument MarkdownDocument = new MarkdownDocument();
        private static readonly HtmlDocument HtmlDocument = new HtmlDocument();
    }
}
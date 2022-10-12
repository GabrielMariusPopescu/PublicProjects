using System.Collections.Generic;
using System.Linq;
using Doc4Markdown.Library.Extensions;
using MarkdownDeep;

namespace Doc4Markdown.Library.Implementation
{
    public class HtmlDocument
    {
        public IEnumerable<string> GetHtml(List<string> lines)
        {
            var tags = new List<string>();
            Title = lines.First().Substring(1).TrimEnd('\n').TrimEnd('\r');
            tags.AddRange(InsertHeadTags);
            InsertBodyTags(lines, tags);
            var breakLines = HtmlDocumentProcess.AddBreakLines(tags);
            var noteLines = HtmlDocumentProcess.AddColorToNoteLines(breakLines);

            return noteLines
                  .Select(tag => tag.TrimEnd('\n'))
                  .ToList();
        }

        private static void InsertBodyTags(IEnumerable<string> lines, List<string> tags)
        {
            var markdown = new Markdown
            {
                UserBreaks = true,
                AutoHeadingIDs = true,
                ExtraMode = true,
                SafeMode = true,
                MarkdownInHtml = true
            };

            tags.AddRange(lines.Select(line => markdown.Transform(line)));
            tags.Add("</xmp>");
            tags.Add("<script src=\"http://strapdownjs.com/v/0.2/strapdown.js\"></script>");
            tags.Add("</html>");
        }

        //

        private static string Title { get; set; }

        private static IEnumerable<string> InsertHeadTags
        {
            get
            {
                return new List<string>
                {
                    "<!DOCTYPE html>",
                    "<html lang=\"en\">",
                    $"<title>{Title}</title>",
                    "<xmp theme=\"united\" style=\"display:none;\">"
                };
            }
        }
    }
}
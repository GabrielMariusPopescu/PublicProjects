using System.Collections.Generic;
using System.Linq;

namespace Doc4Markdown.Library.Extensions
{
    public static class HtmlDocumentProcess
    {
        public static IEnumerable<string> AddBreakLines(IEnumerable<string> tags)
        {
            return tags
                  .Select(tag => string.IsNullOrEmpty(tag)
                                     ? tag?.Insert(0, "<hr style=\"height: 1px; border: none; color:#333333;background-color:#333333;\" />")
                                     : tag)
                  .ToList();
        }

        public static IEnumerable<string> AddColorToNoteLines(IEnumerable<string> breakLines)
        {
            return breakLines
                  .Select(line =>
                   {
                       if (line.Contains("Caution:"))
                           return line.Replace("<p><code>", "<p><code style=\"border: 2px solid #CD0000;\">");
                       return line.Contains("Implement")
                                  ? line.Replace("<p><code>", "<p><code style=\"border: 2px solid #0000CD;\">")
                                  : line;
                   })
                  .ToList();
        }
    }
}
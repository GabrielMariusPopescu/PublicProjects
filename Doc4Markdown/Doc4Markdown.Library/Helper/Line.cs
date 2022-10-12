using System;
using System.Collections.Generic;

namespace Doc4Markdown.Library.Helper
{
    public static class Line
    {
        public static readonly List<string> MultiLines = new List<string>();

        public static string GetBetween(string source, string first, string last)
        {
            var start = source.IndexOf(first, StringComparison.Ordinal) + first.Length;
            var end = source.IndexOf(last, start, StringComparison.Ordinal);
            return source.Substring(start, end - start);
        }

        public static string GetBefore(string source, string before)
        {
            var position = source.IndexOf(before, StringComparison.Ordinal);
            return source.Substring(0, position);
        }

        public static string GetAfter(string source, string after)
        {
            var position = source.LastIndexOf(after, StringComparison.Ordinal);
            var adjustedPosition = position + after.Length;
            return source.Substring(adjustedPosition);
        }

        public static void GetNextLine(IReadOnlyList<string> definitions)
        {
            for (var i = 0; i < definitions.Count; i++)
                if (RegEx.IsAccessModifier(definitions[i]) && definitions[i].EndsWith(","))
                    MultiLines.Add(definitions[i].Trim() + " " + definitions[i + 1].Trim());
        }
    }
}
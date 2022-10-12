using Doc4Markdown.Library.Helper;
using System;
using System.Collections.Generic;

namespace Doc4Markdown.Library.Extensions
{
    public static class MarkdownDocumentProcess
    {
        public static string GenerateTable(string item)
        {
            var trimmed = item.Remove(0, 7);
            string name, task;

            if (item.Contains(":") && item.Contains("-"))
            {
                name = Line.GetBetween(trimmed, ":", "-").Trim();
                task = Line.GetAfter(trimmed, "-");
            }
            else
            {
                name = "NONAME";
                task = Line.GetAfter(trimmed, ": ");
            }

            var status = Line.GetBefore(trimmed, ":");
            var result = "Name | Task | Status" + Environment.NewLine +
                         "--- | --- | ---" + Environment.NewLine +
                         $"{name} | {task} | {status}" + Environment.NewLine;

            return result;
        }

        public static string Replace(string line, string item)
        {
            const int spaces = 2;

            if (line.StartsWith("XmlComments:"))
                return line
                      .Remove(0, line.IndexOf(':') + spaces)
                      .Insert(0, $"{item}");

            if (line.StartsWith("------"))
                return line
                   .Remove(0, 3);

            return line
                  .Remove(0, line.IndexOf(':') + spaces)
                  .Insert(0, $"{item}");
        }

        public static string ChooseType(string line)
        {
            var dict = new Dictionary<string, string>();

            if (XmlCommentsRegEx.IsParam(line))
            {
                Key = Line.GetBetween(line, "\"", "\"");
                Value = Line.GetBetween(line, ">", "<").Length > 0
                            ? Line.GetBetween(line, ">", "<")
                            : "";

                dict.Add($"Parameter: {Key}", $"Comments: {Value}");
            }
            else if (XmlCommentsRegEx.IsReturn(line))
            {
                var returns = Line.GetBetween(line, "<", ">");
                Key = ToUpper(returns);
                Value = Line.GetBetween(line, "<returns>", "</returns>");

                dict.Add($"{Key}: ", $"{Value}");
            }
            else if (XmlCommentsRegEx.IsSquareBracket(line))
                dict.Add("Attribute: ", $"{line}");

            else if (XmlCommentsRegEx.IsTypeParam(line))
            {
                Key = Line.GetBetween(line, "\"", "\"");
                Value = Line.GetBetween(line, ">", "<").Length > 0
                            ? Line.GetBetween(line, ">", "<")
                            : "";

                dict.Add($"Type parameter: {Key}", $"Comments: {Value}");
            }
            else if (XmlCommentsRegEx.AreRemarks(line))
            {
                var remarks = Line.GetBetween(line, "<", ">");
                Key = ToUpper(remarks);
                if (line.StartsWith("<remarks>") && line.EndsWith("</remarks>"))
                    Value = Line.GetBetween(line, "<remarks>", "</remarks>");
                else if (line.StartsWith("<remarks>"))
                    Value = Line.GetAfter(line, "<remarks>");

                dict.Add($"{Key}: ", $"{Value}");
            }
            else if (XmlCommentsRegEx.AreNotes(line))
            {
                var notes = Line.GetBetween(line, "\"", "\"");
                Key = ToUpper(notes);

                string value;
                if (line.Contains("<para>"))
                    value = line.Contains("</para>")
                                ? Line.GetBetween(line, "<para>", "</para>")
                                : Line.GetAfter(line, "<para>");
                else
                    value = Line.GetBetween(line, ">", "<").Length > 0
                                ? Line.GetBetween(line, ">", "<")
                                : "";

                dict.Add($"{Key}: ", $"{value}");
            }

            var item = "";
            foreach (var kv in dict)
            {
                item = $"```{kv.Key}```" + "\t" + $"```{kv.Value}```";
            }

            return item;
        }

        //

        private static string Key { get; set; }
        private static string Value { get; set; }
        
        private static string ToUpper(string word)
        {
            return char.ToUpper(word[0]) + word.Substring(1);
        }
    }
}
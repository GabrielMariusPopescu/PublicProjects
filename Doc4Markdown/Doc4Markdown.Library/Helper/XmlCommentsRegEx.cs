using System.Text.RegularExpressions;

namespace Doc4Markdown.Library.Helper
{
    public static class XmlCommentsRegEx
    {
        public static bool IsParam(string line) => 
            Regex.IsMatch(line, @"\B<param name=", RegexOptions.Compiled);

        public static bool IsReturn(string line) => 
            Regex.IsMatch(line, @"\B<returns>", RegexOptions.Compiled);

        public static bool IsSquareBracket(string line) => 
            Regex.IsMatch(line, @"\[", RegexOptions.Compiled);

        public static bool IsTypeParam(string line) => 
            Regex.IsMatch(line, @"\B<typeparam name=", RegexOptions.Compiled);

        public static bool AreRemarks(string line) => 
            Regex.IsMatch(line, @"\B<remarks", RegexOptions.Compiled);

        public static bool AreNotes(string line) => 
            Regex.IsMatch(line, @"\B<note", RegexOptions.Compiled);
    }
}
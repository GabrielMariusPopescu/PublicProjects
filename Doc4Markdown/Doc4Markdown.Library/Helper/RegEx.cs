using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Doc4Markdown.Library.Helper
{
    public static class RegEx
    {
        public static Regex GetTitleRegex { get; } = 
            new Regex(@"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

        public static bool IsAccessModifier(string line) => 
            Regex.IsMatch(line, @"^(?:(public|private|protected|internal)\s+)", RegexOptions.Compiled);

        public static bool AreProjects(string line) =>
            Regex.IsMatch(line, @"^(?:[A-Z]\:|\.(?:file\:\/\/|\\\\)[^\\\/\:\*?\<\>\'|]+)(?:(?:\\|\/)[^\\\/:\*?\<\>\'|]+)*(?:\\|)?$",
                          RegexOptions.Compiled);

        public static bool IsTask(string line) => AreTasks(line);

        public static bool IsComment(string line) => AreXmlComments(line);

        public static bool IsAttribute(string line) => Regex.IsMatch(line, @"^\[([\w\d])+\]", RegexOptions.Compiled);

        public static bool IsInterface(string line) => Regex.IsMatch(line, @"\binterface\b", RegexOptions.Compiled);

        public static bool AreMembers(string line) =>
            Regex.IsMatch(line,
                          @"(?:\w+\s\w+<\w+>\(\w+\s\w+\))|(?:\w+<\w+\>\s\w+<\w+>\(\))|(?:\w+<\w+\>\s\w+<\w+>\([\w+\s]*,[\s\w+]{1,}\))|(?:\w+\s+\w+\(\w+<\w+>\s\w+\))|(?:\w+\s\w+\(\w+\s\w+\);)|(?:\w+\s+\w+\([\w+\s]*,[\s\w+]{1,}\);)",
                          RegexOptions.Compiled);

        public static bool IsEnum(string line) => 
            Regex.IsMatch(line, @"\benum\b", RegexOptions.Compiled);

        public static bool AreEnumerators(string line) => 
            Regex.IsMatch(line, @"([a-zA-Z]{1,}\s=\s\d{1,3},)|^(([a-zA-Z]+,))", RegexOptions.Compiled);

        public static bool IsClass(string line) => AreClasses(line);

        public static bool IsConstructor(string line) => 
            Regex.IsMatch(line, @"((^\bpublic\b\s\w+\(([^)]*)\))|((^\bprivate\b\s\w+\(([^)]*)\))))", RegexOptions.Compiled);

        public static bool IsDestructor(string line) => Regex.IsMatch(line, @"\A~", RegexOptions.Compiled);

        public static bool IsEvent(string line) => 
            Regex.IsMatch(line, @"(?:\bevent\b)|(?:(public|private)\s+_\w+\([\w+\s,]{1,}\))", RegexOptions.Compiled);

        public static bool IsMethod(string line) =>
            Regex.IsMatch(line,
                          @"^(?:[a-zA-Z\s]{1,}\(\))$|^([a-zA-Z\s]{1,}\([a-zA-Z\s]{1,},[a-zA-Z\s]{1,}\))|^([a-zA-Z\s]{1,}\([a-zA-Z\s]{1,}\))^|(?:[a-zA-Z\s[^=]]{1,}\(\))|^(?:[a-zA-Z\s]{1,}\(\))|^(?:[a-zA-Z\s]{1,}<[a-zA-Z0-9]{1,}>[a-zA-Z0-9\s]{1,}\(\))|^(?:[a-zA-Z\s]{1,}\([a-zA-Z]{1,}<[a-zA-Z0-9]{1,}>[a-zA-Z0-9\s]{1,}\))|^(?:[a-zA-Z\s]{1,}\([a-zA-Z]{1,}<[a-zA-Z0-9]{1,}>[a-zA-Z0-9\s]{1,}=[a-zA-Z\s]{1,}\))|^(?:[a-zA-Z\s]{1,}\([a-zA-Z\s,]{1,}\)\s=>\s[a-zA-Z\s]{1,})|(?:\w+\s\w+<\w+>\(\w+\s\w+\))|(?:\w+\s\w+<\w+>\(\w+<\w+>\s\w+\))",
                          RegexOptions.Compiled);

        public static bool IsProperty(string line) => 
            Regex.IsMatch(line, @"(?:\{\s?get;\s?\})|(?:\{\s?set;\s?\})|(?:\{\s?get; private set;\s?\})|(?:\{\s?get; set;\s?\})", RegexOptions.Compiled);

        public static bool IsField(string line) => 
            Regex.IsMatch(line, @"(?:[a-zA-Z0-9]{1,};)|(?:(\""[\w+=]{1,}\""){1};)", RegexOptions.Compiled);

        public static bool IsLineBreak(string line) => Regex.IsMatch(line, @"^(?:[-]{6})", RegexOptions.Compiled);

        public static bool AreExcludedDirectories(string line) => !ExcludedDirectories.Any(line.Contains);

        public static bool AreExcludedFiles(string line) => !ExcludedFiles.Any(line.Contains);

        //

        private static IEnumerable<string> PossibleTasks { get; } = new[]
            {"//TODO: ", "//DONE: ", "// TODO: ", "// DONE: ", "//Done: ", "//Todo: ", "// Done: ", "// Todo: "};

        private static IEnumerable<string> PossibleXmlComments { get; } = new[]
            {"/// <summary>", "/// ", "/// </summary>", "<returns>", "</returns>", "<param ", "</param>", "<typeparam ", "</typeparam>"};

        private static IEnumerable<string> PossibleClasses { get; } = new[] {"abstract class", "partial class", "class", "sealed class"};

        private static IEnumerable<string> ExcludedDirectories { get; } = new[]
            {".git", ".vs", "Properties", "obj", "bin", "packages", ".svn", "designer", "Service Reference", "Web Reference", "Files", ".nuget"};

        private static IEnumerable<string> ExcludedFiles { get; } = new[] {"Designer.cs", "Reference.cs", "AssemblyInfo.cs"};

        private static bool AreTasks(string line) => PossibleTasks.Any(line.Contains);

        private static bool AreXmlComments(string line) => PossibleXmlComments.Any(line.Contains);

        private static bool AreClasses(string line) => PossibleClasses.Any(line.Contains);
    }
}
using Doc4Markdown.Library.Helper;
using System.Linq;

namespace Doc4Markdown.Library.Extensions
{
    public static class TextDocumentProcess
    {
        public static Definition GetDefinition(string line)
        {
            if (RegEx.IsTask(line))
                return new Definition(DefinitionType.Tasks, RemoveSlashes(line));

            if (RegEx.IsComment(line))
                return new Definition(DefinitionType.XmlComments, RemoveSummary(line));

            if (RegEx.IsAttribute(line))
                return new Definition(DefinitionType.Attributes, line);

            if (RegEx.IsInterface(line) && RegEx.IsAccessModifier(line))
                return new Definition(DefinitionType.Interfaces, line);

            if (!RegEx.IsAccessModifier(line) && RegEx.AreMembers(line) && !line.Contains("."))
                return line.Contains("return")
                           ? new Definition(DefinitionType.Members, line.Remove(0))
                           : new Definition(DefinitionType.Members, line);

            if (RegEx.IsEnum(line) && RegEx.IsAccessModifier(line))
                return line.EndsWith("{")
                           ? new Definition(DefinitionType.Enums, Line.GetBefore(line, "{"))
                           : new Definition(DefinitionType.Enums, line);

            if (RegEx.AreEnumerators(line))
                return new Definition(DefinitionType.Enumerators, line.TrimEnd(','));

            if (RegEx.IsClass(line) && RegEx.IsAccessModifier(line))
                return line.EndsWith("{")
                           ? new Definition(DefinitionType.Classes, Line.GetBefore(line, "{"))
                           : new Definition(DefinitionType.Classes, line);

            if (RegEx.IsConstructor(line) && RegEx.IsAccessModifier(line))
                return line.EndsWith("{")
                           ? new Definition(DefinitionType.Constructors, Line.GetBefore(line, "{"))
                           : new Definition(DefinitionType.Constructors, line);

            if (RegEx.IsDestructor(line))
                return line.EndsWith("{")
                           ? new Definition(DefinitionType.Destructors, Line.GetBefore(line, "{"))
                           : new Definition(DefinitionType.Destructors, line);

            if (RegEx.IsEvent(line))
                return line.EndsWith(",")
                           ? new Definition(DefinitionType.Events, Line.MultiLines.First(it => it.TrimStart(' ').Contains(line)))
                           : new Definition(DefinitionType.Events, line);

            if (RegEx.IsProperty(line) && RegEx.IsAccessModifier(line))
                return new Definition(DefinitionType.Properties, Line.GetBefore(line, "}") + "}");

            if (RegEx.IsMethod(line) && RegEx.IsAccessModifier(line))
                if (line.EndsWith(","))
                    return line.Contains("=>")
                               ? new Definition(DefinitionType.Methods,
                                                Line.MultiLines.First(it => it.TrimStart(' ').Contains(line)).Substring(0, line.IndexOf('=')))
                               : new Definition(DefinitionType.Methods, Line.MultiLines.First(it => it.TrimStart(' ').Contains(line)));
                else
                    return line.Contains("=>")
                               ? new Definition(DefinitionType.Methods, Line.GetBefore(line, "="))
                               : new Definition(DefinitionType.Methods, line);

            // ReSharper disable once InvertIf
            if (RegEx.IsField(line) && RegEx.IsAccessModifier(line))
                return line.Contains(" = ")
                           ? new Definition(DefinitionType.Fields, Line.GetBefore(line, " = "))
                           : new Definition(DefinitionType.Fields, line);

            return RegEx.IsLineBreak(line)
                       ? new Definition(DefinitionType.LineBreak, line)
                       : new Definition(DefinitionType.Unknown, line);
        }

        //

        private static string RemoveSlashes(string line) => 
            line.Replace("//", "");

        private static string RemoveSummary(string line)
        {
            if (line.Contains("/// <summary>") ||
                line.Contains("/// </summary>"))
                return "";

            var text = line.Trim('/', '/', '/').Trim();
            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
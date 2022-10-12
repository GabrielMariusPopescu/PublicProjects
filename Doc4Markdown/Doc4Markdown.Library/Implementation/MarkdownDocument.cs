using System;
using System.Collections.Generic;
using System.Linq;
using Doc4Markdown.Library.Extensions;
using Doc4Markdown.Library.Helper;

namespace Doc4Markdown.Library.Implementation
{
    public class MarkdownDocument
    {
        public IEnumerable<string> GetMarkdowns(IEnumerable<string> lines)
        {
            var markdown = lines
                          .Select(line => line.Trim())
                          .Select(ReplaceBrackets)
                          .Select(GetSpecific)
                          .Select(line => line + Environment.NewLine)
                          .ToList();

            TrimLastNewLine(markdown);

            return markdown;
        }

        //
        private static string ReplaceBrackets(string line)
        {
            if (line.Contains("XmlComments:"))
                return line;

            if (line.Contains("<") || line.Contains(">"))
                return line.Replace("<", "&lt;").Replace(">", "&gt;");
            return line;
        }

        private static string GetSpecific(string definition)
        {
            if (DefinitionRegEx.IsTaskDefinition(definition))
                return MarkdownDocumentProcess.GenerateTable(definition);
            if (DefinitionRegEx.IsTitleDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "#");
            if (DefinitionRegEx.IsProjectDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "##");
            if (DefinitionRegEx.IsXmlCommentDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "```") + "```";
            if (DefinitionRegEx.IsInterfaceDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "###");
            if (DefinitionRegEx.IsMemberDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "####");
            if (DefinitionRegEx.IsEnumDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "###");
            if (DefinitionRegEx.IsEnumeratorDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "####");
            if (DefinitionRegEx.IsClassDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "###");
            if (DefinitionRegEx.IsConstructorDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "####");
            if (DefinitionRegEx.IsDestructorDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "####");
            if (DefinitionRegEx.IsMethodDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "####");
            if (DefinitionRegEx.IsPropertyDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "#####");
            if (DefinitionRegEx.IsFieldDefinition(definition))
                return MarkdownDocumentProcess.Replace(definition, "#####");
            return DefinitionRegEx.IsLineBreakDefinition(definition)
                       ? MarkdownDocumentProcess.Replace(definition, "---")
                       : MarkdownDocumentProcess.ChooseType(definition);
        }

        private static void TrimLastNewLine(List<string> markdown)
        {
            markdown.Reverse();
            var first = markdown.First();
            markdown.Remove(first);

            var trimmed = first.TrimEnd('\n').TrimEnd('\r');
            markdown.Insert(0, trimmed);

            markdown.Reverse();
        }
    }
}
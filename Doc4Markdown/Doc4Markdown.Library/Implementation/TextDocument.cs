using System.Collections.Generic;
using System.Linq;
using Doc4Markdown.Library.Extensions;
using Doc4Markdown.Library.Helper;

namespace Doc4Markdown.Library.Implementation
{
    public class TextDocument
    {
        public List<Definition> GetDefinitions(List<string> definitions)
        {
            Line.GetNextLine(definitions);

            var title = definitions.First();
            var projects = definitions
                          .Where(RegEx.AreProjects)
                          .Select(it => it.Substring(0, it.LastIndexOf('.')))
                          .ToList();

            var lines = new List<Definition> {new Definition(DefinitionType.Title, title)};
            lines
               .AddRange(projects.Select(project => new Definition(DefinitionType.Projects, project.Substring(project.LastIndexOf('\\')).TrimStart('\\'))));

            lines.AddRange(definitions
                          .Select(line => line.Trim())
                          .Select(TextDocumentProcess.GetDefinition)
                          .Where(it => !(it.Type == DefinitionType.XmlComments && it.Line == ""))
                          .ToList());

            return lines;
        }

        public IEnumerable<string> EliminateSomeDefinitions(List<Definition> definitions)
        {
            return definitions
                  .Where(definition => definition.Type != DefinitionType.Unknown)
                  .Where(definition => definition.Type != DefinitionType.Events)
                  .Where(definition => definition.Line != "//")
                  .Select(definition => definition.Type + ": " + definition.Line.TrimEnd(';'))
                  .ToList();
        }
    }
}
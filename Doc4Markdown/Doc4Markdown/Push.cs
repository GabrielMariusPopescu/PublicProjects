using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Doc4Markdown.Library.Helper;

namespace Doc4Markdown
{
    public static class Push
    {
        public static string ProjectName { get; private set; }

        //
        private static List<string> Lines { get; set; }

        public static void Prepare(string selected)
        {
            var projects = Pull.GetProjects(selected);
            var index = 0;
            var dict = projects.ToDictionary(project => index++);

            Console.WriteLine("Which project do you want to create documentation for? ");
            foreach (var kv in dict)
            {
                ProjectName = Pull.GetProjectsNames(kv);
                Console.WriteLine($"{kv.Key}\t{ProjectName}");
            }

            Console.Write("Your option: ");
            var number = Convert.ToInt32(Console.ReadLine());

            var result = Line.GetBefore(dict[number], ".csproj");
            ProjectName = result.Substring(0, result.LastIndexOf('\\'));
        }

        public static void Initialize(string path)
        {
            var directories = Pull.GetDirectories(path);
            var files = Pull.GetFiles(directories, path);
            Lines = Pull.GetLines(files, path);
        }

        public static void GenerateDocumentation(string selectedProject)
        {
            var text = Document.CreateDefinitions(Lines);
            var markdown = Document.CreateMarkdown(text);
            var html = Document.CreateHtml(markdown);

            Console.Clear();
            WriteToFile(selectedProject, "txt", text, "md", markdown, "html", html);
            Console.WriteLine(ProjectName != null
                                  ? $"Check the files (text, markdown and html) generated for {Line.GetAfter(ProjectName, "ls.common").TrimStart('\\')}."
                                  : $"Check the files (text, markdown and html) generated for {Pull.GetSolutionName(selectedProject)}.");
        }

        //
        private static void WriteToFile(string selectedProject, string txtExt, List<string> text, string mdExt, List<string> markdown, string htmlExt,
                                        IEnumerable<string> html)
        {
            var path = Path.GetFullPath("../../OUTPUT");
            var name = selectedProject.Substring(selectedProject.LastIndexOf("\\", StringComparison.Ordinal));

            File.WriteAllLines($"{path}{name}.{txtExt}", text);
            File.WriteAllLines($"{path}{name}.{mdExt}", markdown);
            File.WriteAllLines($"{path}{name}.{htmlExt}", html);
        }
    }
}
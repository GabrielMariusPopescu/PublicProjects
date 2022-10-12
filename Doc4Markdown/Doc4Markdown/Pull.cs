using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Doc4Markdown.Library.Helper;

namespace Doc4Markdown
{
    public static class Pull
    {
        public static List<string> GetDirectories(string selectedProject)
        {
            var directories = Directory.EnumerateDirectories(selectedProject, "*.*", SearchOption.AllDirectories)
                                       .Where(RegEx.AreExcludedDirectories)
                                       .ToList();

            return (from directory in directories
                    let isEmpty = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).Length == 0
                    where !isEmpty
                    select directory)
               .ToList();
        }

        public static List<string> GetFiles(IEnumerable<string> directories, string selectedProject)
        {
            var files = new List<string>();
            foreach (var directory in directories)
                GetAllFiles(directory, files);

            GetAllFiles(selectedProject, files);
            return files;
        }

        public static List<string> GetLines(IEnumerable<string> files, string path)
        {
            var lines = new List<string> {GetTitle(path)};

            lines
               .AddRange(GetProjects(path)
                            .ToList());

            foreach (var file in files)
            {
                lines
                   .AddRange(File.ReadAllLines(file, Encoding.Default));

                lines.Add("------");
            }

            return lines
                  .Where(line => line.Length > 2)
                  .ToList();
        }

        public static List<string> GetProjects(string selection)
        {
            return
                Directory.GetFiles(selection, "*.csproj", SearchOption.AllDirectories)
                         .ToList();
        }

        public static string GetSolutionName(string solution)
        {
            return Line.GetAfter(solution, "\\").TrimStart('\\');
        }

        public static string GetProjectsNames(KeyValuePair<int, string> project)
        {
            return project
                  .Value
                  .Substring(project.Value.LastIndexOf('\\'), project.Value.LastIndexOf('.') - project.Value.LastIndexOf('\\'))
                  .TrimStart('\\');
        }

        //
        private static void GetAllFiles(string selected, List<string> files)
        {
            files.AddRange(Directory.GetFiles(selected, "*.cs")
                                    .Where(RegEx.AreExcludedFiles)
                                    .ToList());
        }

        private static string GetTitle(string selectedProject)
        {
            var name = selectedProject.Substring(selectedProject.LastIndexOf('\\'));
            var title = RegEx.GetTitleRegex;

            return title.Replace(name.TrimStart('\\'), " ").ToUpper();
        }
    }
}
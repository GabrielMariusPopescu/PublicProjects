using System;

namespace Doc4Markdown
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            PositionWindow();
            var solution = Pull.GetSolutionName(args[0]);
            Console.WriteLine("============================================================================");
            Console.WriteLine($"\t1 - Create documentation for the whole {solution.ToUpper()} solution.");
            Console.WriteLine("\t2 - Create documentation for one of the its project.");
            Console.WriteLine("============================================================================");
            Console.WriteLine();
            Console.Write("Your option: ");

            int.TryParse(Console.ReadLine(), out var number);
            Console.Clear();

            switch (number)
            {
                case 1:
                    Push.Initialize(args[0]);
                    Push.GenerateDocumentation(args[0]);
                    break;
                case 2:
                    Push.Prepare(args[0]);
                    Push.Initialize(Push.ProjectName);
                    Push.GenerateDocumentation(Push.ProjectName);
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }

            Console.ReadLine();
        }

        //

        private static void PositionWindow()
        {
            Console.SetWindowSize(120, 45);
        }
    }
}
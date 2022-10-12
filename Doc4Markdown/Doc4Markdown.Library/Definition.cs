namespace Doc4Markdown.Library
{
    public class Definition
    {
        public Definition(DefinitionType type, string line)
        {
            Type = type;
            Line = line;
        }

        public DefinitionType Type { get; }
        public string Line { get; }
    }
}
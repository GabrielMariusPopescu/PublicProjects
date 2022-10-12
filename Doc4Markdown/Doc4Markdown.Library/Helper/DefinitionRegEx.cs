using System.Text.RegularExpressions;

namespace Doc4Markdown.Library.Helper
{
    public static class DefinitionRegEx
    {
        public static bool IsTaskDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bTasks: \b", RegexOptions.Compiled);

        public static bool IsTitleDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bTitle: \b", RegexOptions.Compiled);

        public static bool IsProjectDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bProjects: \b", RegexOptions.Compiled);

        public static bool IsXmlCommentDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bXmlComments: \b", RegexOptions.Compiled);

        public static bool IsInterfaceDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bInterfaces: \b", RegexOptions.Compiled);

        public static bool IsMemberDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bMembers: \b", RegexOptions.Compiled);

        public static bool IsEnumDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bEnums: \b", RegexOptions.Compiled);

        public static bool IsEnumeratorDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bEnumerators: \b", RegexOptions.Compiled);

        public static bool IsClassDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bClasses: \b", RegexOptions.Compiled);

        public static bool IsConstructorDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bConstructors: \b", RegexOptions.Compiled);

        public static bool IsDestructorDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bDestructors: \b", RegexOptions.Compiled);

        public static bool IsMethodDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bMethods: \b", RegexOptions.Compiled);

        public static bool IsPropertyDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bProperties: \b", RegexOptions.Compiled);

        public static bool IsFieldDefinition(string definition) => 
            Regex.IsMatch(definition, @"\bFields: \b", RegexOptions.Compiled);

        public static bool IsLineBreakDefinition(string definition) => 
            Regex.IsMatch(definition, @"LineBreak: ", RegexOptions.Compiled);
    }
}
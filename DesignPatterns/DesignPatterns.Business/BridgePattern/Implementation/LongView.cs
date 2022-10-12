using DesignPatterns.Business.BridgePattern.Contracts;

namespace DesignPatterns.Business.BridgePattern.Implementation
{
    public class LongView : View
    {
        public LongView(IResource resource)
            : base(resource) { }

        public override string Show()
        {
            var snippet = resource.Snippet();
            return $"This is the long view representation of the {snippet}";
        }
    }
}

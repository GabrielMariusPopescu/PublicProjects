using DesignPatterns.Business.BridgePattern.Contracts;

namespace DesignPatterns.Business.BridgePattern.Implementation
{
    public class ShortView : View
    {
        public ShortView(IResource resource)
            : base(resource) { }

        public override string Show()
        {
            var snippet = resource.Snippet();
            return $"This is the short view representation of the {snippet}";
        }
    }
}

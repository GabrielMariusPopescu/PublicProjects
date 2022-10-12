namespace DesignPatterns.Business.BridgePattern.Contracts
{
    public abstract class View
    {
        protected View(IResource resource) => this.resource = resource;

        public abstract string Show();


        //

        protected readonly IResource resource;
    }
}

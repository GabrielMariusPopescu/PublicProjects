namespace DesignPatterns.Business.CommandPattern.Contracts
{
    public interface ICommand
    {
        void Do();

        void Undo();
    }
}

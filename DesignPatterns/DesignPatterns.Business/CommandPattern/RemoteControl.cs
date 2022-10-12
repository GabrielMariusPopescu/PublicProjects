using DesignPatterns.Business.CommandPattern.Contracts;

namespace DesignPatterns.Business.CommandPattern
{
    public class RemoteControl
    {
        public RemoteControl(ICommand onCommand, ICommand offCommand, ICommand dimCommand, ICommand brightCommand)
        {
            this.onCommand = onCommand;
            this.offCommand = offCommand;
            this.dimCommand = dimCommand;
            this.brightCommand = brightCommand;
        }

        public void ClickOn() => onCommand.Do();

        public void UndoClickOn() => onCommand.Undo();

        public void ClickOff() => offCommand.Do();

        public void UndoClickOff() => offCommand.Undo();

        public void ClickDim() => dimCommand.Do();

        public void UndoClickDim() => dimCommand.Undo();

        public void ClickBright() => brightCommand.Do();

        public void UndoClickBright() => brightCommand.Undo();

        //

        private readonly ICommand onCommand;
        private readonly ICommand offCommand;
        private readonly ICommand dimCommand;
        private readonly ICommand brightCommand;
    }
}

namespace DesignPatterns.Business.CommandPattern.Models
{
    public class Light
    {
        public string State { get; private set; }

        public void TurnOn() => State = "Light is turned on.";

        public void TurnOff() => State = "Light is turned off.";

        public void Dim() => State = "Light is dimmed.";

        public void Bright() => State = "Light is brighter.";
    }
}
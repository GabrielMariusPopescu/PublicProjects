namespace DesignPatterns.Business.FacadePattern
{
    public class CodecFactory
    {
        public string Filename => GetType().Name;
    }
}
namespace MetaBuilder.Core.Interfaces
{
    public interface ISupply
    {
        int Supply { get; }
        bool IsFinished(double time);
    }
}
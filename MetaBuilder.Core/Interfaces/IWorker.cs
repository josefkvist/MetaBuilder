namespace MetaBuilder.Core.Interfaces
{
    public interface IWorker
    {
        bool HasFinishedMining(double time, int noOfDrones);
    }
}

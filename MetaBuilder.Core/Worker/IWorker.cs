using System.Security.Cryptography.X509Certificates;

namespace MetaBuilder.Core.Worker
{
    public interface IWorker
    {
        bool HasFinishedMining(double time, int noOfDrones);
    }
}

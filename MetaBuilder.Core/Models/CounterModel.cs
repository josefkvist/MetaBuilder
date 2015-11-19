using System.Collections.Generic;

namespace MetaBuilder.Core.Models
{
    public class CounterModel
    {
        public CounterModel()
        {
        }

        public CounterModel(CounterModel lastCounterModel)
        {
            Minerals = lastCounterModel.Minerals;
            Gas = lastCounterModel.Gas;
            Supply = lastCounterModel.Supply;
            SupplyLimit = lastCounterModel.SupplyLimit;
        }

        public int Minerals { get; set; }
        public int Gas { get; set; }
        public int Supply { get; set; }
        public int SupplyLimit { get; set; }
    }
}

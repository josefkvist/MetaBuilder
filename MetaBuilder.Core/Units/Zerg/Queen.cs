using MetaBuilder.Core.Interfaces;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Queen : Unit
    {

        public int Energy { get; set; }
        public Queen(double created)
            : base(created, UnitSettings.Queen.BuildTime, UnitSettings.Queen.Supply, UnitSettings.Queen.Name)
        {
            Energy = 100;
        }
    }
}
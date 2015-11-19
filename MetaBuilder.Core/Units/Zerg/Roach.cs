using MetaBuilder.Core.Interfaces;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Roach : Unit
    {
        public Roach(double created)
            : base(created, UnitSettings.Ling.BuildTime, UnitSettings.Ling.Supply, UnitSettings.Ling.Name)
        {
        }
    }
}
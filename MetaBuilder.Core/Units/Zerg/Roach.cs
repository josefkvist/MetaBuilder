using MetaBuilder.Core.Interfaces;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Roach : Unit
    {
        public Roach(double created)
            : base(created, UnitSettings.Roach.BuildTime, UnitSettings.Roach.Supply, UnitSettings.Roach.Name)
        {
        }
    }
}
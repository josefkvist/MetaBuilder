using MetaBuilder.Core.Interfaces;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Baneling : Unit
    {
        public Baneling(double created)
            : base(created, UnitSettings.Bane.BuildTime, UnitSettings.Bane.Supply, UnitSettings.Bane.Name)
        {
        }
    }
}
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Settings;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Baneling : Unit
    {
        public Baneling(double created)
            : base(created, ZergUnitSettings.Bane.BuildTime, ZergUnitSettings.Bane.Supply, ZergUnitSettings.Bane.Name)
        {
        }
    }
}
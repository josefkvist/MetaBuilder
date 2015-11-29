using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Settings;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Roach : Unit
    {
        public Roach(double created)
            : base(created, ZergUnitSettings.Roach.BuildTime, ZergUnitSettings.Roach.Supply, ZergUnitSettings.Roach.Name)
        {
        }
    }
}
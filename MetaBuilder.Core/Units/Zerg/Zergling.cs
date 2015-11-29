using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Settings;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Zergling : Unit
    {
        public Zergling(double created) : base(created, ZergUnitSettings.Ling.BuildTime, ZergUnitSettings.Ling.Supply, ZergUnitSettings.Ling.Name)
        {
        }
    }
}
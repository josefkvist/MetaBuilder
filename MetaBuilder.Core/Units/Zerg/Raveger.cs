using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Settings;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Raveger : Unit
    {
        public Raveger(double created)
            : base(created, ZergUnitSettings.Raveger.BuildTime, ZergUnitSettings.Raveger.Supply, ZergUnitSettings.Raveger.Name)
        {
        }
    }
}
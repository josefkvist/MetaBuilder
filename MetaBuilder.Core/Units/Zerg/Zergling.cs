using MetaBuilder.Core.Interfaces;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Zergling : Unit
    {
        public Zergling(double created) : base(created, UnitSettings.Ling.BuildTime, UnitSettings.Ling.Supply, UnitSettings.Ling.Name)
        {
        }
    }
}
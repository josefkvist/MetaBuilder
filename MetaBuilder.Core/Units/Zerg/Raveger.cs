using MetaBuilder.Core.Interfaces;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Raveger : Unit
    {
        public Raveger(double created)
            : base(created, UnitSettings.Raveger.BuildTime, UnitSettings.Raveger.Supply, UnitSettings.Raveger.Name)
        {
        }
    }
}
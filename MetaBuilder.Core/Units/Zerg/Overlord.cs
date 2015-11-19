using System;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Models;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Overlord : Unit, ISupply
    {
        public new int Supply { get; private set; }
     
        public Overlord() :this(-UnitSettings.Overlord.BuildTime)
        {
        }

        public Overlord(double created) 
            : base(created, UnitSettings.Overlord.BuildTime, UnitSettings.Overlord.Supply, UnitSettings.Overlord.Name)
        {
            Supply = 8;
        }

        public override bool IsFinished(double time)
        {
            return time >= _created + _buildTime;
        }
    }
}
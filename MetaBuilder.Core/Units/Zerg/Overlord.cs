using System;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Models;
using MetaBuilder.Core.Settings;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Overlord : Unit, ISupply
    {
        public new int Supply { get; private set; }
     
        public Overlord() :this(-ZergUnitSettings.Overlord.BuildTime)
        {
        }

        public Overlord(double created) 
            : base(created, ZergUnitSettings.Overlord.BuildTime, ZergUnitSettings.Overlord.Supply, ZergUnitSettings.Overlord.Name)
        {
            Supply = 8;
        }

        public override bool IsFinished(double time)
        {
            return time >= _created + _buildTime;
        }
    }
}
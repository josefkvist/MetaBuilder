using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaBuilder.Core.Worker;

namespace MetaBuilder.Core.Resources
{
    public class MineralPatch
    {
        public List<MineralDrone> MineralDrones { get; set; }

        public MineralPatch()
        {
            MineralDrones = new List<MineralDrone>();
        }

    }
}

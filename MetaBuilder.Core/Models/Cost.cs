using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaBuilder.Core.Models
{
    public struct Cost
    {
        public Cost(int minerals, int gas = 0)
            : this()
        {
            Minerals = minerals;
            Gas = gas;
        }

        public int Minerals { get; set; }
        public int Gas { get; set; }
    }
}

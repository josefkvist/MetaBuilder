using System.Collections.Generic;
using MetaBuilder.Core.Models;

namespace MetaBuilder.Core.Bases
{
    public abstract class Base
    {
        protected double StepTime;
        public Base(double stepTime)
        {
            InProductions = new Dictionary<int, IProduction>();
            StepTime = stepTime;
            
        }

        public Dictionary<int, IProduction> InProductions { get; set; }
         
    }
}
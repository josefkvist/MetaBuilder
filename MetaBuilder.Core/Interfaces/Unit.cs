using System;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Models;

namespace MetaBuilder.Core.Interfaces
{
    public abstract class Unit: IProduction
    {
        public double Supply { get; private set; }
        public double Created { get { return _created; } }
        protected double _created;
        protected bool _isFinished;
        protected double _buildTime;
        public string Name { get; set; }

        protected Unit(double created, double buildTime, int supply, string name)
        {
            _created = created;
            _buildTime = buildTime;
            Name = name;
            _isFinished = _created < 0;
            Supply = supply;
        }

        public bool IsBuiltRightNow(double time)
        {
            var delta = time - _created - _buildTime;
            var isBuiltRightNow = delta.ToMilliSeconds() 
                < Settings.TimeStep.ToMilliSeconds() && delta.ToMilliSeconds() >= 0;
            return isBuiltRightNow;
        }
        public virtual int PromilleDone(double time)
        {
            var timeElapsed = time - _created;
            var percentDone = timeElapsed / _buildTime;
            var promilleDone = percentDone.ToMilliSeconds()*100;
            return promilleDone < (int)Percentage.P100
                ? (int)percentDone.ToMilliSeconds()*100
                : (int)Percentage.P100;
        }
        public virtual bool IsFinished(double time)
        {

            return time >= _created + _buildTime;
        }
    }
}
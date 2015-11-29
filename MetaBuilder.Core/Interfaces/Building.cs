using System;
using System.Collections.Generic;
using System.Linq;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Models;
using MetaBuilder.Core.Settings;

namespace MetaBuilder.Core.Interfaces
{
    public abstract class Building : IProduction
    {
        protected double _created;
        protected double _buildTime;
        private bool _isIdle;
        public string Name { get; set; }
        protected Building(double createdAt, double buildTime, string name)
        {
            _created = createdAt;
            _buildTime = buildTime;
            Name = name;
            _isIdle = true;
        }

        public virtual bool IsFinished(double time)
        {
            return time >= _created + _buildTime;
        }

        public bool IsBuiltRightNow(double time)
        {
            var delta = time - _created - _buildTime;

            return delta.ToMilliSeconds() < CoreSettings.TimeStep.ToMilliSeconds() 
                && delta.ToMilliSeconds() >= 0;

        }


        public bool IsIdle(double time)
        {
            if (!IsFinished(time)) return false;
            return _isIdle;
        }

        public bool SwitchIdle()
        {
            _isIdle = !_isIdle;
            return _isIdle;
        }

        public int PromilleDone(double time)
        {
            var timeElapsed = time - _created;
            var percentDone = timeElapsed/_buildTime;
            return percentDone.ToMilliSeconds()*100 < 100000
                ? (int)percentDone.ToMilliSeconds()*100
                : 100000;
        }
    }
}
using System;

namespace MetaBuilder.Core.Models
{
    public interface IProduction
    {
        int PromilleDone(double time);
        string Name { get; }
        bool IsBuiltRightNow(double time);
    }
}
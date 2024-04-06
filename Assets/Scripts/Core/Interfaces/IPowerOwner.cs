using System;
using Core.Power;

namespace Core
{
    public interface IPowerOwner
    {
        void AddPower(AbstractPower power);
        bool HasPower(Type type);
        void RemovePower(Type type);
        void ReducePower(Type powerType, int amount);
    }
}
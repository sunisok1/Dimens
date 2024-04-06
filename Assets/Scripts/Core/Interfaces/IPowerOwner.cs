using System;

namespace Core
{
    public interface IPowerOwner
    {
        void AddPower(AbstractPower power);
        bool HasPower(Type type);
    }
}
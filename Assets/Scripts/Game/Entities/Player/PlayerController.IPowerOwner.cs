using System;
using System.Collections.Generic;
using Core;

namespace Game.Entities.Player
{
    public partial class Player : IPowerOwner
    {
        private Dictionary<Type, AbstractPower> powers = new();

        public void AddPower(AbstractPower power)
        {
            powers.Add(power.GetType(), power);
        }

        public bool HasPower(Type type)
        {
            return powers.ContainsKey(type);
        }
    }
}
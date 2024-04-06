using System;
using System.Collections.Generic;
using Core;
using Core.Power;

namespace Game.Entities.Player
{
    public partial class Player : IPowerOwner
    {
        private readonly Dictionary<Type, AbstractPower> powers = new();

        public void AddPower(AbstractPower power)
        {
            Type type = power.GetType();
            if (!powers.TryAdd(type, power))
            {
                powers[type] += power;
                return;
            }

            power.OnAdded();
        }

        public void RemovePower(Type type)
        {
            powers.Remove(type, out AbstractPower power);
            power.OnRemoved();
        }

        public bool HasPower(Type type)
        {
            return powers.ContainsKey(type);
        }


        public void ReducePower(Type powerType, int amount)
        {
            powers[powerType].amount -= amount;
        }
    }
}
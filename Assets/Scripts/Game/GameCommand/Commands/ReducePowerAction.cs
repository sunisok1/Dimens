using System;
using Core;

namespace Game.GameCommand.Commands
{
    public class ReducePowerAction : Command
    {
        public ReducePowerAction(IPowerOwner owner, Type powerType, int amount) : base(() => owner.ReducePower(powerType, amount))
        {
        }
    }
}
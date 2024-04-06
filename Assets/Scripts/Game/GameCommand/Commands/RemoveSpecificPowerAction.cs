using System;
using Core;

namespace Game.GameCommand.Commands
{
    public class RemoveSpecificPowerAction : Command
    {
        public RemoveSpecificPowerAction(IPowerOwner owner, Type powerType) : base(() => { owner.RemovePower(powerType); })
        {
        }
    }
}
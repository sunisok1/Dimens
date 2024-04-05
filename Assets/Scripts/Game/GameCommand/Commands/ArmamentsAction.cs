using System;
using Core;

namespace Game.GameCommand.Commands
{
    public class ArmamentsAction : Command
    {
        public ArmamentsAction(bool upgraded) : base(() => throw new NotImplementedException())
        {
        }
    }
}
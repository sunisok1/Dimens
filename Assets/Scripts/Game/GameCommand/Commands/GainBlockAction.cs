using System;
using Core;
using Core.Entities;

namespace Game.GameCommand.Commands
{
    public class GainBlockAction : Command
    {
        public GainBlockAction(AbstractEntity user, AbstractEntity target, int block) : base(() => throw new NotImplementedException())
        {
        }
    }
}
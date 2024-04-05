using System;
using Core;

namespace Game.GameCommand.Commands
{
    public class GainBlockAction : Command
    {
        public GainBlockAction(IUserController user, IUserController userController, int block) : base(() => throw new NotImplementedException())
        {
        }
    }
}
using Core;
using Core.Entities;

namespace Game.GameCommand.Commands
{
    public class ApplyPowerAction : Command
    {
        public ApplyPowerAction(AbstractEntity user, IPowerOwner powerOwner, AbstractPower power) : base(() => { powerOwner.AddPower(power); })
        {
        }
    }
}
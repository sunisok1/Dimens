using Core;
using Core.Power;

namespace Game.GameCommand.Commands
{
    public class ApplyPowerAction : Command
    {
        public ApplyPowerAction(IPowerOwner powerOwner, AbstractPower power) : base(() => powerOwner.AddPower(power))
        {
        }
    }
}
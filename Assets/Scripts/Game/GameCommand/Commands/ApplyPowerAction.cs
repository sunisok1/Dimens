using Core;

namespace Game.GameCommand.Commands
{
    public class ApplyPowerAction : Command
    {
        public ApplyPowerAction(IUserController user, ITarget target, AbstractPower power) : base(() => { target.AddPower(power); })
        {
        }
    }
}
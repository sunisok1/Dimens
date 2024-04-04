using Core;

namespace Game.GameCommand.Commands
{
    public class ApplyPowerAction : ICommand
    {
        private readonly IUserController user;
        private readonly ITarget target;
        private readonly AbstractPower power;

        public ApplyPowerAction(IUserController user, ITarget target, AbstractPower power)
        {
            this.user = user;
            this.target = target;
            this.power = power;
        }

        public void Execute()
        {
            target.AddPower(power);
        }
    }
}
using Core;

namespace Game.GameCommand.Commands
{
    public class ApplyPowerAction : ICommand
    {
        private readonly IUserController user;
        private readonly ITarget powerCapable;
        private readonly AbstractPower power;

        public ApplyPowerAction(IUserController user, ITarget powerCapable, AbstractPower power)
        {
            this.user = user;
            this.powerCapable = powerCapable;
            this.power = power;
        }

        public void Execute()
        {
            powerCapable.AddPower(power);
        }
    }
}
using System;
using Classes;
using Classes.Entities;
using Core.Powers;
using Core.Powers.Model;

namespace Core.GameCommand.Commands
{
    public class ApplyPowerAction : ICommand
    {
        private readonly IUserController user;
        private readonly IPowerCapable powerCapable;
        private readonly AbstractPower power;

        public ApplyPowerAction(IUserController user, IPowerCapable powerCapable, AbstractPower power)
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
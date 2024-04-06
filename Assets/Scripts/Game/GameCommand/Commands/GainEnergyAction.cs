using Core;

namespace Game.GameCommand.Commands
{
    public class GainEnergyAction : Command
    {
        public GainEnergyAction(IEnergyOwner owner, int amount) : base(() => owner.GainEnergy(amount))
        {
        }
    }
}
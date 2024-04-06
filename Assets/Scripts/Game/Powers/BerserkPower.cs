using Core;
using Core.Commands;
using Core.Localization;
using Core.Power;
using Game.GameCommand.Commands;

namespace Game.Powers
{
    public class BerserkPower : AbstractPower
    {
        private const string ID = "BerserkPower";
        private static readonly PowerStrings powerStrings = CardCrawlGame.languagePack.GetPowerStrings(ID);

        public BerserkPower(IPowerOwner owner, int amount) : base(ID, powerStrings.NAME, "berserkPower", powerStrings.DESCRIPTIONS, owner, PowerType.Debuff)
        {
            this.amount = amount;
        }

        private void AtStartOfTurn()
        {
            if (owner is IEnergyOwner energyOwner)
                CommandInvoker.ExecuteCommand(new GainEnergyAction(energyOwner, 1));
        }

        public override void OnAdded()
        {
            base.OnAdded();

            if (owner is ITurnRunner turnRunner)
                turnRunner.AtStartOfTurn += AtStartOfTurn;
        }

        public override void OnRemoved()
        {
            base.OnRemoved();

            if (owner is ITurnRunner turnRunner)
                turnRunner.AtStartOfTurn -= AtStartOfTurn;
        }
    }
}
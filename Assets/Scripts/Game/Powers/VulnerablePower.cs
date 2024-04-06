using Core;
using Core.Commands;
using Core.Localization;
using Core.Power;
using Game.GameCommand.Commands;

namespace Game.Powers
{
    public class VulnerablePower : AbstractPower
    {
        private const string ID = "Vulnerable";
        private static readonly PowerStrings powerStrings = CardCrawlGame.languagePack.GetPowerStrings(ID);

        public VulnerablePower(IPowerOwner owner, int amount) : base(ID, powerStrings.NAME, "vulnerable", powerStrings.DESCRIPTIONS, owner, PowerType.Debuff)
        {
            this.amount = amount;
        }
        
        public void AtEndOfRound()
        {
            if (amount == 0)
            {
                CommandInvoker.ExecuteCommand(new RemoveSpecificPowerAction(owner, typeof(VulnerablePower)));
            }
            else
            {
                CommandInvoker.ExecuteCommand(new ReducePowerAction(owner, typeof(VulnerablePower), 1));
            }
        }

        public override void OnAdded()
        {
            base.OnAdded();
            if (owner is ITurnRunner turnRunner)
                turnRunner.AtEndOfRound += AtEndOfRound;
        }

        public override void OnRemoved()
        {
            base.OnRemoved();

            if (owner is ITurnRunner turnRunner)
                turnRunner.AtEndOfRound -= AtEndOfRound;
        }
    }
}
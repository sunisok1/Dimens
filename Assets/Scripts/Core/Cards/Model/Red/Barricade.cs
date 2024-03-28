using Classes;
using Classes.Entities;
using Common;
using Core.GameCommand;
using Core.GameCommand.Commands;
using Core.Powers;
using Core.Powers.Model;

namespace Core.Cards.Model.Red
{
    internal class Barricade : SlayTheSpireCard
    {
        private const string ID = "Barricade";
        private static readonly CardStrings cardStrings = LocalizedStrings.GetCardStrings(ID);

        public Barricade() : base(ID, cardStrings.NAME, "red/power/barricade", 3, cardStrings.DESCRIPTION, CardType.Attack, CardRarity.Basic, CardColor.Red, CardTarget.Self)
        {
        }

        public override void Upgrade()
        {
            base.Upgrade();
            UpgradeCost(2);
        }

        public override AbstractCard MakeCopy()
        {
            return new Barricade();
        }

        public override void Use(IUserController user, IHealthController target)
        {
            if (target is not IPowerCapable powerCapable) return;
            if (powerCapable.HasPower(ID)) return;
            CommandInvoker.ExecuteCommand(new ApplyPowerAction(user, powerCapable, new BarricadePower(powerCapable)));
        }
    }
}
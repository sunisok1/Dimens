using System;
using Core;
using Core.Card;
using Core.Commands;
using Core.Entities;
using Core.Localization;
using Game.GameCommand.Commands;
using Game.Powers;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class Barricade : SlayTheSpireCard
    {
        private const string ID = "Barricade";
        private static readonly CardStrings cardStrings = CardCrawlGame.languagePack.GetCardStrings(ID);

        public Barricade() : base(ID, cardStrings.NAME, "red/power/barricade", 3, cardStrings.DESCRIPTION, CardType.Power, CardColor.Red, CardRarity.Rare, CardTarget.Self)
        {
        }

        public override void Upgrade()
        {
            UpgradeName();
            costForTurn = Math.Max(0, costForTurn + 2 - Cost);
            Cost = 2;
        }

        protected override AbstractCard MakeCopy()
        {
            return new Barricade();
        }

        public override void Use(AbstractEntity user, AbstractEntity target)
        {
            if (target is not IPowerOwner powerOwner) return;
            if (powerOwner.HasPower(typeof(BarricadePower))) return;
            CommandInvoker.ExecuteCommand(new ApplyPowerAction(powerOwner, new BarricadePower(powerOwner)));
        }
    }
}
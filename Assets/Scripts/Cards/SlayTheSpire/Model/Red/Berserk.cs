using Core;
using Core.Card;
using Core.Commands;
using Core.Entities;
using Core.Localization;
using Game.GameCommand.Commands;
using Game.Powers;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class Berserk : SlayTheSpireCard, IMagicCard
    {
        private const string ID = "Berserk";
        private static readonly CardStrings cardStrings = CardCrawlGame.languagePack.GetCardStrings(ID);

        public int MagicNumber { get; private set; }

        public Berserk() : base(ID, cardStrings.NAME, "red/power/berserk", 3, cardStrings.DESCRIPTION, CardType.Power, CardColor.Red, CardRarity.Rare, CardTarget.Self)
        {
            MagicNumber = 2;
        }

        public override void Upgrade()
        {
            UpgradeName();
            MagicNumber -= 1;
        }

        protected override AbstractCard MakeCopy()
        {
            return new Berserk();
        }

        public override void Use(AbstractEntity user, AbstractEntity target)
        {
            if (target is not IPowerOwner powerOwner) return;
            CommandInvoker.ExecuteCommand(new ApplyPowerAction(powerOwner, new VulnerablePower(powerOwner, MagicNumber)));
            CommandInvoker.ExecuteCommand(new ApplyPowerAction(powerOwner, new BerserkPower(powerOwner, 1)));
        }
    }
}
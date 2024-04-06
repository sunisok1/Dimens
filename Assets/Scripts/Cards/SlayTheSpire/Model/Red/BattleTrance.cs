using Core;
using Core.Card;
using Core.Commands;
using Core.Entities;
using Core.Localization;
using Game.GameCommand.Commands;
using Game.Powers;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class BattleTrance : SlayTheSpireCard, IMagicCard
    {
        private const string ID = "Battle Trance";
        private static readonly CardStrings cardStrings = CardCrawlGame.languagePack.GetCardStrings(ID);
        public int MagicNumber { get; private set; }

        public BattleTrance() : base(ID, cardStrings.NAME, "red/skill/battle_trance", 0, cardStrings.DESCRIPTION, CardType.Skill, CardColor.Red, CardRarity.Uncommon, CardTarget.Self)
        {
            MagicNumber = 3;
        }

        public override void Use(AbstractEntity user, AbstractEntity target)
        {
            if (target is ICardOwner cardOwner)
                CommandInvoker.ExecuteCommand(new DrawCardAction(cardOwner, MagicNumber));
            if (target is IPowerOwner powerOwner)
                CommandInvoker.ExecuteCommand(new ApplyPowerAction(powerOwner, new NoDrawPower(powerOwner)));
        }

        protected override AbstractCard MakeCopy()
        {
            return new BattleTrance();
        }

        public override void Upgrade()
        {
            MagicNumber++;
        }
    }
}
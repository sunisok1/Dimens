using Core;
using Core.Card;
using Core.Commands;
using Core.Entities;
using Core.Localization;
using Game.GameCommand.Commands;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class Armaments : SlayTheSpireCard, IBlockCard
    {
        private const string ID = "Armaments";
        private static readonly CardStrings cardStrings = CardCrawlGame.languagePack.GetCardStrings(ID);
        public int Block { get; }

        public Armaments() : base(ID, cardStrings.NAME, "red/skill/armaments", 1, cardStrings.DESCRIPTION, CardType.Skill, CardColor.Red, CardRarity.Common, CardTarget.Self)
        {
            Block = 5;
        }

        public override void Upgrade()
        {
            UpgradeName();
            rawDescription = cardStrings.UPGRADE_DESCRIPTION;
        }


        protected override AbstractCard MakeCopy()
        {
            return new Armaments();
        }

        public override void Use(AbstractEntity user, AbstractEntity target)
        {
            CommandInvoker.ExecuteCommand(new GainBlockAction(user, user, Block));
            CommandInvoker.ExecuteCommand(new ArmamentsAction(Upgraded));
        }
    }
}
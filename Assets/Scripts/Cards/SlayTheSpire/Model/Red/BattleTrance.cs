using Common;
using Core;
using Core.Localization;
using Game.GameCommand;
using Game.GameCommand.Commands;
using Game.Powers.Model;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class BattleTrance : SlayTheSpireCard, IMagicCard
    {
        private const string ID = "Battle Trance";
        private static CardStrings cardStrings;
        public int MagicNumber { get; private set; }

        public BattleTrance() : base(ID, cardStrings.NAME, "red/skill/battle_trance", 0, cardStrings.DESCRIPTION, CardType.Skill, CardColor.Red, CardRarity.Uncommon, CardTarget.Self)
        {
            MagicNumber = 3;
        }

        public override void Use(IUserController user, ITarget target)
        {
            CommandInvoker.ExecuteCommand(new DrawCardAction(user, MagicNumber));
            CommandInvoker.ExecuteCommand(new ApplyPowerAction(user, target, new NoDrawPower(user)));
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
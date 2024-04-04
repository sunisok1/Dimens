using Core;
using Core.Card;
using Core.Localization;
using Game.GameCommand;
using Game.GameCommand.Commands;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class Bash : SlayTheSpireCard, IMagicCard, IDamageCard
    {
        private const string ID = "Bash";
        private static readonly CardStrings cardStrings = CardCrawlGame.languagePack.GetCardStrings(ID);
        public int Damage { get; private set; }
        public int MagicNumber { get; private set; }

        public Bash() : base(ID, cardStrings.NAME, "red/attack/bash", 2, cardStrings.DESCRIPTION, CardType.Attack, CardColor.Red, CardRarity.Basic, CardTarget.Enemy)
        {
            Damage = 8;
            MagicNumber = 2;
        }

        public override void Use(IUserController user, ITarget target)
        {
            CommandInvoker.ExecuteCommand(new DamageCommand(target, new DamageInfo(user, 6)));
        }

        public override void Upgrade()
        {
            UpgradeName();
            Damage += 2;
            MagicNumber += 1;
        }

        protected override AbstractCard MakeCopy()
        {
            return new Bash();
        }
    }
}
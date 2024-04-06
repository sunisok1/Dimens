using Core;
using Core.Card;
using Core.Commands;
using Core.Entities;
using Core.Localization;
using Game.GameCommand.Commands;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class Anger : SlayTheSpireCard, IDamageCard
    {
        private const string ID = "Anger";
        private static readonly CardStrings cardStrings = CardCrawlGame.languagePack.GetCardStrings(ID);
        public int Damage { get; private set; }

        public Anger() : base(ID, cardStrings.NAME, "red/attack/anger", 0, cardStrings.DESCRIPTION, CardType.Attack, CardColor.Red, CardRarity.Uncommon, CardTarget.Enemy)
        {
            Damage = 6;
        }

        public override void Upgrade()
        {
            UpgradeName();
            Damage += 2;
        }

        protected override AbstractCard MakeCopy()
        {
            return new Anger();
        }

        public override void Use(AbstractEntity user, AbstractEntity target)
        {
            if (target is IHealth health)
            {
                CommandInvoker.ExecuteCommand(new DamageCommand(health, new DamageInfo(user, Damage)));
            }

            CommandInvoker.ExecuteCommand(new MakeTempCardInDiscardAction(MakeStatEquivalentCopy(this), 1));
        }
    }
}
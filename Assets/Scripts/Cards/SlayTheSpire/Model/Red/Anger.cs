using Classes;
using Classes.Entities;
using Common;
using Core.GameCommand;
using Core.GameCommand.Commands;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class Anger : SlayTheSpireCard, IDamageCard
    {
        private const string ID = "Anger";
        private static readonly CardStrings cardStrings = LocalizedStrings.GetCardStrings(ID);
        public int Damage { get; private set; }

        public Anger() : base(ID, cardStrings.NAME, "red/attack/anger", 0, cardStrings.DESCRIPTION, CardType.Attack, CardRarity.Basic, CardColor.Red, CardTarget.Enemy)
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

        public override void Use(IUserController user, IHealthController target)
        {
            CommandInvoker.ExecuteCommand(new DamageCommand(target, new DamageInfo(user, Damage)));
            CommandInvoker.ExecuteCommand(new MakeTempCardInDiscardAction(MakeStatEquivalentCopy(this), 1));
        }
    }
}
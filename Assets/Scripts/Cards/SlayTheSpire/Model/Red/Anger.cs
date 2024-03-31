using Classes;
using Classes.Core;
using Classes.Core.Entities;
using Common;
using Game.GameCommand;
using Game.GameCommand.Commands;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class Anger : SlayTheSpireCard, IDamageCard
    {
        private const string ID = "Anger";
        private static readonly CardStrings cardStrings = LocalizedStrings.GetCardStrings(ID);
        public int Damage { get; private set; }

        public Anger() : base(ID, cardStrings.NAME, "red/attack/anger", 0, cardStrings.DESCRIPTION, CardType.Attack, CardColor.Red, CardRarity.Basic, CardTarget.Enemy)
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

        public override void Use(IUserController user, ITarget target)
        {
            CommandInvoker.ExecuteCommand(new DamageCommand(target, new DamageInfo(user, Damage)));
            CommandInvoker.ExecuteCommand(new MakeTempCardInDiscardAction(MakeStatEquivalentCopy(this), 1));
        }
    }
}
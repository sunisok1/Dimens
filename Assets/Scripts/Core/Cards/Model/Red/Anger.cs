using System;
using Classes;
using Classes.Entities;
using Common;
using Core.GameCommand;
using Core.GameCommand.Commands;

namespace Core.Cards.Model.Red
{
    internal class Anger : SlayTheSpireCard
    {
        private const string ID = "Anger";
        private static readonly CardStrings cardStrings = LocalizationManager.GetCardStrings(ID);
        public Anger() : base(ID, cardStrings.NAME, "red/attack/anger", 0, cardStrings.DESCRIPTION, CardType.Attack, CardRarity.Basic,CardColor.Red, CardTarget.Enemy)
        {
            base.damage = 6;
        }

        public override void Upgrade()
        {
            base.Upgrade();
            UpgradeDamage(2);
        }

        public override AbstractCard MakeCopy()
        {
            return new Anger();
        }

        public override void Use(IUserController user, IHealthController target)
        {
            CommandInvoker.ExecuteCommand(new DamageCommand(target, new DamageInfo(user, damage)));
            CommandInvoker.ExecuteCommand(new MakeTempCardInDiscardAction(MakeStatEquivalentCopy, 1));
        }
    }
}
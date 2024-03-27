using System;
using Classes;
using Classes.Entities;
using Common;
using Core.GameCommand;
using Core.GameCommand.Commands;

namespace Core.Cards.Model.Red
{
    internal class Anger : RedCard
    {
        private const string ID = "Anger";

        public Anger() : base(ID, LocalizationManager.GetCardName(ID), "red/attack/A", 0, LocalizationManager.GetCardDescription(ID), CardType.Attack, CardRarity.Basic, CardTarget.Enemy)
        {
            base.baseDamage = 6;
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
            CommandInvoker.ExecuteCommand(new DamageCommand(target, new DamageInfo(user, baseDamage)));
            CommandInvoker.ExecuteCommand(new MakeTempCardInDiscardAction(MakeStatEquivalentCopy, 1));
        }
    }

   
}
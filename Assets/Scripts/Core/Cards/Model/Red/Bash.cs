using System;
using Classes;
using Classes.Entities;
using Common;
using Core.GameCommand;
using Core.GameCommand.Commands;

namespace Core.Cards.Model.Red
{
    internal class Bash : SlayTheSpireCard
    {
        private const string ID = "Strike_R";
        private static readonly CardStrings cardStrings = LocalizedStrings.GetCardStrings(ID);

        public Bash() : base(ID, cardStrings.NAME, "red/attack/bash", 2, cardStrings.DESCRIPTION, CardType.Attack, CardRarity.Basic, CardColor.Red, CardTarget.Enemy)
        {
            damage = 8;
            magicNumber = 2;
        }


        public override void Use(IUserController user, IHealthController target)
        {
            CommandInvoker.ExecuteCommand(new DamageCommand(target, new DamageInfo(user, 6)));
        }

        public override void Upgrade()
        {
            base.Upgrade();
            UpgradeDamage(2);
            UpgradeMagicNumber(1);
        }

        public override AbstractCard MakeCopy()
        {
            return new Bash();
        }
    }
}
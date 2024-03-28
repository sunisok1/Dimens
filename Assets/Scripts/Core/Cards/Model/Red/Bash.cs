using System;
using Classes;
using Classes.Entities;
using Common;
using Core.GameCommand;
using Core.GameCommand.Commands;

namespace Core.Cards.Model.Red
{
    internal class Bash : SlayTheSpireCard, IMagicCard, IDamageCard
    {
        private const string ID = "Strike_R";
        private static readonly CardStrings cardStrings = LocalizedStrings.GetCardStrings(ID);
        public int Damage { get; private set; }
        public int MagicNumber { get; private set; }

        public Bash() : base(ID, cardStrings.NAME, "red/attack/bash", 2, cardStrings.DESCRIPTION, CardType.Attack, CardRarity.Basic, CardColor.Red, CardTarget.Enemy)
        {
            Damage = 8;
            MagicNumber = 2;
        }

        public override void Use(IUserController user, IHealthController target)
        {
            CommandInvoker.ExecuteCommand(new DamageCommand(target, new DamageInfo(user, 6)));
        }

        public override void Upgrade()
        {
            UpgradeName();
            Damage += 2;
            this.MagicNumber += 1;
        }

        protected override AbstractCard MakeCopy()
        {
            return new Bash();
        }
    }
}
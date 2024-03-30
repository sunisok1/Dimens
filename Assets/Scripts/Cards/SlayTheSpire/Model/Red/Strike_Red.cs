﻿using System;
using Classes;
using Classes.Entities;
using Common;
using Core.GameCommand;
using Core.GameCommand.Commands;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class StrikeRed : SlayTheSpireCard, IDamageCard
    {
        private const string ID = "Strike_R";
        private static readonly CardStrings cardStrings = LocalizedStrings.GetCardStrings(ID);
        public int Damage { get; private set; }

        public StrikeRed() : base(ID, cardStrings.NAME, "red/attack/strike", 1, cardStrings.DESCRIPTION, CardType.Attack, CardRarity.Basic, CardColor.Red, CardTarget.Enemy)
        {
            Damage = 6;
            tags.Add(CardTags.Strike);
            tags.Add(CardTags.StarterStrike);
        }


        public override void Use(IUserController user, IHealthController target)
        {
            CommandInvoker.ExecuteCommand(new DamageCommand(target, new DamageInfo(user, 6)));
        }

        public override void Upgrade()
        {
            throw new NotImplementedException();
        }


        protected override AbstractCard MakeCopy()
        {
            return new StrikeRed();
        }
    }
}
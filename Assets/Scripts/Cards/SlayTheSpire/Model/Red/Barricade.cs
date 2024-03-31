﻿using System;
using Classes;
using Classes.Core;
using Classes.Core.Entities;
using Common;
using Game.GameCommand;
using Game.GameCommand.Commands;
using Game.Powers.Model;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class Barricade : SlayTheSpireCard
    {
        private const string ID = "Barricade";
        private static readonly CardStrings cardStrings = LocalizedStrings.GetCardStrings(ID);

        public Barricade() : base(ID, cardStrings.NAME, "red/power/barricade", 3, cardStrings.DESCRIPTION, CardType.Attack, CardColor.Red, CardRarity.Basic, CardTarget.Self)
        {
        }

        public override void Upgrade()
        {
            UpgradeName();
            costForTurn = Math.Max(0, costForTurn + 2 - cost);
            cost = 2;
        }

        protected override AbstractCard MakeCopy()
        {
            return new Barricade();
        }

        public override void Use(IUserController user, ITarget target)
        {
            if (target.HasPower(ID)) return;
            CommandInvoker.ExecuteCommand(new ApplyPowerAction(user, target, new BarricadePower(target)));
        }
    }
}
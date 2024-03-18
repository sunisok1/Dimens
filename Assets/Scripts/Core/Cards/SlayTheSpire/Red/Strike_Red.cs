﻿using Common;
using Core.Action;
using System;

namespace Core.Cards.SlayTheSpire.Red
{
    public class Strike_Red : RedCard
    {
        public Strike_Red() : base("Strike_R", LocalizationManager.GetCardName("Strike_R"), "red/attack/strike", 1, LocalizationManager.GetCardDescription("Strike_R"), CardType.Attack, CardRarity.Basic, CardTarget.Enemy)
        {
            baseDamage = 6;
            tags.Add(CardTags.Strike);
            tags.Add(CardTags.StarterStrike);
        }


        public override void Use(IUser user, ITarget target)
        {
            ActionManager.AddAction(new DamageAction(target, new DamageInfo(user, 6)));
        }

        public override void Upgrade()
        {
            throw new NotImplementedException();
        }

        public override AbstractCard MakeCopy()
        {
            return new Strike_Red();
        }
    }
}
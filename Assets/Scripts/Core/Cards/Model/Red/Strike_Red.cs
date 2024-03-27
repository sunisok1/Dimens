using System;
using Classes;
using Classes.Entities;
using Common;
using Core.GameCommand;
using Core.GameCommand.Commands;

namespace Core.Cards.Model.Red
{
    internal class StrikeRed : RedCard
    {
        public StrikeRed() : base("Strike_R", LocalizationManager.GetCardName("Strike_R"), "red/attack/strike", 1, LocalizationManager.GetCardDescription("Strike_R"), CardType.Attack, CardRarity.Basic, CardTarget.Enemy)
        {
            baseDamage = 6;
            tags.Add(CardTags.Strike);
            tags.Add(CardTags.StarterStrike);
        }


        public override void Use(IUserController user, IHealthController target)
        {
            CommandInvoker.ExecuteCommand(new DamageCommand(target, new DamageInfo(user, 6)));
            // ActionManager.AddAction(new DamageAction(target, new DamageInfo(user, 6)));
        }

        public override void Upgrade()
        {
            throw new NotImplementedException();
        }

        public override AbstractCard MakeCopy()
        {
            return new StrikeRed();
        }
    }
}
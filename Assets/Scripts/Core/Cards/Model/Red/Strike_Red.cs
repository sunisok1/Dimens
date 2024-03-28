using System;
using Classes;
using Classes.Entities;
using Common;
using Core.GameCommand;
using Core.GameCommand.Commands;

namespace Core.Cards.Model.Red
{
    internal class StrikeRed : SlayTheSpireCard
    {
        private const string ID = "Strike_R";
        private static readonly CardStrings cardStrings = LocalizationManager.GetCardStrings(ID);

        public StrikeRed() : base(ID, cardStrings.NAME, "red/attack/strike", 1, cardStrings.DESCRIPTION, CardType.Attack, CardRarity.Basic, CardColor.Red, CardTarget.Enemy)
        {
            damage = 6;
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

        public override AbstractCard MakeCopy()
        {
            return new StrikeRed();
        }
    }
}
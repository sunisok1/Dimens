using System;
using Core;
using Core.Card;
using Core.Localization;
using Game.GameCommand;
using Game.GameCommand.Commands;

namespace Cards.SlayTheSpire.Model.Red
{
    internal class StrikeRed : SlayTheSpireCard, IDamageCard
    {
        private const string ID = "Strike_R";
        private static readonly CardStrings cardStrings = CardCrawlGame.languagePack.GetCardStrings(ID);
        public int Damage { get; private set; }

        public StrikeRed() : base(ID, cardStrings.NAME, "red/attack/strike", 1, cardStrings.DESCRIPTION, CardType.Attack, CardColor.Red, CardRarity.Basic, CardTarget.Enemy)
        {
            Damage = 6;
            tags.Add(CardTags.Strike);
            tags.Add(CardTags.StarterStrike);
        }


        public override void Use(IUserController user, ITarget target)
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
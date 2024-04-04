using System.Collections.Generic;
using Core;
using Core.Card;

namespace Cards.SlayTheSpire
{
    [Card("Card/SlayTheSpireCardView")]
    internal abstract class SlayTheSpireCard : AbstractCard, IEnergyRequired, IUpgradeable, IHasTarget
    {
        public int Cost { get; protected set; }
        public readonly CardType type;
        public readonly CardRarity rarity;
        public readonly CardColor color;
        public CardTarget Target { get; protected set; }

        protected readonly List<CardTags> tags = new();
        public int TimesUpgraded { get; set; }
        protected int costForTurn;
        protected bool Upgraded { get; private set; }

        protected SlayTheSpireCard(string cardID, string name, string portrait, int cost, string rawDescription, CardType type, CardColor color, CardRarity rarity, CardTarget target) : base(cardID, name, portrait, rawDescription)
        {
            this.type = type;
            this.Cost = cost;
            this.color = color;
            this.rarity = rarity;
            this.Target = target;
        }


        public abstract void Upgrade();

        public void UpgradeName()
        {
            TimesUpgraded++;
            Upgraded = true;
            Name += "+";
            // initializeTitle();
        }
    }
}
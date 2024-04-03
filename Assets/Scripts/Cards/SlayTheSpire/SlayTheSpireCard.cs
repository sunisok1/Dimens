using System.Collections.Generic;
using Core;
using Core.Card;

namespace Cards
{
    public enum CardTarget
    {
        Enemy,
        AllEnemy,
        Self,
        None,
        SelfAndEnemy,
        All
    }

    public enum CardColor
    {
        Red,
        Green,
        Blue,
        Purple,
        Colorless,
        Curse
    }

    public enum CardRarity
    {
        Basic,
        Special,
        Common,
        Uncommon,
        Rare,
        Curse
    }

    public enum CardType
    {
        Attack,
        Skill,
        Power,
        Status,
        Curse
    }

    public enum CardTags
    {
        Healing,
        Strike,
        Empty,
        StarterDefend,
        StarterStrike
    }

    [Card("Card/SlayTheSpireCardView")]
    internal abstract class SlayTheSpireCard : AbstractCard, IUpgradeable
    {
        private const string PortraitsDirectory = "Slay the Spire/cards/";

        public readonly CardType type;
        protected int cost;
        protected CardRarity rarity;
        protected CardColor color;
        protected CardTarget target;
        protected readonly List<CardTags> tags = new();
        public int TimesUpgraded { get; set; }
        protected int costForTurn;
        protected bool Upgraded { get; private set; }

        protected SlayTheSpireCard(string cardID, string name, string portrait, int cost, string rawDescription, CardType type, CardColor color, CardRarity rarity, CardTarget target) : base(name, cardID, PortraitsDirectory + portrait, rawDescription)
        {
            this.type = type;
            this.cost = cost;
            this.color = color;
            this.rarity = rarity;
            this.target = target;
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
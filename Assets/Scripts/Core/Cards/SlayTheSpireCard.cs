using System.Collections.Generic;
using Classes;

namespace Core.Cards
{
    internal enum CardTarget
    {
        Enemy,
        AllEnemy,
        Self,
        None,
        SelfAndEnemy,
        All
    }

    internal enum CardColor
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


    internal abstract class SlayTheSpireCard : AbstractCard
    {
        private const string PortraitsDirectory = "Slay the Spire/cards/";

        public CardType type;
        public int cost;
        public CardRarity rarity;
        public CardColor color;
        public CardTarget target;
        public int baseDamage = -1, baseBlock = -1, baseMagicNumber = -1, baseHeal = -1, baseDraw = -1, baseDiscard = -1;
        public readonly List<CardTags> tags = new();
        private int timesUpgraded;
        private bool upgraded;
        public bool UpgradedDamage { get; private set; }

        protected SlayTheSpireCard(string cardID, string name, string portrait, int cost, string rawDescription, CardType type, CardRarity rarity, CardColor color, CardTarget target) : base(name, cardID, PortraitsDirectory + portrait, rawDescription)
        {
            this.type = type;
            this.cost = cost;
            this.rarity = rarity;
            this.color = color;
            this.target = target;
        }

        public abstract AbstractCard MakeCopy();

        public virtual void Upgrade()
        {
            timesUpgraded++;
            upgraded = true;
            Name += "+";
            // initializeTitle();
        }

        protected void UpgradeDamage(int amount)
        {
            baseDamage += amount;
            UpgradedDamage = true;
        }

        public AbstractCard MakeStatEquivalentCopy()
        {
            if (MakeCopy() is not SlayTheSpireCard card) return default;
            for (int i = 0; i < this.timesUpgraded; i++)
                card.Upgrade();
            card.Name = this.Name;
            card.target = this.target;
            card.upgraded = this.upgraded;
            card.timesUpgraded = this.timesUpgraded;
            card.baseDamage = this.baseDamage;
            card.baseBlock = this.baseBlock;
            card.baseMagicNumber = this.baseMagicNumber;
            card.cost = this.cost;
            // card.costForTurn = this.costForTurn;
            // card.isCostModified = this.isCostModified;
            // card.isCostModifiedForTurn = this.isCostModifiedForTurn;
            // card.inBottleLightning = this.inBottleLightning;
            // card.inBottleFlame = this.inBottleFlame;
            // card.inBottleTornado = this.inBottleTornado;
            // card.isSeen = this.isSeen;
            // card.isLocked = this.isLocked;
            // card.misc = this.misc;
            // card.freeToPlayOnce = this.freeToPlayOnce;
            return card;
        }
    }
}
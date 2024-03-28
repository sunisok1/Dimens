using System;
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

        public readonly CardType type;
        protected int cost;
        protected CardRarity rarity;
        protected CardColor color;
        protected CardTarget target;
        protected int damage = -1;
        protected int block = -1;
        protected int magicNumber = -1;
        protected int heal = -1;
        protected int draw = -1;
        protected int discard = -1;
        protected readonly List<CardTags> tags = new();
        protected int timesUpgraded;
        private int costForTurn;
        protected bool Upgraded { get; private set; }
        protected bool UpgradedDamage { get; private set; }
        protected bool UpgradedCost { get; private set; }
        protected bool UpgradedMagicNumber { get; private set; }

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
            Upgraded = true;
            Name += "+";
            // initializeTitle();
        }

        protected void UpgradeDamage(int amount)
        {
            damage += amount;
            UpgradedDamage = true;
        }

        protected void UpgradeCost(int newCost)
        {
            costForTurn = Math.Max(0, costForTurn + newCost - cost);
            cost = newCost;
            UpgradedCost = true;
        }

        public AbstractCard MakeStatEquivalentCopy()
        {
            if (MakeCopy() is not SlayTheSpireCard card) return default;
            for (int i = 0; i < this.timesUpgraded; i++)
                card.Upgrade();
            card.Name = this.Name;
            card.target = this.target;
            card.Upgraded = this.Upgraded;
            card.timesUpgraded = this.timesUpgraded;
            card.damage = this.damage;
            card.block = this.block;
            card.magicNumber = this.magicNumber;
            card.cost = this.cost;
            card.costForTurn = this.costForTurn;
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

        protected void UpgradeMagicNumber(int amount)
        {
            this.magicNumber += amount;
            this.UpgradedMagicNumber = true;
        }
    }
}
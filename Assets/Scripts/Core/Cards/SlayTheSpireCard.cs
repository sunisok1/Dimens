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

        protected SlayTheSpireCard(string cardID, string name, string portrait, int cost, string rawDescription, CardType type, CardRarity rarity, CardColor color, CardTarget target) : base(name, cardID, PortraitsDirectory + portrait, rawDescription)
        {
            this.type = type;
            this.cost = cost;
            this.rarity = rarity;
            this.color = color;
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
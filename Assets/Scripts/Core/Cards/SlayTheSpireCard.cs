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

        protected SlayTheSpireCard(string cardID, string name, string portrait, int cost, string rawDescription, CardType type, CardRarity rarity, CardColor color, CardTarget target) : base(name, cardID, PortraitsDirectory + portrait, rawDescription)
        {
            this.type = type;
            this.cost = cost;
            this.rarity = rarity;
            this.color = color;
            this.target = target;
        }

        public abstract void Upgrade();
        public abstract AbstractCard MakeCopy();
    }
}
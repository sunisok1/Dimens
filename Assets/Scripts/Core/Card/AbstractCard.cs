using System;

namespace Core.Card
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CardAttribute : Attribute
    {
        internal string Path { get; }

        public CardAttribute(string path)
        {
            Path = path;
        }
    }

    public abstract class AbstractCard
    {
        public readonly string originalName;
        public string Name { get; protected set; }
        public readonly string cardID;
        public readonly string portrait;
        public string rawDescription;

        protected AbstractCard(string cardID, string name, string portrait, string rawDescription)
        {
            originalName = name;
            this.cardID = cardID;
            Name = name;

            this.portrait = portrait;
            this.rawDescription = rawDescription;
        }

        public abstract void Use(IUserController user, ITarget target);
        protected abstract AbstractCard MakeCopy();

        protected static AbstractCard MakeStatEquivalentCopy(AbstractCard card)
        {
            AbstractCard copy = card.MakeCopy();
            if (card is IUpgradeable upgradeable && copy is IUpgradeable copyUpgradeable)
            {
                for (var i = 0; i < upgradeable.TimesUpgraded; i++)
                    copyUpgradeable.Upgrade();
            }

            return card;
        }
    }
}
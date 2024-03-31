using Classes.Core.Entities;

namespace Classes.Core
{
    public abstract class AbstractCard
    {
        public readonly string originalName;
        public string Name { get; protected set; }
        public readonly string cardID;
        public readonly string portrait;
        public string rawDescription;

        protected AbstractCard(string cardID, string name, string portrait, string rawDescription)
        {
            this.originalName = name;
            this.cardID = cardID;
            this.Name = name;

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
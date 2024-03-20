namespace Core.Cards
{
    public abstract class AbstractCard
    {
        public readonly string originalName;
        public string name { get; private set; }
        public readonly string cardID;
        public readonly string portrait;
        public readonly string rawDescription;

        protected AbstractCard(string cardID, string name, string portrait, string rawDescription)
        {
            this.originalName = name;
            this.cardID = cardID;
            this.name = name;

            this.portrait = portrait;
            this.rawDescription = rawDescription;
        }

        public abstract void Use(IUser user, ITarget target);
    }
}
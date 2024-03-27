using Classes.Entities;

namespace Classes
{
    public abstract class AbstractCard
    {
        public readonly string originalName;
        public string Name { get; protected set; }
        public readonly string cardID;
        public readonly string portrait;
        public readonly string rawDescription;

        protected AbstractCard(string cardID, string name, string portrait, string rawDescription)
        {
            this.originalName = name;
            this.cardID = cardID;
            this.Name = name;

            this.portrait = portrait;
            this.rawDescription = rawDescription;
        }

        public abstract void Use(IUserController user, IHealthController target);
    }
}
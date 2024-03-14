using System;

namespace Core
{
    public delegate void CardEffect(CardEffectArgs args);

    public class CardEffectArgs
    {
        public Entity target { get; }

        public CardEffectArgs(Entity target)
        {
            this.target = target;
        }
    }

    public class CardImageAttribute : Attribute
    {
        public CardImageAttribute(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }

    public abstract class Card
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Cost { get; protected set; }

        public virtual string Image { get; }

        protected Card(string name, string description, int cost)
        {
            Name = name;
            Description = description;
            Cost = cost;
        }

        public abstract void ExecuteEffect(CardEffectArgs args);
    }
}
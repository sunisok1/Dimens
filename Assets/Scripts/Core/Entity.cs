using System;

namespace Core
{
    public abstract class Entity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

        protected Entity(string name)
        {
            Name = name;
        }
    }
}
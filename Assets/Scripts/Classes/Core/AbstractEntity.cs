using System;

namespace Core
{
    public abstract class AbstractEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

        protected AbstractEntity(string name)
        {
            Name = name;
        }
    }
}
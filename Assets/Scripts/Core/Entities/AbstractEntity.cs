using UnityEngine;

namespace Core.Entities
{
    public abstract class AbstractEntity
    {
        private string name;
        private Vector3Int position;

        public virtual string Name
        {
            get => name;
            set => name = value;
        }

        public virtual Vector3Int Position
        {
            get => position;
            set => position = value;
        }

        protected AbstractEntity(string name, Vector3Int position)
        {
            this.name = name;
            this.position = position;
        }
    }
}
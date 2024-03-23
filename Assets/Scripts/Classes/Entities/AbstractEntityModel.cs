namespace Classes.Entities
{
    using UnityEngine;

    public abstract class AbstractEntityModel
    {
        public Vector3Int Position { get; internal set; }
        public string Name { get; internal set; }

        protected AbstractEntityModel(string name, Vector3Int position)
        {
            Name = name;
            Position = position;
        }
    }
}
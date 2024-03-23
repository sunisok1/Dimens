using System;
using UnityEngine;

namespace Classes.Entities
{
    public class EntityCreatedArgs : EventArgs
    {
        public readonly AbstractEntity entity;
        public readonly Vector3Int initialPosition;

        public EntityCreatedArgs(AbstractEntity entity, Vector3Int initialPosition)
        {
            this.entity = entity;
            this.initialPosition = initialPosition;
        }
    }
}
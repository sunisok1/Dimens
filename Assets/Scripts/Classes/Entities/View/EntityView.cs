using Common;
using UnityEngine;

namespace Classes.Entities.View
{
    public abstract class EntityView : BaseObject
    {
        public abstract void UpdatePosition(Vector3Int position);

        public abstract void UpdateName(string name);
    }
}
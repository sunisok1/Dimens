using UnityEngine;

namespace Classes.Core.Entities.Factory
{
    public interface IEntityFactory<out T> where T : EntityController
    {
        T CreateEntity(string name ,Vector3Int position);
    }
}
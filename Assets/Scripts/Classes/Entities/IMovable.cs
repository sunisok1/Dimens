using UnityEngine;

namespace Classes.Entities
{
    public interface IMovable
    {
        void MoveTo( Vector3Int target);
    }
}
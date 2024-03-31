using UnityEngine;

namespace Core
{
    public interface IMovable
    {
        void MoveTo( Vector3Int target);
    }
}
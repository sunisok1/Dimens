using UnityEngine;

namespace Classes.Core
{
    public interface IMovable
    {
        void MoveTo( Vector3Int target);
    }
}
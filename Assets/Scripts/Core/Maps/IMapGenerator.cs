using UnityEngine;

namespace Core.Maps
{
    public abstract class AbstractMapGenerator : MonoBehaviour
    {
        public abstract AbstractMap GenerateMap();
    }
}
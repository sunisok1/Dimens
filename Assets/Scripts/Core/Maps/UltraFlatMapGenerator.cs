using UnityEngine;

namespace Core.Maps
{
    public class UltraFlatMapGenerator : MonoBehaviour, IMapGenerator
    {
        public Map GenerateMap()
        {
            return new Map(10, 10);
        }
    }
}
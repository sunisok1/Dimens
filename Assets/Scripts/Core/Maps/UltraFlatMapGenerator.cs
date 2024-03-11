using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.Maps
{
    public class UltraFlatMapGenerator : MonoBehaviour, IMapGenerator
    {
        [SerializeField] private int Width = 10;
        [SerializeField] private int Height = 10;
        [SerializeField] private Transform mapObjectPrefab;
        [SerializeField] private Tile tile;


        public Map GenerateMap()
        {
            Transform mapInstance = Instantiate(mapObjectPrefab);

            return new UltraFlatMap(mapInstance, tile, Width, Height);
        }
    }
}
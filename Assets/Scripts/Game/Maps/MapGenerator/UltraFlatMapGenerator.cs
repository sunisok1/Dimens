using Core.Maps;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Maps.MapGenerator
{
    public class UltraFlatMapGenerator : AbstractMapGenerator
    {
        [SerializeField] private int width = 10;
        [SerializeField] private int height = 10;
        [SerializeField] private Transform mapObjectPrefab;
        [SerializeField] private Tile tile;


        public override AbstractMap GenerateMap()
        {
            Transform mapInstance = Instantiate(mapObjectPrefab, transform);
            var ultraFlatMap = new UltraFlatMap(mapInstance, tile, width, height);
            return ultraFlatMap;
        }
    }
}
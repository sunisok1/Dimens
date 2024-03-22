using Common;
using Core.Map;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.Maps.MapGenerator
{
    public class UltraFlatMapGenerator : MonoBehaviour, IMapGenerator
    {
        [SerializeField] private int Width = 10;
        [SerializeField] private int Height = 10;
        [SerializeField] private Transform mapObjectPrefab;
        [SerializeField] private Tile tile;


        public AbstractMap GenerateMap()
        {
            Transform mapInstance = Instantiate(mapObjectPrefab);
            var ultraFlatMap = new UltraFlatMap(mapInstance, tile, Width, Height);

            EventSystem.Subscribe<EntityCreatedArgs>(ultraFlatMap.OnEntityCreated);
            EventSystem.Subscribe<EntityMoveArgs>(ultraFlatMap.OnEntityMove);

            return ultraFlatMap;
        }
    }
}
using Core.Maps;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.Maps
{
    internal class UltraFlatMap : AbstractMap
    {
        private readonly Tilemap tilemap;
        private readonly Transform entityContent;

        public UltraFlatMap(Transform mapInstance, TileBase tile, int width, int height) : base(width, height)
        {
            tilemap = mapInstance.Find("Grid/Tilemap").GetComponent<Tilemap>();
            entityContent = mapInstance.Find("Entities").transform;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    tilemap.SetTile(new Vector3Int(i, j), tile);
                }
            }

            PopulateUnoccupiedPositions();
        }

        private void PopulateUnoccupiedPositions()
        {
            unoccupiedGrids.Clear();
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    unoccupiedGrids.Add(new Vector3Int(x, y, 0));
                }
            }
        }

        public override Vector3 GetWorldPosition(Vector3Int position)
        {
            return tilemap.GetCellCenterWorld(position);
        }

        public override Transform GetContent()
        {
            return entityContent;
        }
    }
}
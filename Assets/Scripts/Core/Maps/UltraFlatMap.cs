using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Core.Maps
{
    public class UltraFlatMap : Map
    {
        private readonly Tilemap tilemap;
        public override Transform PlayerContent { get; }

        private readonly HashSet<Vector3Int> unoccupied = new();

        public UltraFlatMap(Transform mapInstance, TileBase tile, int width, int height) : base(width, height)
        {
            tilemap = mapInstance.Find("Grid/Tilemap").GetComponent<Tilemap>();
            PlayerContent = mapInstance.Find("Entities").transform;
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
            unoccupied.Clear();
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    // Assuming a single-layer approach for simplicity
                    unoccupied.Add(new Vector3Int(x, y, 0));
                }
            }
        }

        public override Vector3 GetWorldPosition(Vector3Int position) => tilemap.CellToWorld(position);

        public override bool GetUnoccupiedPosition(out Vector3Int position)
        {
            if (unoccupied.Count == 0)
            {
                position = Vector3Int.zero;
                return false;
            }

            var randomIndex = Random.Range(0, unoccupied.Count);
            position = unoccupied.ElementAt(randomIndex);
            return true;
        }

        public override void MarkPositionOccupied(Vector3Int position)
        {
            unoccupied.Remove(position);
        }

        public override void MarkPositionUnoccupied(Vector3Int position)
        {
            unoccupied.Add(position);
        }
    }
}
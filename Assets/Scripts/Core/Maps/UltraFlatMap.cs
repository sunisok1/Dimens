using System;
using System.Collections.Generic;
using Classes;
using Classes.Entities;
using Common;
using Core.Entities;
using Core.Entities.GameObjects.Players;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.Maps
{
    public class UltraFlatMap : AbstractMap
    {
        private readonly Dictionary<AbstractEntity, EntityObject> entityObjects = new();
        private readonly Tilemap tilemap;
        private Transform EntityContent { get; }

        public UltraFlatMap(Transform mapInstance, TileBase tile, int width, int height) : base(width, height)
        {
            tilemap = mapInstance.Find("Grid/Tilemap").GetComponent<Tilemap>();
            EntityContent = mapInstance.Find("Entities").transform;
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

        public override void OnEntityCreated(object sender, EntityCreatedArgs e)
        {
            EntityObject entityObject;
            switch (e.entity)
            {
                case Player player:
                    entityObject = ObjectManager.Create<PlayerObject>(EntityContent, player);
                    break;
                default:
                    throw new NotImplementedException();
            }

            entityObject.transform.position = tilemap.CellToWorld(e.initialPosition);
        }

        public override void OnEntityMove(object sender, EntityMoveArgs e)
        {
            unoccupiedGrids.Add(e.origin);
            unoccupiedGrids.Remove(e.target);

            entityObjects[e.entity].transform.position = tilemap.CellToWorld(e.target);
        }
    }
}
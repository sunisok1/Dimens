using System.Collections.Generic;
using System.Linq;
using Classes.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Classes
{
    public abstract class AbstractMap
    {
        protected readonly HashSet<Vector3Int> unoccupiedGrids = new();
        protected int Width { get; }
        protected int Height { get; }

        protected AbstractMap(int width, int height)
        {
            Width = width;
            Height = height;
        }

 
        public bool GetUnoccupiedPosition(out Vector3Int position)
        {
            if (unoccupiedGrids.Count == 0)
            {
                position = Vector3Int.zero;
                return false;
            }

            var randomIndex = Random.Range(0, unoccupiedGrids.Count);
            position = unoccupiedGrids.ElementAt(randomIndex);
            return true;
        }

        public abstract void OnEntityCreated(object sender, EntityCreatedArgs e);
        public abstract void OnEntityMove(object sender, EntityMoveArgs e);
    }
}
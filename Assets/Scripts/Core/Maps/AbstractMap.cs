using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Maps
{
    public abstract class AbstractMap : IDisposable
    {
        protected readonly HashSet<Vector3Int> unoccupiedGrids = new();
        protected int Width { get; }
        protected int Height { get; }

        protected AbstractMap(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void SubscribeEvents()
        {
            EventSystem.Subscribe<EntityCreatedArgs>(OnEntityCreated);
            EventSystem.Subscribe<EntityMoveArgs>(OnEntityMove);
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

        protected abstract void OnEntityCreated(object sender, EntityCreatedArgs e);
        protected abstract void OnEntityMove(object sender, EntityMoveArgs e);

        public virtual void Dispose()
        {
            EventSystem.Unsubscribe<EntityCreatedArgs>(OnEntityCreated);
            EventSystem.Unsubscribe<EntityMoveArgs>(OnEntityMove);
        }
    }
}
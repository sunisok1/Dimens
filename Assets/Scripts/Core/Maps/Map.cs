using UnityEngine;

namespace Core.Maps
{
    public interface IMapGenerator
    {
        Map GenerateMap();
    }

    public abstract class Map
    {
        public int Width { get; }
        public int Height { get; }

        protected Map(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public abstract Vector3 GetWorldPosition(Vector3Int position);
        public abstract Transform PlayerContent { get; }
        public abstract bool GetUnoccupiedPosition(out Vector3Int position);
        public abstract void MarkPositionOccupied(Vector3Int position);
        public abstract void MarkPositionUnoccupied(Vector3Int position);
    }
}
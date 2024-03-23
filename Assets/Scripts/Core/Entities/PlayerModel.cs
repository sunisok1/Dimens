using Classes.Entities;
using UnityEngine;

namespace Core.Entities
{
    public class PlayerModel : AbstractEntityModel, IHealth
    {
        public PlayerModel(string name, Vector3Int position) : base(name, position)
        {
        }

        public int CurHealth { get; set; }

        public int MaxHealth { get; set; }
    }
}
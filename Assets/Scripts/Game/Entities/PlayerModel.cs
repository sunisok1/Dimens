using Classes.Core.Entities;
using UnityEngine;

namespace Game.Entities
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
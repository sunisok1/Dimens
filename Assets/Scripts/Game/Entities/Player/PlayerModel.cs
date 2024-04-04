using System.Collections.Generic;
using Core;
using Core.Entities;
using UnityEngine;

namespace Game.Entities.Player
{
    internal class PlayerModel : AbstractEntityModel, IHealth
    {
        internal PlayerModel(string name, Vector3Int position) : base(name, position)
        {
        }

        public List<AbstractPower> Powers { get; } = new();

        public int Energy { get; set; }

        public int CurHealth { get; set; }

        public int MaxHealth { get; set; }
    }
}
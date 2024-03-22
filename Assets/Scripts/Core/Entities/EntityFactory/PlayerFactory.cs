using Common;
using UnityEngine;

namespace Core.Entities.EntityFactory
{
    public class PlayerFactory
    {
        private readonly AbstractMap map;

        public PlayerFactory(AbstractMap map)
        {
            this.map = map;
        }

        public Player CreatePlayer(string name, int health, int maxHealth)
        {
            if (!map.GetUnoccupiedPosition(out Vector3Int position)) return null;
            var player = new Player(name, health, maxHealth, position);
            EventSystem.InvokeEvent(this, new EntityCreatedArgs(player, position));
            return player;
        }
    }
}
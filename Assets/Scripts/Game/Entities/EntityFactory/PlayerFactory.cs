using Classes.Core.Entities.Factory;
using Classes.Core.Maps;
using Common;
using Game.Entities.Controller;
using Game.Entities.View;
using UnityEngine;

namespace Game.Entities.EntityFactory
{
    public class PlayerFactory : IEntityFactory<Player>
    {
        private readonly AbstractMap map;

        public PlayerFactory(AbstractMap map)
        {
            this.map = map;
        }

        public Player CreateEntity(string name, Vector3Int position)
        {
            var playerModel = new PlayerModel(name, position);
            var playerView = ObjectManager.Create<PlayerView>(map.GetContent(), playerModel);
            return new Player(playerModel, playerView);
        }
    }
}
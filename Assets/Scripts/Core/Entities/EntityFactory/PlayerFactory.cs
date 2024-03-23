using Classes.Entities.Factory;
using Classes.Maps;
using Common;
using Core.Entities.Controller;
using Core.Entities.View;
using UnityEngine;

namespace Core.Entities.EntityFactory
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
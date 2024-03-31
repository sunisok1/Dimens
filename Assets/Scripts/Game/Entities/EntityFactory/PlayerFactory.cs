using Common;
using Core.Entities.Factory;
using Core.Maps;
using Game.Entities.Controller;
using Game.Entities.View;
using UnityEngine;

namespace Game.Entities.EntityFactory
{
    public class PlayerFactory : IEntityFactory<PlayerController>
    {
        private readonly AbstractMap map;

        public PlayerFactory(AbstractMap map)
        {
            this.map = map;
        }

        public PlayerController CreateEntity(string name, Vector3Int position)
        {
            var playerModel = new PlayerModel(name, position);
            var playerView = ObjectManager.Create<PlayerView>(map.GetContent(), playerModel);
            return new PlayerController(playerModel, playerView);
        }
    }
}
using Common;
using Core.Card.Deck;
using Core.Maps;
using Game.Entities.Player;
using UnityEngine;

namespace Game.Entities.EntityFactory
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private AbstractDeckFactory deckFactory;

        private AbstractMap map;

        public void SetMap(AbstractMap map) => this.map = map;


        public PlayerController CreateEntity(string name, Vector3Int position)
        {
            var playerModel = new PlayerModel(name, position, deckFactory.CreateInstance());
            
            var playerView = ObjectManager.Create<PlayerView>(map.GetContent(), playerModel);
            var playerController = new PlayerController(playerModel, playerView);
            return playerController;
        }
    }
}
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

        public Player.Player CreateEntity(string name, Vector3Int position)
        {
            var playerController = new Player.Player(name, position, deckFactory.CreateInstance(), 3);
            ObjectManager.Create<PlayerView>(map.GetContent(), playerController);
            return playerController;
        }
    }
}
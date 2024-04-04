using Core.Maps;
using Game.Entities.EntityFactory;
using Game.Entities.Player;
using Systems.TurnSystem;
using UnityEngine;

namespace Game.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private AbstractMapGenerator abstractMapGenerator;
        [SerializeField] private TurnSystemController turnSystemController;
        [SerializeField] private PlayerFactory playerFactory;

        private void Start()
        {
            AbstractMap map = abstractMapGenerator.GenerateMap();
            playerFactory.SetMap(map);

            var players = new PlayerController[4];
            for (var i = 0; i < players.Length; i++)
            {
                if (!map.GetUnoccupiedPosition(out Vector3Int pos)) return;

                players[i] = playerFactory.CreateEntity($"player_{i}", pos);
                players[i].SetInfo(100, 100);
            }

            turnSystemController.Init(players);
        }
    }
}
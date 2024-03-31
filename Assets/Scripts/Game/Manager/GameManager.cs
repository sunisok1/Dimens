using Core.Maps;
using Game.Entities.Controller;
using Game.Entities.EntityFactory;
using Systems.TurnSystem;
using UnityEngine;

namespace Game.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private AbstractMapGenerator abstractMapGenerator;
        [SerializeField] private TurnSystemController turnSystemController;

        private void Start()
        {
            AbstractMap map = abstractMapGenerator.GenerateMap();
            PlayerFactory playerFactory = new(map);

            var players = new PlayerController[9];
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
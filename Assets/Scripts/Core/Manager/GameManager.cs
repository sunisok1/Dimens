using Classes.Maps;
using Core.Entities.Controller;
using Core.Entities.EntityFactory;
using UnityEngine;

namespace Core.Manager
{
    [RequireComponent(typeof(IMapGenerator))]
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            var mapGenerator = GetComponent<IMapGenerator>();
            var map = mapGenerator.GenerateMap();
            PlayerFactory playerFactory = new(map);

            var players = new Player[9];
            for (var i = 0; i < players.Length; i++)
            {
                if (!map.GetUnoccupiedPosition(out var pos)) return;

                players[i] = playerFactory.CreateEntity($"player_{i}", pos);
                players[i].SetInfo(100,100);
            }

            var turnSystem = new TurnSystem(players);
            StartCoroutine(turnSystem.RunTurnCycle());
        }
    }
}
using Classes.Maps;
using Core.Entities;
using Core.Entities.EntityFactory;
using Core.Maps;
using UnityEngine;

namespace Core.Manager
{
    [RequireComponent(typeof(IMapGenerator))]
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            var mapGenerator = GetComponent<IMapGenerator>();
            var gameMap = mapGenerator.GenerateMap();
            PlayerFactory playerFactory = new(gameMap);

            var players = new Player[9];
            for (var i = 0; i < players.Length; i++)
            {
                players[i] = playerFactory.CreatePlayer($"player_{i}", 100, 100);
            }

            var turnSystem = new TurnSystem(players);
            StartCoroutine(turnSystem.RunTurnCycle());
        }
    }
}
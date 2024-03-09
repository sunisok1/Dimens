using Core.Entities;
using Core.System;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private Map gameMap;
        private TurnSystem turnSystem;

        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            InitializeMap();
            InitializeTurnSystem();
        }

        private void InitializeMap()
        {
            var mapGenerator = GetComponent<IMapGenerator>();
            gameMap = mapGenerator.GenerateMap();
            Debug.Log("Map Initialized");
        }

        private void InitializeTurnSystem()
        {
            Player[] players = new Player[9];
            for (var i = 0; i < players.Length; i++)
            {
                players[i] = new Player($"player_{i}", 100, 100);
            }

            turnSystem = GetComponent<TurnSystem>();
            turnSystem.Initialize(players);
            Debug.Log("Round System Initialized");
        }
    }
}
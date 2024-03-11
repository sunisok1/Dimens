using System;
using Core.Entities;
using Core.System;
using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(IMapGenerator))]
    [RequireComponent(typeof(TurnSystem))]
    public class GameManager : MonoBehaviour
    {
        private Map gameMap;
        private TurnSystem turnSystem;

        private void Start()
        {
            InitializeGame();
        }

        private void OnDestroy()
        {
            DisposeGame();
        }

        private void InitializeGame()
        {
            PlayerManager.Initialize();
            InitializeMap();
            InitializeTurnSystem();
        }

        private void DisposeGame()
        {
            PlayerManager.Dispose();
        }

        private void InitializeMap()
        {
            var mapGenerator = GetComponent<IMapGenerator>();
            gameMap = mapGenerator.GenerateMap();

            EventSystem.InvokeEvent(this, new InitializeMapArgs
            {
                map = gameMap
            });

            Debug.Log("Map Initialized");
        }

        private void InitializeTurnSystem()
        {
            var players = new Player[9];
            for (var i = 0; i < players.Length; i++)
            {
                players[i] = PlayerManager.CreatePlayer($"player_{i}", 100, 100);
            }

            turnSystem = GetComponent<TurnSystem>();
            turnSystem.Initialize(players);

            EventSystem.InvokeEvent(this, new InitializeTurnSystemArgs
            {
                turnSystem = turnSystem
            });

            Debug.Log("Round System Initialized");
        }
    }

    public class InitializeMapArgs : EventArgs
    {
        public Map map;
    }

    public class InitializeTurnSystemArgs : EventArgs
    {
        public TurnSystem turnSystem;
    }
}
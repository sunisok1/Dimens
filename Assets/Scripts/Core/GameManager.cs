using System;
using Common;
using Core.Entities.Player;
using Core.Maps;
using Core.System.Turn;
using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(IMapGenerator))]
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
            turnSystem = new();

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
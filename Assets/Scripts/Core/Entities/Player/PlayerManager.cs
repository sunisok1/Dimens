﻿using System.Collections.Generic;
using Common;
using Core.Maps;
using UnityEngine;

namespace Core.Entities.Player
{
    public static class PlayerManager
    {
        private static Map map;
        private static readonly Dictionary<Player, PlayerObject> PlayerObjects = new();

        public static void Initialize()
        {
            EventSystem.Subscribe<InitializeMapArgs>(OnInitializeMap);
            EventSystem.Subscribe<PlayerMoveEventArgs>(OnPlayerMove);
        }


        #region PublicMethod

        public static Player CreatePlayer(string name, int health, int maxHealth)
        {
            if (!map.GetUnoccupiedPosition(out Vector3Int initialPosition))
            {
                return null;
            }

            map.MarkPositionOccupied(initialPosition);

            var player = new Player(name, health, maxHealth, initialPosition);
            var playerObject = ObjectManager.Create<PlayerObject>(map.PlayerContent, player);
            playerObject.transform.position = map.GetWorldPosition(initialPosition);


            PlayerObjects.Add(player, playerObject);
            return player;
        }

        #endregion

        #region Events

        private static void OnInitializeMap(object sender, InitializeMapArgs e)
        {
            map = e.map;
        }

        private static void OnPlayerMove(object sender, PlayerMoveEventArgs e)
        {
            if (sender is not Player player) return;

            map.MarkPositionUnoccupied(e.origin);
            map.MarkPositionOccupied(e.target);

            // Update player position
            PlayerObjects[player].transform.position = map.GetWorldPosition(e.target);
        }

        #endregion


        public static void Dispose()
        {
            EventSystem.Unsubscribe<InitializeMapArgs>(OnInitializeMap);
            EventSystem.Unsubscribe<PlayerMoveEventArgs>(OnPlayerMove);
            PlayerObjects.Clear();
        }
    }
}
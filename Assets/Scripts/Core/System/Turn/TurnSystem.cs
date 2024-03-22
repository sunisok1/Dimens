using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using Core.Entities;
using UnityEngine;

namespace Core.System.Turn
{
    public class TurnSystem
    {
        private readonly LinkedList<Player> playersLinkedList = new();
        private LinkedListNode<Player> currentPlayerNode;

        public TurnSystem(IEnumerable<Player> players)
        {
            foreach (Player player in players)
            {
                playersLinkedList.AddLast(player);
            }
        }

        public IEnumerator RunTurnCycle()
        {
            SwitchToSpecificPlayer(playersLinkedList.First.Value);

            while (playersLinkedList.Count >= 2)
            {
                yield return new WaitForSeconds(1);
                Player player = currentPlayerNode.Value;

                player.DrawCards(3);
                yield return player.Play();
                player.EndTurn();

                SwitchToNextPlayer();
            }
        }

        private void SwitchToNextPlayer()
        {
            // 触发事件之前的玩家
            Player previousPlayer = currentPlayerNode.Value;

            currentPlayerNode = currentPlayerNode.Next ?? playersLinkedList.First;

            // 触发事件之后的玩家
            Player currentPlayer = currentPlayerNode.Value;

            // 触发玩家切换事件
            EventSystem.InvokeEvent(this, new PlayerChangedEventArgs(previousPlayer, currentPlayer));
        }

        public void SwitchToSpecificPlayer(Player targetPlayer)
        {
            LinkedListNode<Player> targetNode = playersLinkedList.Find(targetPlayer);
            if (targetNode == null) return;
            Player previousPlayer = currentPlayerNode?.Value;
            currentPlayerNode = targetNode;
            Player currentPlayer = currentPlayerNode.Value;
            EventSystem.InvokeEvent(this, new PlayerChangedEventArgs(previousPlayer, currentPlayer));
        }
    }

    public class PlayerChangedEventArgs : EventArgs
    {
        public Player PreviousPlayer { get; }
        public Player CurrentPlayer { get; }

        public PlayerChangedEventArgs(Player previousPlayer, Player currentPlayer)
        {
            PreviousPlayer = previousPlayer;
            CurrentPlayer = currentPlayer;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Core.Entities;
using UnityEngine;

namespace Core.System
{
    public class TurnSystem : MonoBehaviour
    {
        private readonly LinkedList<Player> playersLinkedList = new();
        private LinkedListNode<Player> currentPlayerNode;

        public void Initialize(IEnumerable<Player> players)
        {
            if (players == null) return;

            foreach (Player player in players)
            {
                playersLinkedList.AddLast(player);
            }

            if (playersLinkedList.Count == 0) return;

            StartCoroutine(RunTurnCycle());
        }

        private IEnumerator RunTurnCycle()
        {
            currentPlayerNode = playersLinkedList.First;

            while (playersLinkedList.Count >= 2)
            {
                yield return new WaitForSeconds(1);
                yield return StartTurn(currentPlayerNode.Value);

                currentPlayerNode = currentPlayerNode.Next ?? playersLinkedList.First;
            }
        }

        private IEnumerator StartTurn(Player player)
        {
            player.Draw(3);
            yield return player.Play();
            player.EndTurn();
        }
    }
}
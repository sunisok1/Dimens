using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Entities
{
    public class PlayerMoveEventArgs : EventArgs
    {
        public Vector3Int origin { get; }
        public Vector3Int target { get; }

        public PlayerMoveEventArgs(Vector3Int origin, Vector3Int target)
        {
            this.origin = origin;
            this.target = target;
        }
    }


    public class CardsDrawnEventArgs : EventArgs
    {
        public List<Card> Cards { get; private set; }

        public CardsDrawnEventArgs(List<Card> cards)
        {
            Cards = cards ?? throw new ArgumentNullException(nameof(cards));
        }
    }

    public class CardsDiscardedEventArgs : EventArgs
    {
        public List<Card> Cards { get; private set; }

        public CardsDiscardedEventArgs(List<Card> cards)
        {
            Cards = cards ?? throw new ArgumentNullException(nameof(cards));
        }
    }

    public class CardsPlayedEventArgs : EventArgs
    {
        public List<Card> Cards { get; private set; }
        public Player TargetPlayer { get; private set; }

        public CardsPlayedEventArgs(List<Card> cards, Player targetPlayer)
        {
            Cards = cards ?? throw new ArgumentNullException(nameof(cards));
            TargetPlayer = targetPlayer;
        }
    }
}
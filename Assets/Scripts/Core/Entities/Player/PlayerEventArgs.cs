using System;
using System.Collections.Generic;
using Core.Action;
using Core.Cards;
using UnityEngine;

namespace Core.Entities.Player
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
        public List<AbstractCard> Cards { get; private set; }

        public CardsDrawnEventArgs(List<AbstractCard> cards)
        {
            Cards = cards ?? throw new ArgumentNullException(nameof(cards));
        }
    }

    public class CardsDiscardedEventArgs : EventArgs
    {
        public List<AbstractCard> Cards { get; private set; }

        public CardsDiscardedEventArgs(List<AbstractCard> cards)
        {
            Cards = cards ?? throw new ArgumentNullException(nameof(cards));
        }
    }

    public class CardsPlayedEventArgs : EventArgs
    {
        public AbstractCard Card { get; private set; }
        public ITarget Target { get; private set; }

        public CardsPlayedEventArgs(AbstractCard card, ITarget target)
        {
            Card = card ?? throw new ArgumentNullException(nameof(card));
            Target = target;
        }
    }
}
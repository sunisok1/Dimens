using System.Collections.Generic;
using Common;
using Core.Card;
using Core.Card.Deck;
using Core.Entities;
using UnityEngine;

namespace Game.Entities.Player
{
    public partial class Player : AbstractEntity
    {

        internal AbstractDeck Deck { get; }

        internal readonly HashSet<CardController> cards = new();

        internal Player(string name, Vector3Int position, AbstractDeck deck, int energyMaster) : base(name, position)
        {
            Deck = deck;
            this.energyMaster = energyMaster;
            coroutineHelper = new GameObject().AddComponent<CoroutineHelper>();
        }
    }
}
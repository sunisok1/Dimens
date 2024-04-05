using System.Collections.Generic;
using Core;
using Core.Card;
using Core.Card.Deck;
using Core.Entities;
using UnityEngine;

namespace Game.Entities.Player
{
    internal class PlayerModel : AbstractEntityModel, IHealth
    {
        internal PlayerModel(string name, Vector3Int position, AbstractDeck deck) : base(name, position)
        {
            Deck = deck;
        }

        public List<AbstractPower> Powers { get; } = new();

        public int Energy { get; set; }

        public int CurHealth { get; set; }

        public int MaxHealth { get; set; }

        public AbstractDeck Deck { get; }

        public readonly HashSet<CardController> cards = new();
    }
}
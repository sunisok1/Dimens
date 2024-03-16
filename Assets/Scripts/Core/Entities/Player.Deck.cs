using System;
using System.Collections.Generic;
using Core.Cards;
using Random = UnityEngine.Random;

namespace Core.Entities
{
    public partial class Player
    {
        private class Deck
        {
            private readonly List<Card> cards = new();

            public Deck()
            {
                for (int i = 0; i < 5; i++)
                {
                    cards.Add(new AttackCard("AttackCard", "", 1, null));
                    cards.Add(new EffectCard("EffectCard", "", 1, null));
                    cards.Add(new EquipmentCard("EquipmentCard", "", new()));
                }

                Shuffle();
            }

            public void Shuffle()
            {
                for (var i = 0; i < cards.Count; i++)
                {
                    var x = Random.Range(i, cards.Count);
                    (cards[i], cards[x]) = (cards[x], cards[i]);
                }
            }

            public List<Card> Draw(int num)
            {
                List<Card> list = new();

                int actualNum = Math.Min(num, cards.Count);

                for (int i = 0; i < actualNum; i++)
                {
                    Card card = cards[^1];
                    cards.RemoveAt(cards.Count - 1);
                    list.Add(card);
                }

                return list;
            }
        }
    }
}
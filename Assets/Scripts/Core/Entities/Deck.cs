using System;
using System.Collections.Generic;
using Core.Card;
using Core.Cards;

namespace Core.Entities
{
    public class Deck
    {
        private readonly List<AbstractCard> cards = new();

        public Deck(ICardFactory cardFactory)
        {
            cards.AddRange(cardFactory.CreateCards());
            Shuffle();
        }

        private void Shuffle()
        {
            for (var i = 0; i < cards.Count; i++)
            {
                var x = UnityEngine.Random.Range(i, cards.Count);
                (cards[i], cards[x]) = (cards[x], cards[i]);
            }
        }

        public List<AbstractCard> Draw(int num)
        {
            List<AbstractCard> list = new();

            int actualNum = Math.Min(num, cards.Count);

            for (int i = 0; i < actualNum; i++)
            {
                AbstractCard slayTheSpireCard = cards[^1];
                cards.RemoveAt(cards.Count - 1);
                list.Add(slayTheSpireCard);
            }

            return list;
        }
    }
}
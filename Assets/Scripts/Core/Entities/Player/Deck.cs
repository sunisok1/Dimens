using System;
using System.Collections.Generic;
using Core.Cards;
using Core.Cards.CardFactory;

namespace Core.Entities.Player
{
    public class Deck
    {
        private readonly List<AbstractCard> cards = new();

        public Deck(ICardFactory cardFactory)
        {
            cards.AddRange(cardFactory.CreateCards());
            Shuffle();
        }

        public void Shuffle()
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
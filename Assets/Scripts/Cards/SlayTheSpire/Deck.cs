using System.Collections.Generic;
using Cards.SlayTheSpire.Model.Red;
using Core.Card;

namespace Cards.SlayTheSpire
{
    public class Deck
    {
        private List<AbstractCard> cardList = new();

        public Deck()
        {
            cardList.Add(new Anger());
            cardList.Add(new Armaments());
            cardList.Add(new Barricade());
            cardList.Add(new Bash());
            cardList.Add(new BattleTrance());
            cardList.Add(new Anger());
            cardList.Add(new Armaments());
            cardList.Add(new Barricade());
            cardList.Add(new Bash());
            cardList.Add(new BattleTrance());
            cardList.Add(new Anger());
            cardList.Add(new Armaments());
            cardList.Add(new Barricade());
            cardList.Add(new Bash());
            cardList.Add(new BattleTrance());
            cardList.Add(new Anger());
            cardList.Add(new Armaments());
            cardList.Add(new Barricade());
            cardList.Add(new Bash());
            cardList.Add(new BattleTrance());
        }

        public AbstractCard Draw()
        {
            var card = cardList[^1];
            cardList.RemoveAt(cardList.Count - 1);
            return card;
        }
    }
}
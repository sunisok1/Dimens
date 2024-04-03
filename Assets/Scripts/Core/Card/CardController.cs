using System;
using System.Reflection;
using Common;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Card
{
    public class CardController
    {
        private readonly AbstractCard card;
        private CardView cardView;

        public CardController(AbstractCard card)
        {
            this.card = card;
        }

        public void CreateView(Transform content)
        {
            Type type = card.GetType();

            var attribute = type.GetCustomAttribute<CardAttribute>();
            if (attribute == null) return;

            cardView = ObjectManager.CreateDerived<CardView>(attribute.Path, content,card);
        }

        public void DestroyView()
        {
            cardView.DestroySelf();
        }
    }
}
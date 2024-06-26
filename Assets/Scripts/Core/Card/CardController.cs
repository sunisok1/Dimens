﻿using System;
using System.Collections;
using System.Reflection;
using Common;
using Core.Entities;
using UnityEngine;

namespace Core.Card
{
    public class CardController
    {
        private readonly AbstractCard card;
        private CardView cardView;
        private bool selected;

        private bool Selected
        {
            get => selected;
            set
            {
                if (Selector?.Filter == null) return;
                if (!Selector.Filter(card)) return;
                if (selected == value) return;
                selected = value;
                cardView.MoveTransform(selected);
                if (selected)
                    Selector.Select(this);
                else
                    Selector.Unselect(this);
            }
        }

        public void Unselect() => Selected = false;

        public ISelector Selector { get; set; }

        public CardController(AbstractCard card)
        {
            this.card = card;
        }

        public void CreateView(Transform content)
        {
            Type type = card.GetType();

            var attribute = type.GetCustomAttribute<CardAttribute>();
            if (attribute == null) return;

            cardView = ObjectManager.CreateDerived<CardView>(attribute.Path, content, card);
            cardView.OnClick += OnClick;
        }

        private void OnClick()
        {
            Selected = !Selected;
        }

        public void DestroyView()
        {
            cardView.DestroySelf();
        }

        public void Use(AbstractEntity user, AbstractEntity target)
        {
            card.Use(user, target);
        }

        public IEnumerator GetTarget(Action<AbstractEntity> returnValue)
        {
            if (card is not IHasTarget hasTarget)
                yield break;
            switch (hasTarget.Target)
            {
                case CardTarget.Enemy:
                    yield return Selector.SelectTarget(returnValue);
                    break;
                case CardTarget.AllEnemy:
                    break;
                case CardTarget.Self:
                    returnValue(Selector as AbstractEntity);
                    break;
                case CardTarget.None:
                    break;
                case CardTarget.SelfAndEnemy:
                    break;
                case CardTarget.All:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
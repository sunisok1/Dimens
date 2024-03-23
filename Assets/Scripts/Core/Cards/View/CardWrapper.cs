using System;
using Classes;
using Common;
using Core.Entities;
using UnityEngine;
using UnityEngine.EventSystems;
using EventSystem = Common.EventSystem;

namespace Core.Cards.View
{
    [Object("Card/CardWrapper")]
    public class CardWrapper : BaseObject, IPointerClickHandler
    {
        private AbstractCard card;
        private bool selected;

        private RectTransform rectTransform;
        [SerializeField] private float moveAmount = 40f;

        public override void OnCreated(params object[] objs)
        {
            base.OnCreated(objs);
            if (objs.Length > 0 && objs[0] is AbstractCard card)
            {
                this.card = card;
                rectTransform = transform as RectTransform;
                switch (card)
                {
                    case SlayTheSpireCard slayTheSpireCard:
                        ObjectManager.Create<SlayTheSpireCardObject>(transform, slayTheSpireCard);

                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(card));
                }
            }
        }

        private void MoveTransform(float moveAmount)
        {
            Vector2 position = rectTransform.anchoredPosition;
            position.y += moveAmount;
            rectTransform.anchoredPosition = position;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (selected)
            {
                OnSelected();
            }
            else
            {
                OnUnselected();
            }
        }

        private void OnUnselected()
        {
            // EventSystem.InvokeEvent(this, new SelectEventArgs<AbstractCard>(card, true));
            MoveTransform(moveAmount);

            selected = true;
        }

        private void OnSelected()
        {
            // EventSystem.InvokeEvent(this, new SelectEventArgs<AbstractCard>(card, false));
            MoveTransform(-moveAmount);

            selected = false;
        }
    }
}
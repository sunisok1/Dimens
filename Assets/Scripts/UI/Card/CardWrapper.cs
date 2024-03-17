using System;
using Common;
using Core.Cards;
using Core.System.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Card
{
    [Object("Card/CardWrapper")]
    public class CardWrapper : BaseObject, ISelectable, IPointerClickHandler
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

        private void MoveTransform(bool up)
        {
            Vector2 position = rectTransform.anchoredPosition;
            if (up) position.y += moveAmount;
            else position.y -= moveAmount;
            rectTransform.anchoredPosition = position;
        }

        public void Select()
        {
            InputSystem<AbstractCard>.Select(card);

            MoveTransform(true);

            selected = true;
        }

        public void Unselect()
        {
            InputSystem<AbstractCard>.Unselect(card);

            MoveTransform(false);

            selected = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (selected)
            {
                Unselect();
            }
            else
            {
                Select();
            }
        }
    }
}
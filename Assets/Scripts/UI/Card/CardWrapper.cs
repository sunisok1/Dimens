using System;
using System.Collections.Generic;
using Common;
using Core.Cards;
using Core.System.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Card
{
    [Object("Card/CardWrapper")]
    public class CardWrapper : BaseObject, ISelectable<AbstractCard>
    {
        private static readonly InputSystem<CardWrapper, AbstractCard> inputSystem;

        static CardWrapper()
        {
            inputSystem = InputSystem.Create<CardWrapper, AbstractCard>();
        }

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

        public void OnDestroy()
        {
            MoveTransform(true);

            selected = true;
        }

        public bool CanSelect(HashSet<CardWrapper> selectedItems)
        {
            return selectedItems.Count < 1;
        }

        public AbstractCard Data => card;

        public void OnSelected()
        {
            MoveTransform(false);

            selected = false;
        }

        public void OnUnselected()
        {
            MoveTransform(false);

            selected = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (selected)
            {
                inputSystem.Unselect(this);
            }
            else
            {
                inputSystem.Select(this);
            }
        }
    }
}
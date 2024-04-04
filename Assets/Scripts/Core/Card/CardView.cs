using System;
using Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.Card
{
    [Object("Card/CardView")]
    public class CardView : BaseObject, IPointerClickHandler
    {
        private bool selected;

        private RectTransform rectTransform;
        [SerializeField] private float moveAmount = 40f;

        internal event Action OnClick;

        private void Start()
        {
            rectTransform = transform as RectTransform;
        }

        internal void MoveTransform(bool selected)
        {
            Vector2 position = rectTransform.anchoredPosition;
            if (selected)
                position.y += moveAmount;
            else
                position.y -= moveAmount;
            rectTransform.anchoredPosition = position;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }
    }
}
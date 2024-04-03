using Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Card
{
    [Object("Card/CardView")]
    public class CardView : BaseObject, IPointerClickHandler
    {
        private bool selected;

        private RectTransform rectTransform;
        [SerializeField] private float moveAmount = 40f;

        private void Start()
        {
            rectTransform = transform as RectTransform;
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
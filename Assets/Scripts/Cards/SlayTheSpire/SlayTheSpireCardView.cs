using Common;
using Core.Card;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cards.SlayTheSpire
{
    [Object("Card/SlayTheSpireCardObject")]
    internal class SlayTheSpireCardView : CardView
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private TextMeshProUGUI cardNameText;
        [SerializeField] private TextMeshProUGUI cardTypeText;

        private SlayTheSpireCard slayTheSpireCard;

        public override void OnCreated(params object[] objs)
        {
            base.OnCreated(objs);
            if (objs.Length <= 0) return;
            if (objs[0] is not SlayTheSpireCard card) return;
            slayTheSpireCard = card;
            SetCardInfo(slayTheSpireCard);
            return;

            void SetCardInfo(SlayTheSpireCard card)
            {
                cardImage.sprite = Resources.Load<Sprite>(card.portrait);
                cardNameText.text = card.Name;
                cardTypeText.text = card.type.ToString();
            }
        }
    }
}
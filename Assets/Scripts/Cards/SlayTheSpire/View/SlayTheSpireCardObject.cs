using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cards.SlayTheSpire.View
{
    [Object("Card/SlayTheSpireCardObject")]
    internal class SlayTheSpireCardObject : BaseObject
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private TextMeshProUGUI cardNameText;
        [SerializeField] private TextMeshProUGUI cardTypeText;

        private SlayTheSpireCard slayTheSpireCard;

        public override void OnCreated(params object[] objs)
        {
            base.OnCreated(objs);
            if (objs.Length > 0 && objs[0] is SlayTheSpireCard card)
            {
                slayTheSpireCard = card;
                SetCardInfo(slayTheSpireCard);
            }
        }

        private void SetCardInfo(SlayTheSpireCard card)
        {
            cardImage.sprite = Resources.Load<Sprite>(card.portrait);
            cardNameText.text = card.Name;
            cardTypeText.text = card.type.ToString();
        }
    }
}
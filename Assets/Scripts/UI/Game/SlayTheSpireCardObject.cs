using System;
using Common;
using Core.Cards;
using TMPro;
using UnityEngine.UI;

namespace UI.Game
{
    using UnityEngine;

    [Object("Card/SlayTheSpireCardObject")]
    public class SlayTheSpireCardObject : BaseObject
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private TextMeshProUGUI cardNameText;
        [SerializeField] private TextMeshProUGUI cardTypeText;


        public override void OnCreate(params object[] objs)
        {
            base.OnCreate(objs);
            if (objs.Length > 0 && objs[0] is SlayTheSpireCard card)
                SetCardInfo(card);
        }

        public void SetCardInfo(SlayTheSpireCard card)
        {
            cardImage.sprite = Resources.Load<Sprite>(card.portrait);
            cardNameText.text = card.name;
            cardTypeText.text = card.type.ToString();
        }
    }
}
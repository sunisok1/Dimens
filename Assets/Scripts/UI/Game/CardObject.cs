using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

namespace UI.Game
{
    using UnityEngine;
    using Core;

    [Object("Game/CardUI")]
    public class CardObject : BaseObject
    {
        [SerializeField, NotNull] private Image cardImage;
        [SerializeField, NotNull] private TextMeshProUGUI cardNameText;

        public void SetCardInfo(Card card)
        {
            if (cardNameText != null)
            {
                cardNameText.text = card.Name;
            }

            if (cardImage != null)
            {
                var path = card.GetType().GetAttribute<CardImageAttribute>().Path;
                cardImage.sprite = Resources.Load<Sprite>(path); // 设置卡牌图像
            }
        }
    }
}
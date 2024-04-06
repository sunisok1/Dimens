using System;
using Common;
using Core.Card;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Cards.SlayTheSpire
{
    [Object("Card/SlayTheSpireCardObject")]
    internal class SlayTheSpireCardView : CardView
    {
        private const string cardUIResPath = "Slay the Spire/cardui/1024/";
        private const string portraitsResPath = "Slay the Spire/cards/";

        [SerializeField] private TextMeshProUGUI cardNameText;
        [SerializeField] private TextMeshProUGUI cardTypeText;
        [SerializeField] private TextMeshProUGUI cardCostText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private Image bg;
        [FormerlySerializedAs("portraits")] [SerializeField] private Image portrait;
        [SerializeField] private Image frame;
        [SerializeField] private Image banner;
        [SerializeField] private Image orb;

        private SlayTheSpireCard slayTheSpireCard;

        public override void OnCreated(params object[] objs)
        {
            base.OnCreated(objs);
            if (objs.Length <= 0) return;
            if (objs[0] is not SlayTheSpireCard card) return;
            slayTheSpireCard = card;
            SetCardStyle(slayTheSpireCard);
            SetCardInfo(slayTheSpireCard);


            return;

            void SetCardStyle(SlayTheSpireCard card)
            {
                var cardType = card.type switch
                {
                    CardType.Attack => "attack",
                    CardType.Skill => "skill",
                    CardType.Power => "power",
                    _ => throw new ArgumentOutOfRangeException()
                };
                var cardColor = card.color switch
                {
                    CardColor.Red => "red",
                    CardColor.Green => "green",
                    CardColor.Blue => "blue",
                    CardColor.Purple => "purple",
                    CardColor.Colorless => "colorless",
                    CardColor.Curse => "black",
                    _ => throw new ArgumentOutOfRangeException()
                };
                var cardRarity = card.rarity switch
                {
                    CardRarity.Common => "common",
                    CardRarity.Uncommon => "uncommon",
                    CardRarity.Rare => "rare",
                    _ => "common"
                };

                bg.sprite = Resources.Load<Sprite>($"{cardUIResPath}bg_{cardType}_{cardColor}");
                frame.sprite = Resources.Load<Sprite>($"{cardUIResPath}frame_{cardType}_{cardRarity}");
                banner.sprite = Resources.Load<Sprite>($"{cardUIResPath}banner_{cardRarity}");
                orb.sprite = Resources.Load<Sprite>($"{cardUIResPath}card_{cardColor}_orb");
            }

            void SetCardInfo(SlayTheSpireCard card)
            {
                portrait.sprite = Resources.Load<Sprite>($"{portraitsResPath}{card.portrait}");
                cardNameText.text = card.Name;
                cardTypeText.text = card.type.ToString();
                cardCostText.text = card.Cost.ToString();
                SetDescriptionText(card);
            }

            void SetDescriptionText(SlayTheSpireCard card)
            {
                string rawDescription = card.rawDescription.Replace("NL", "\n");
                if (card is IDamageCard damageCard)
                    rawDescription = rawDescription.Replace("!D!", damageCard.Damage.ToString());
                if (card is IMagicCard magicCard)
                    rawDescription = rawDescription.Replace("!M!", magicCard.MagicNumber.ToString());
                descriptionText.text = rawDescription;
            }
        }
    }
}
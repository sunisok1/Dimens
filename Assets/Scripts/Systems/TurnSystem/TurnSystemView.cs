using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.TurnSystem
{
    internal class TurnSystemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI turnNumText;
        [SerializeField] private CardPanel cardPanel;
        [SerializeField] private Button endTurnButton;
        [SerializeField] private Button confirmButton;
        [SerializeField] private Button cancelButton;

        private ITurnRunner currentTurnRunner;

        private void Start()
        {
            endTurnButton.onClick.AddListener(() => currentTurnRunner?.EndTurn());
            confirmButton.onClick.AddListener(() => currentTurnRunner?.Confirm());
            cancelButton.onClick.AddListener(() => currentTurnRunner?.Cancel());
        }

        public void UpdateTurnNumText(int turnNum)
        {
            turnNumText.text = turnNum.ToString();
        }

        public void UpdateRunnerInfo(ITurnRunner turnRunner)
        {
            currentTurnRunner = turnRunner;

            if (turnRunner is ICardOwner cardOwner)
                cardPanel.CurrentCardOwner = cardOwner;
        }
    }
}
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

        // private ITurnRunner currentRunner;


        public void UpdateTurnNumText(int turnNum)
        {
            turnNumText.text = turnNum.ToString();
        }

        public void UpdateRunnerInfo(ITurnRunner turnRunner)
        {
            if (turnRunner is ICardOwner cardOwner)
                cardPanel.CurrentCardOwner = cardOwner;
            
            endTurnButton.onClick.RemoveAllListeners();
            endTurnButton.onClick.AddListener(turnRunner.EndTurn);
        }
    }
}
using Core;
using TMPro;
using UnityEngine;

namespace Systems.TurnSystem
{
    internal class TurnSystemView:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI turnNumText;

        public void UpdateRunnerInfo(ITurnRunner turnRunner)
        {
            
        }
    }
}
using Core.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Entities.Player
{
    internal class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private Image fill;

        public void UpdateHealth(IHealth health)
        {
            healthText.text = $"{health.CurHealth}/{health.MaxHealth}";
            fill.fillAmount = (float)health.CurHealth / health.MaxHealth;
        }
    }
}
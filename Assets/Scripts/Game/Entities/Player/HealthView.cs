using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Entities.Player
{
    internal class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private Image fill;


        public void UpdateHealth(int currentHealth, int maxHealth)
        {
            healthText.text = $"{currentHealth}/{maxHealth}";
            fill.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
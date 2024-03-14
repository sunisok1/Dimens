using TMPro;
using UnityEngine;

namespace Core.Entities
{
    [Object("Entity/Player")]
    public class PlayerObject : BaseObject
    {
        [SerializeField] private TextMeshProUGUI NameText;
        [SerializeField] private TextMeshProUGUI HealthText;

        public override void OnCreate(params object[] objs)
        {
            base.OnCreate(objs);
            var player = objs[0] as Player;
            NameText.text = player.Name;
            HealthText.text = $"{player.Health}/{player.MaxHealth}";
        }
    }
}
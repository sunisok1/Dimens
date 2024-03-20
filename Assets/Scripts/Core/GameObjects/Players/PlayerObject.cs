using Common;
using Core.Entities.Players;
using TMPro;
using UnityEngine;

namespace Core.GameObjects.Players
{
    [Object("Entity/Player")]
    public class PlayerObject : EntityObject
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI healthText;
        private Player player;


        public override void OnCreated(params object[] objs)
        {
            base.OnCreated(objs);
            if (objs[0] is not Entities.Players.Player player) return;
            nameText.text = player.Name;
            healthText.text = $"{player.Health}/{player.MaxHealth}";
        }

        public override void OnSelected()
        {
            base.OnSelected();
            transform.localScale = Vector3.one * 1.1f;
        }

        public override void OnUnselected()
        {
            base.OnUnselected();
            transform.localScale = Vector3.one;
        }
    }
}
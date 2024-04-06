using System;
using Common;
using TMPro;
using UnityEngine;

namespace Game.Entities.Player
{
    [Object("Entity/PlayerView")]
    public class PlayerView : BaseObject, ISelectable
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private HealthView healthView;

        private Player player;

        public override void OnCreated(params object[] objs)
        {
            base.OnCreated(objs);
            if (objs.Length <= 0) return;

            player = objs[0] as Player;
            if (player == null) return;

            UpdateName();
            UpdatePosition();
            player.OnHealthChange += UpdateHealth;
        }

        private void OnDestroy()
        {
            player.OnHealthChange -= UpdateHealth;
        }

        public void UpdatePosition()
        {
            transform.position = player.Position;
        }

        private void UpdateName()
        {
            nameText.text = player.Name;
        }

        public bool Select()
        {
            transform.localScale = Vector3.one * 1.1f;
            OnSelected?.Invoke();
            return true;
        }


        public bool Deselect()
        {
            transform.localScale = Vector3.one;
            OnDeselected?.Invoke();
            return true;
        }

        // 定义事件，当玩家被选中或取消选中时触发
        public event Action OnSelected;
        public event Action OnDeselected;

        internal void UpdateHealth(int currentHealth, int maxHealth) => healthView.UpdateHealth(currentHealth, maxHealth);
    }
}
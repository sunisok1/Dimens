using System;
using Classes.Entities;
using Classes.Entities.View;
using Common;
using TMPro;
using UnityEngine;

namespace Core.Entities.View
{
    [Object("Entity/Player")]
    public class PlayerView : EntityView, ISelectable
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI healthText;

        public override void OnCreated(params object[] objs)
        {
            base.OnCreated(objs);
            if (objs.Length <= 0) return;
            if (objs[0] is not PlayerModel model) return;
            UpdatePosition(model.Position);
            UpdateName(model.Name);
        }


        public override void UpdatePosition(Vector3Int position)
        {
            transform.position = position;
        }

        public override void UpdateName(string name)
        {
            nameText.text = name;
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

        public void UpdateHealth(IHealth health)
        {
            healthText.text = $"{health.CurHealth}/{health.MaxHealth}";
        }
    }
}
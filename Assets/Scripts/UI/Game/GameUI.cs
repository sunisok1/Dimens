using Common;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Game
{
    public class GameUI : BaseUI
    {


        [SerializeField] private Button ConfirmButton;
        [SerializeField] private Button CancelButton;

        public override void OnCreated(params object[] objs)
        {
            base.OnCreated(objs);
        }
    }
}
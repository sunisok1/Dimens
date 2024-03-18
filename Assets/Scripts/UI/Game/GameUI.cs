using Common;
using Core.Cards;
using Core.System.Input;
using UI.Card;
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
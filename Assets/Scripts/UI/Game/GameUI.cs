using Common;
using UnityEditor;

namespace UI.Game
{
    public class GameUI : BaseUI
    {
#if UNITY_EDITOR
        [MenuItem("Tools/GameUI/Close")]
        public static void Close()
        {
            UIManager.Close<GameUI>();
        }
#endif
    }
}
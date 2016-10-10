using UnityEngine;

namespace Assets.Scripts.Game_Controllers.Game_Modes
{
    public interface IGameMode
    {
        void RightMouseClicked();
        void LeftMouseClicked();
        // This is NOT a built-in method, you need to call it in MonoBehaviour's update to work
        void Update();
        void Exit();
        void Select(GameObject gameObject);
    }
}

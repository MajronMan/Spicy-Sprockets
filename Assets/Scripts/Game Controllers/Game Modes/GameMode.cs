using UnityEngine;

namespace Assets.Scripts.Game_Controllers.Game_Modes {
    /// <summary>
    /// Main interface to define the game behaviour in response to user's actions
    /// </summary>
    public interface IGameMode {
        /// <summary>
        /// Defines behaviour on right mouse click
        /// </summary>
        void RightMouseClicked();

        /// <summary>
        /// Defines behaviour on left mouse click
        /// </summary>
        void LeftMouseClicked();

        /// <summary>
        /// This is NOT a built-in method, you need to call it in MonoBehaviour's update to work
        /// </summary>
        void Update();

        /// <summary>
        /// Defines behaviour on change of game mode
        /// </summary>
        void Exit();

        // ???
        void Select(GameObject gameObject);
    }
}
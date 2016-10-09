using UnityEngine;

namespace Assets.Scripts.Game_Controllers.Game_Modes
{
    public class DefaultMode : IGameMode
    {
        private int i = 0;

        public void RightMouseClicked()
        {
            Debug.Log("Right" + i);
            i++;

        }

        public void LeftMouseClicked()
        {
            Debug.Log("Left" + i);
            i++;
        }

        public void Update()
        {
        
        }

        public void Exit()
        {
        
        }

        public void Select(GameObject gameObject)
        {
        
        }
    }
}

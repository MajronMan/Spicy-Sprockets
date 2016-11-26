using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class AutomaticInterface : MonoBehaviour
    {
        public GameObject MainPanel;
        public GameObject ResourcePanel;

        public void Start ()
        {
            CreatePanels();
            //CreateButtons();
        }

        private void CreateButtons()
        {
            throw new System.NotImplementedException();
        }

        private void CreatePanels()
        {
            // lower left corner in percent
            var minXY = new Vector2(0.8f, 0.3f);
            //upper right corner in percent
            var maxXY = new Vector2(1, 1);
            MainPanel = Loader.NewInstance(PrefabPaths.Panel);

            SetPosition(MainPanel.GetComponent<RectTransform>(), minXY, maxXY);
            
        }

        private void SetPosition(RectTransform rectTransform, Vector2 lowerLeft, Vector2 upperRight)
        {
            rectTransform.SetParent(rectTransform);
            rectTransform.anchorMax = upperRight;
            rectTransform.anchorMin = lowerLeft;
            rectTransform.offsetMax = rectTransform.offsetMin = Vector2.zero;
        }
    }
}

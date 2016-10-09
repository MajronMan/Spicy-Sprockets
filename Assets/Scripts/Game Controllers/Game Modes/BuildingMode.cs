using System;
using System.Collections;
using Assets.Scripts.Buildings;
using Assets.Scripts.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Game_Controllers.Game_Modes
{
    public class BuildingMode : IGameMode
    {
        public System.Type ToBeBuiltType;
        private Building _preview;
        private int time;

        public BuildingMode(Type buildingType)
        {
            this.ToBeBuiltType = buildingType;
            SetPreview();
        }

        public void RightMouseClicked()
        {
            Exit();
        }

        public void LeftMouseClicked()
        {
            Controllers.CurrentBuildingManager.Build(ToBeBuiltType, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
            Exit();
        }

        public void Update()
        {
            if (_preview == null) return;
            var previewPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            previewPosition.z = 0;
            _preview.transform.position = previewPosition;

            if (time > 30)
            {
                time = 0;
                Debug.Log(_preview.transform.position);
            }
            time++;
        }

        public void SetPreview()
        {
            var gameObject = new GameObject("Preview", typeof(SpriteRenderer), typeof(BuildingPreview));
            _preview = (Building) gameObject.GetComponent(typeof(BuildingPreview));
            _preview.SetSprite(ToBeBuiltType);
            _preview.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        public void Exit()
        {
            Object.Destroy(_preview.gameObject);
            Controllers.GameController.EnterDefaultMode();
        }

        public void Select(GameObject gameObject)
        {
            ToBeBuiltType = gameObject.GetType();
            SetPreview();
        }
    }
}

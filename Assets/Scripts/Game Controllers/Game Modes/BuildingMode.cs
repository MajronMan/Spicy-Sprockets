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
        private GameController _gameController;
        public System.Type ToBeBuiltType;
        private Building _preview;
        private int time;

        public BuildingMode(Type buildingType, GameController gameController)
        {
            this._gameController = gameController;
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
            
            /*
            if (time > 30)
            {
                time = 0;
                Debug.Log(_preview.transform.position);
            }
            time++;
            */
        }

        public void SetPreview()
        {
            var gameObject = new GameObject("Preview", typeof(SpriteRenderer), typeof(BuildingPreview));
            _preview = (Building) gameObject.GetComponent(typeof(BuildingPreview));
            _preview.SetSprite(ToBeBuiltType);
            var buildingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            buildingPosition.z = 0;
            _preview.transform.position = Camera.main.ScreenToWorldPoint(buildingPosition);
            _preview.transform.SetParent(_gameController.GetCurrentCity()._mapInstance.transform, true);
            Util.Rescale(_preview.GetComponent<SpriteRenderer>(), 60, 60);


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

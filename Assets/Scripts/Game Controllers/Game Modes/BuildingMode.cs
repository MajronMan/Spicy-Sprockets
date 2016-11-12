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

        private bool Overlaps(Vector2 where, System.Type what)
        {
            //need to replace 20 with size of buildings of type what - xsize/20 and ysize/2
            
            if (Physics2D.OverlapArea(new Vector2((where.x-10f), (where.y+10f)), new Vector2((where.x + 10f), (where.y - 10f)),8) == null)
                return false;
            else
                return true;
        }

        //feedback todo
        private void CantBuildShit (string why, Vector2 where)
        {
            switch (why)
            {
                case "overlap":
                    break;
                default:
                    return;
                
            }

        }
        

        public void LeftMouseClicked()
        {
            
            if (Overlaps(new Vector2(Input.mousePosition.x, Input.mousePosition.y), ToBeBuiltType))
            {
                CantBuildShit("overlap", new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
            }
            else
            {
                Controllers.CurrentBuildingManager.Build(ToBeBuiltType, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
                Exit();
            }
        }

        public void Update()
        {
            if (_preview == null) return;
            var previewPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            previewPosition.z = 0;
            _preview.transform.position = previewPosition;
        }

        public void SetPreview()
        {
            var gameObject = new GameObject("Preview", typeof(SpriteRenderer), typeof(BuildingPreview));
            _preview = (Building) gameObject.GetComponent(typeof(BuildingPreview));
            _preview.SetSprite(ToBeBuiltType);
            var buildingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            buildingPosition.z = 0;
            _preview.transform.position = Camera.main.ScreenToWorldPoint(buildingPosition);
            _preview.transform.SetParent(_gameController.GetCurrentCity().MapInstance.transform, true);
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

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
        private bool canBeBuilt;

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
        
        private bool Overlaps(BoxCollider2D what, int layer)
        {
            LayerMask a = 1 << layer;
            return what.IsTouchingLayers(a);
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
            
            if (canBeBuilt)
            {
                Controllers.CurrentBuildingManager.Build(ToBeBuiltType, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                Exit();
            }
            else
            {
                CantBuildShit("overlap", new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            }
        }

        public void Update()
        {
            if (_preview == null) return;
            
            
            var previewPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            previewPosition.z = 0;
            _preview.transform.position = previewPosition;


            var collider = _preview.gameObject.GetComponent<BoxCollider2D>();
            if (Overlaps(collider,8))//||InsufficientResources(_preview))
            {
                canBeBuilt = false;
                
            } else
            {
                canBeBuilt = true;
                
            }
            if (canBeBuilt)
            {
                _preview.MyRenderer.color = Color.green;
            } else _preview.MyRenderer.color = Color.red;


            if (Input.GetMouseButton(0)&&_preview.GetComponent<BoxCollider2D>().IsTouchingLayers(1))
            {
                LeftMouseClicked();
            }
            if (Input.GetMouseButton(1))
            {
                RightMouseClicked();
            }
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
            Collider.addCollider(gameObject, new Vector2(2, 1), Camera.main.ScreenToWorldPoint(buildingPosition), _gameController.GetCurrentCity().MapInstance.transform);
            Collider.addFakeRigidBody(gameObject);
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

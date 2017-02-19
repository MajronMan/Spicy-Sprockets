using System;
using Assets.Scripts.Buildings;
using Assets.Scripts.Interface;
using Assets.Scripts.Utils;
using Assets.Static;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Assets.Scripts.Game_Controllers.Game_Modes {
    /// <summary>
    /// Modifies behaviour of mouse clicks to enable creating buildings
    /// </summary>
    public class BuildingMode : IGameMode {
        /// <summary>
        /// Type of building that player wishes to create
        /// </summary>
        public Type ToBeBuiltType;

        /// <summary>
        /// Building sprite hovering after mouse cursor
        /// </summary>
        private Building _preview;

        //private int _time;
        private bool _canBeBuilt = true;

        /// <summary>
        /// Map, on which the building shall be built
        /// </summary>
        private Map _map;

        /// <summary>
        /// Initialize the mode to create a building of type buildingType
        /// </summary>
        /// <param name="buildingType">Type of building player wishes to create</param>
        public BuildingMode(Type buildingType) {
            _map = Controllers.CurrentCityController.MapInstance;

            ToBeBuiltType = buildingType;
            //Create a sprite of given type that hovers after cursor
            SetPreview();
        }

        /// <summary>
        /// Defines game behaviour on right mouse click
        /// </summary>
        public void RightMouseClicked() {
            Exit();
        }


        //feedback todo
        //I like the name
        private void CantBuildShit(string why, Vector2 where) {
            switch (why) {
                case "overlap":
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// Defines game behaviour on left mouse click
        /// </summary>
        public void LeftMouseClicked() {
            if (_canBeBuilt && _preview.Collides == 0) {
                // get mouse position and create a building of desired type placed by the cursor
                Controllers.CurrentBuildingManager.Build(ToBeBuiltType, _map.SnapMouse());
                // return to default mode
                Exit();
            } else {
                CantBuildShit("overlap", new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            }
        }

        /// <summary>
        /// Needs to be called manually since it's not a MonoBehaviour
        /// </summary>
        public void Update() {
            // Check if preview exists
            if (_preview == null) return;

            // if it does, place it by the mouse cursor snapped to grid
            _preview.transform.position = _map.SnapMouse();

            _canBeBuilt =
                Controllers.CurrentCityController.MyInfo.SufficientResources(
                    Controllers.ConstantData.BuildingCosts[ToBeBuiltType]);
            if (_canBeBuilt && _preview.Collides == 0) {
                _preview.Renderer.color = Color.green;
            } else _preview.Renderer.color = Color.red;


            if (Input.GetMouseButton(0) && _preview.GetComponent<BoxCollider2D>().IsTouchingLayers(1)) {
                LeftMouseClicked();
            }
            if (Input.GetMouseButton(1)) {
                RightMouseClicked();
            }
        }

        /// <summary>
        /// Create a preview which has same sprite as desired building but is not its instance so it does not start coroutines etc.
        /// </summary>
        public void SetPreview() {
            // create the game object which obeys BuildingPreview script and renders a sprite
            var gameObject = new GameObject("Preview", typeof(SpriteRenderer), typeof(BuildingPreview));
            // Actual preview is the script component of the game object
            _preview = (Building) gameObject.GetComponent(typeof(BuildingPreview));
            // set sprite to the same as desired type
            _preview.SetSprite(ToBeBuiltType);

            // place it by the mouse cursor
            var buildingPosition = _map.SnapMouse();
            _preview.transform.position = buildingPosition;
            // make the preview a child of map
            _preview.transform.SetParent(gameObject.transform, true);
            // change size of the sprite

            SpicyCollider.AddCollider(gameObject, new Vector2(2, 1), buildingPosition, _map.transform);
            SpicyCollider.AddFakeRigidBody(gameObject);

            Sprites.Rescale(_preview.GetComponent<SpriteRenderer>(), 0.6f, 0.6f);
        }

        /// <summary>
        /// Go back to default mode
        /// </summary>
        public void Exit() {
            // no need for preview anymore
            Object.Destroy(_preview.gameObject);
            Controllers.GameController.EnterDefaultMode();
        }

        /// <summary>
        /// A method that chooses which type should be built and creates a preview
        /// </summary>
        /// <param name="gameObject">Object which type is to be copied</param>
        public void Select(GameObject gameObject) {
            ToBeBuiltType = gameObject.GetType();
            SetPreview();
        }
    }
}
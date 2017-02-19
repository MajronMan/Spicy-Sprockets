using Assets.Scripts.Interface;
using Assets.Scripts.MapGenerator;
using Assets.Scripts.Utils;
using Assets.Static;
using UnityEngine;

namespace Assets.Scripts.Game_Controllers {
    /// <summary>
    /// Manages a single city owned by the player
    /// </summary>
    public class CityController : MonoBehaviour {
        /// <summary>
        /// Actual map where the city is built
        /// </summary>
        public Map MapInstance;

        private BuildingManager _buildingManagerInstance;

        /// <summary>
        /// This city's data, e. g. collected resources, population etc.
        /// </summary>
        public Info MyInfo;

        private const int MapSize = 100;
        private const int MapSideTiles = 100;

        /// <summary>
        /// Defines what happens when a new city is created
        /// </summary>
        public void CreateCity() {
            //place the map in the middle of the screen
            var mapPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f));
            mapPosition.z = 0;

            MapInstance = Instantiate(Prefabs.Map, mapPosition, Quaternion.identity, transform).GetComponent<Map>();
            MapInstance.name = "Map";

            // set desired map size
            Sprites.Rescale(MapInstance.GetComponent<SpriteRenderer>(), MapSize, MapSize);

            MapInstance.SideTiles = MapSideTiles;
            MapInstance.DrawGrid();

            // create a building manager for this city
            var newGameObject = new GameObject("Building Manager", typeof(BuildingManager));
            _buildingManagerInstance = newGameObject.GetComponent<BuildingManager>();
            // and make it a child of this controller
            _buildingManagerInstance.transform.SetParent(transform);
            _buildingManagerInstance.SetMapInstance(MapInstance);
            // create basic information container for this city
            MyInfo = new Info(this);
            SourcesGenerator.Generate(MapInstance);
        }

        public BuildingManager GetBuildingManager() {
            return _buildingManagerInstance;
        }
    }
}
using System;
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

        private IntVector2 _mapSize = new IntVector2(10000, 10000);

        /// <summary>
        /// Defines what happens when a new city is created
        /// </summary>
        public void CreateCity() {
            //place the map in the middle of the screen
            var mapPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2));
            mapPosition.z = 0;
            var mapGameObject = Instantiate(Prefabs.Map, mapPosition, transform.rotation) as GameObject;
            try
            {
                MapInstance = mapGameObject.GetComponent<Map>();
                // make the map a child of this city controller
                MapInstance.transform.SetParent(transform);
                // set desired map size
                Util.Rescale(MapInstance.GetComponent<SpriteRenderer>(), _mapSize.X, _mapSize.Y);
                MapInstance.name = "Map";
            }
            catch (Exception e)
            {
                Debug.Log("Cannot instantiate map from Prefabs.Map. Exception was \n"+ e.StackTrace);
            }
           
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
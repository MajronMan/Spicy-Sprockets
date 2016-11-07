using System.Collections.Generic;
using Assets.Scripts.Interface;
using Assets.Scripts.Sources_of_Resources;
using Assets.Scripts.Utils;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Scripts.Game_Controllers
{
    /// <summary>
    /// Manages a single city owned by the player
    /// </summary>
    public class CityController : MonoBehaviour
    {
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
        public List<Source> Sources = new List<Source>();

        /// <summary>
        /// Defines what happens when a new city is created
        /// </summary>
        /// <param name="mapPrefab">Prefab which shall be instatiated</param>
        public void BeginGame(Map mapPrefab)
        {
            // place the map at the middle of the screen
            var mapPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2));
            mapPosition.z = 0;
            MapInstance = Instantiate(mapPrefab, mapPosition, transform.rotation) as Map;
            // make the map a child of this city controller
            MapInstance.transform.SetParent(transform);
            // set desired map size
            Util.Rescale(MapInstance.GetComponent<SpriteRenderer>(), _mapSize.x, _mapSize.y);
            MapInstance.name = "Map";
            // create a building manager for this city
            var newGameObject = new GameObject("Building Manager", typeof(BuildingManager));
            _buildingManagerInstance = newGameObject.GetComponent<BuildingManager>();
            // and make it a child of this controller
            _buildingManagerInstance.transform.SetParent(transform);
            _buildingManagerInstance.SetMapInstance(MapInstance);
            // create basic information container for this city
            MyInfo = new Info(this);
            CreateSources();
        }

        public BuildingManager GetBuildingManager()
        {
            return _buildingManagerInstance;
        }

        /// <summary>
        /// Creates randomly distributed sources of resources and places them on map
        /// </summary>
        public void CreateSources()
        {
            var mrenderer = MapInstance.GetComponent<Renderer>();
            // watch out not to place them outside of the map
            var xmax = mrenderer.bounds.size.x/2;
            var ymax = mrenderer.bounds.size.y/2;
            for (var i = 0; i < 20; i++)
            {
                var sourceGameObject = new GameObject("Source " + i);
                // remember the source which is a script attatched to new game object
                Sources.Add(sourceGameObject.AddComponent<Source>());
                sourceGameObject.transform.SetParent(MapInstance.transform);
                // find a random place for this source
                sourceGameObject.transform.localPosition = Vector3.zero;
                var x = Random.Range(-xmax, xmax);
                var y = Random.Range(-ymax, ymax);
                sourceGameObject.transform.Translate(x, y, 0);
            }
        }
    }
}

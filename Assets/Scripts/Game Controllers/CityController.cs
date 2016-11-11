using System.Collections.Generic;
using Assets.Scripts.Interface;
using Assets.Scripts.MapGenerator;
using Assets.Scripts.Sources_of_Resources;
using Assets.Scripts.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Scripts.Game_Controllers
{
    public class CityController : MonoBehaviour
    {
        public Map MapInstance;
        private BuildingManager _buildingManagerInstance;
        public Info MyInfo;
        private IntVector2 _mapSize = new IntVector2(10000, 10000);

        public void BeginGame(Map mapPrefab)
        {
            
            var mapPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2));
            mapPosition.z = 0;
            MapInstance = Instantiate(mapPrefab, mapPosition, transform.rotation) as Map;
            MapInstance.transform.SetParent(transform);
            Util.Rescale(MapInstance.GetComponent<SpriteRenderer>(), _mapSize.x, _mapSize.y);
            MapInstance.name = "Map";
            var newGameObject = new GameObject("Building Manager", typeof(BuildingManager));
            _buildingManagerInstance = newGameObject.GetComponent<BuildingManager>();
            _buildingManagerInstance.transform.SetParent(transform);
            _buildingManagerInstance.SetMapInstance(MapInstance);
            MyInfo = new Info();
            SourcesGenerator.Generate(MapInstance);
        }

        public BuildingManager GetBuildingManager()
        {
            return _buildingManagerInstance;
        }
    }
}

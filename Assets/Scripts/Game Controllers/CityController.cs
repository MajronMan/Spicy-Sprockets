using Assets.Scripts.Interface;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Game_Controllers
{
    public class CityController : MonoBehaviour
    {
        public Map _mapInstance;
        private BuildingManager _buildingManagerInstance;
        public Info MyInfo;

        public void BeginGame(Map mapPrefab)
        {
            
            var mapPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2));
            mapPosition.z = 0;
            _mapInstance = Instantiate(mapPrefab, mapPosition, transform.rotation) as Map;
            _mapInstance.transform.SetParent(transform);
            Util.Rescale(_mapInstance.GetComponent<SpriteRenderer>(), 10000, 10000);
            _mapInstance.name = "Map";
            var newGameObject = new GameObject("Building Manager", typeof(BuildingManager));
            _buildingManagerInstance = newGameObject.GetComponent<BuildingManager>();
            _buildingManagerInstance.transform.SetParent(transform);
            _buildingManagerInstance.SetMapInstance(_mapInstance);
            MyInfo = new Info();
        }

        public BuildingManager GetBuildingManager()
        {
            return _buildingManagerInstance;
        }
    }
}

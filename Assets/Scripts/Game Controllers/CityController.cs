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
            _mapInstance = Instantiate(mapPrefab, transform.position, transform.rotation) as Map;
            _mapInstance.transform.localScale = new Vector3(100, 100, 100);
            _mapInstance.transform.SetParent(transform);
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

using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class StrategyManager : MonoBehaviour {
        public Map MapPrefab;
        private Map _mapInstance=null;
        public BuildingManager BuildingManagerPrefab;
        private BuildingManager _buildingManagerInstance=null;
        public Info CityInformation;

        private void Start()
        {
            BeginGame();
        }

        private void BeginGame()
        {
            _mapInstance = Instantiate(MapPrefab, transform.position, transform.rotation) as Map;
            _mapInstance.transform.localScale = new Vector3(50, 50, 50);
            _mapInstance.transform.SetParent(transform);
            _mapInstance.name = "Map Instance";
            _buildingManagerInstance = Instantiate(BuildingManagerPrefab);
            _buildingManagerInstance.transform.SetParent(transform);
            _buildingManagerInstance.name = "Building Manager";
            _buildingManagerInstance.SetMapInstance(_mapInstance);
            CityInformation = new Info(_buildingManagerInstance);
        }

        private void RestartGame()
        {
            StopAllCoroutines();
            Destroy(_mapInstance.gameObject);
            BeginGame();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }
        }

        public void MapClicked()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            try
            {
                _buildingManagerInstance.Build(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
            }
            catch (NullReferenceException e)
            {
            }
        }

        public BuildingManager GetBuildingManager()
        {
            return _buildingManagerInstance;
        }

        public void ButtonClicked()
        {
            foreach (var building in CityInformation.Buildings)
            {
                Debug.Log(building);
            }
            _buildingManagerInstance.SetActive(true);
        }
    }
}

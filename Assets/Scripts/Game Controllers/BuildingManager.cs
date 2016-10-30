using System.Collections.Generic;
using Assets.Scripts.Buildings;
using Assets.Scripts.Interface;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Game_Controllers
{
    [System.Serializable]
    public class BuildingManager : MonoBehaviour
    {
        public List<Building> Built = new List<Building>();
        private Map _mapInstance;
        public Dictionary<string, System.Type> AvailableBuildings = new Dictionary<string, System.Type>();
    
        public Building Build(System.Type buildingType, Vector3 location)
        {
            var go = new GameObject("Building", buildingType, typeof(SpriteRenderer));
            var newBuilding = go.GetComponent<Building>();
            var buildingPosition = Camera.main.ScreenToWorldPoint(location);
            buildingPosition.z = 0;
            newBuilding.transform.position = buildingPosition;
            newBuilding.transform.SetParent(_mapInstance.transform, true);
            Built.Add(newBuilding);

            Controllers.CurrentInfo.BuildingCosts(buildingType);
            return newBuilding;
        }

        public void SetMapInstance(Map mapInstance)
        {
            this._mapInstance = mapInstance;
        }

        public void Start()
        {
            // load that from a xml pls
            AvailableBuildings.Add("Production Building", typeof(ProductionBuilding));
            AvailableBuildings.Add("Storage Building", typeof(StorageBuilding));
        }
   
        public Map GetMapInstance()
        {
            return _mapInstance;
        }
    }
}

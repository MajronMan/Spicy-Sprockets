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
        /// <summary>
        /// A list of all buildings that were created and are active
        /// </summary>
        public List<Building> Built = new List<Building>();
        /// <summary>
        /// Map on which buildings associated with this manager are built
        /// </summary>
        private Map _mapInstance;
        /// <summary>
        /// A dictionary informing which buildings is player allowed to build
        /// </summary>
        public Dictionary<string, System.Type> AvailableBuildings = new Dictionary<string, System.Type>();


        /// <summary>
        /// Creates a new building at given point on screen
        /// </summary>
        /// <param name="buildingType">Type of the building you want to create</param>
        /// <param name="location">Point on screen where the building will appear</param>
        /// <returns>The created building</returns>
        public Building Build(System.Type buildingType, Vector3 location)
        {
            // create a new game object which behaviour is defined by buldingType's script and renders a sprite
            var buildingGameObject = new GameObject("Building", buildingType, typeof(SpriteRenderer));
            var newBuilding = buildingGameObject.GetComponent<Building>();
            // building should appear at given location on screen, which is not the same as its world location
            var buildingPosition = Camera.main.ScreenToWorldPoint(location);

            // to set proper order of sprites rendered
            buildingPosition.z = 0;

            //need to find a way to get size dependant on building
            Collider.addCollider(buildingGameObject, new Vector2(2, 1), buildingPosition, _mapInstance.transform);

            newBuilding.transform.position = buildingPosition;
            newBuilding.transform.SetParent(_mapInstance.transform, true);
            // remember we built it
            Built.Add(newBuilding);

            // take building cost from the storage
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

using System.Collections.Generic;
using Assets.Scripts.Buildings;
using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class BuildingManager : MonoBehaviour
    {

        private List<Building> _built = new List<Building>();
        private Map _mapInstance;
        public Building BuildingPrefab;
        private bool _active = false;

        public void Build(Vector3 location)
        {
            if (!this._active) return;
            Building newBuilding = Instantiate(BuildingPrefab);
            newBuilding.transform.position = Camera.main.ScreenToWorldPoint(location);
            newBuilding.transform.localScale=new Vector3(20,20,20);
            newBuilding.transform.SetParent(_mapInstance.transform, true);
            this._active = false;
            _built.Add(newBuilding);
        }

        public void SetMapInstance(Map MapInstance)
        {
            this._mapInstance = MapInstance;
        }

        public void SetActive(bool active)
        {
            this._active = active;
        }

        public bool GetActive()
        {
            return _active;
        }

        public List<Building> GetBuilt()
        {
            return this._built;
        }
    }
}

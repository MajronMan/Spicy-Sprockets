using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Resources;
using UnityEngine;

namespace Assets.Scripts.Utils {
    /// <summary>
    /// Contains variable data about a single city
    /// </summary>
    public class Info {
        public Dictionary<string, Resource> Resources = new Dictionary<string, Resource>();
        public Population ThePeople;
        public Money MyMoney = new Money();
        public int CurrentStorageVolume;
        public CityController MyCity;

        //maybe later use given limits from file or depending on sth
        private int _maxStorageVolume = 10000;
        private int _maxPopulation = 200;

        public Info(CityController cityController) {
            MyCity = cityController;
        }

        public void LoadInitialResources(Dictionary<string, Dictionary<string, string>> resourceTypes) {
            foreach (var type in resourceTypes.Keys) {
                var res = new Resource(type, int.Parse(resourceTypes[type]["initial"]));
                Resources.Add(type, res);
                CurrentStorageVolume += res.GetVolume();
            }
            var gameObject = new GameObject("People", typeof(Population));
            gameObject.transform.SetParent(MyCity.transform);
            ThePeople = gameObject.GetComponent<Population>();
        }

        public Resource this[string key] {
            get { return Resources[key]; }

            set { Resources[key] = value; }
        }

        public Resource this[Resource key] {
            get { return Resources[key.MyType]; }
            set { Resources[key.MyType] = value; }
        }

        public int GetPopulationLimit() {
            return _maxPopulation;
        }

        public bool SufficientResources(List<Resource> costs) {
            //no idea again but I hope it works
            return costs.Aggregate(true, (current, resource) => current & Resources[resource.MyType] >= resource);
        }

        public bool HasEnoughStorageSpace(int load) {
            return CurrentStorageVolume + load < _maxStorageVolume;
        }

        public void UseResources(List<Resource> costs) {
            foreach (var resource in costs) {
                Resources[resource.MyType] -= resource;
                CurrentStorageVolume -= resource.GetVolume();
            }
        }

        public void BuildingCosts(System.Type buildingType) {
            UseResources(Controllers.ConstantData.BuildingCosts[buildingType]);
        }

        public void ChangeStorageLimit(int by) {
            _maxStorageVolume += by;
        }

        public void ChangePopulationLimit(int by) {
            _maxPopulation += by;
        }
    }
}
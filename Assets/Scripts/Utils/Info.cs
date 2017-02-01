using System;
using System.Collections.Generic;
 using System.Linq;
 using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using UnityEngine;

namespace Assets.Scripts.Utils {
    /// <summary>
    /// Event informing about added or removed resources
    /// </summary>
    /// <param name="sender">Who sent event</param>
    public delegate void ResourceStateChangedEventHandler2_primalOrigins(object sender, EventArgs e);

    public delegate void MoneyStateChangedEH(object sender, EventArgs e);

    /// <summary>
    /// Contains variable data about a single city
    /// </summary>
    public class Info {
        public Dictionary<ResourceType, Resource> Resources = new Dictionary<ResourceType, Resource>();
        public Population ThePeople;
        private Money _myMoney = new Money();
        public int UsedStorageVolume;
        public CityController MyCity;
        public event ResourceStateChangedEventHandler2_primalOrigins Changed;
        public event MoneyStateChangedEH MoneyChanged;
        //maybe later use given limits from file or depending on sth
        private int _maxStorageVolume = 10000;
        private int _maxPopulation = 200;

        public Money MyMoney
        {
            get
            {
                return _myMoney;
            }
            set
            {
                _myMoney = value;
                OnMoneyChanged(EventArgs.Empty);
            }
        }

        public Info(CityController cityController) {
            MyCity = cityController;
        }

        protected virtual void OnMoneyChanged(EventArgs e)
        {
            if (MoneyChanged != null)
                MoneyChanged(this, e);
        }

        protected virtual void OnResourceStateChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        public void LoadInitialResources(List<Resource> initialResources) {
            foreach (var resource in initialResources)
            {
                Resources.Add(resource.Type, resource);
                UsedStorageVolume += resource.Volume;
            }
            var gameObject = new GameObject("People");
            ThePeople = gameObject.AddComponent<Population>();
            gameObject.transform.SetParent(MyCity.transform);
        }

        public Resource this[ResourceType key] {
            get { return Resources[key]; }

            set
            {
                Resources[key] = value; 
                OnResourceStateChanged(EventArgs.Empty);
            }
        }

        public Resource this[Resource key]
        {
            get { return Resources[key.Type]; }
            set
            {
                Resources[key.Type] = value; 
                OnResourceStateChanged(EventArgs.Empty);
            }
        }

        public int GetPopulationLimit() {
            return _maxPopulation;
        }

        public bool SufficientResources(List<Resource> costs) {
            //no idea again but I hope it works
            return costs.Aggregate(true, (current, resource) => current && Resources[resource.Type] >= resource);
        }

        public bool HasEnoughStorageSpace(int load) {
            return UsedStorageVolume + load < _maxStorageVolume;
        }


        public void UseResources(List<Resource> costs) {
            costs.ForEach(resource => {
                Resources[resource.Type] -= resource;
                UsedStorageVolume -= resource.Volume;
            });
            OnResourceStateChanged(EventArgs.Empty);
        }

        public void BuildingCosts(System.Type buildingType) {
            UseResources(Controllers.ConstantData.BuildingCosts[buildingType]);
        }

        public void ChangeStorageLimit(int by) {
            _maxStorageVolume += by;
        }

        public void ChangePopulationLimit(int by) {
            _maxPopulation += by;
            ThePeople.OnPopulationStateChanged(EventArgs.Empty);
        }
    }
}
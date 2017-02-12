using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Buildings.Components;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// General class of buildings that transform resources into another ones
    /// </summary>
    public sealed class ProductionBuilding : Building, IResourceProduction {
        private IResourceProduction _resourceProduction;

        public void Awake() {
            gameObject.AddComponent<LocalStorage>();
            _resourceProduction = gameObject.AddComponent<ResourceProduction>();
        }

        public override void Start() {
            Size = BuildingSize.Big;
            base.Start();

            Produce();
        }

        public Dictionary<ResourceType, Resource> Stored {
            get { return _resourceProduction.Stored; }
        }

        public Dictionary<ResourceType, Resource> Capacity {
            get { return _resourceProduction.Capacity; }
        }

        public bool Add(Resource resource) {
            return _resourceProduction.Add(resource);
        }

        public bool Remove(Resource resource) {
            return _resourceProduction.Remove(resource);
        }

        public Resource FreeSpace(ResourceType resourceType) {
            return _resourceProduction.FreeSpace(resourceType);
        }

        public List<Resource> Prefabricates {
            get { return _resourceProduction.Prefabricates; }
        }

        public List<Resource> Products {
            get { return _resourceProduction.Products; }
        }

        public IEnumerator Produce() {
            return _resourceProduction.Produce();
        }

        public int ProductionCycleSeconds {
            get { return _resourceProduction.ProductionCycleSeconds; }
        }

        public bool IsProducing() {
            return _resourceProduction.IsProducing();
        }

        public bool IsEnoughResources() {
            return _resourceProduction.IsEnoughResources();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Buildings.Capabilities;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// General class of buildings that transform resources into another ones
    /// </summary>
    public class ProductionBuilding : Building, IResourceProduction {
        private readonly IResourceProduction _resourceProducer = new ResourceProducer();

        public override void Start() {
            Size = BuildingSize.Big;
            base.Start();
            //todo test if the Produce() will start when it's inside ResourceProducer's Start()
            //todo test what will happen if instead having _resourceProducer, there's gameObject.AddComponent<ResourceProducer> in Start, here or in ResourceProducer's Start()
            Produce();
        }

        public Dictionary<ResourceType, Resource> Stored {
            get { return _resourceProducer.Stored; }
        }

        public Dictionary<ResourceType, Resource> Capacity {
            get { return _resourceProducer.Capacity; }
        }

        public bool Add(Resource resource) {
            return _resourceProducer.Add(resource);
        }

        public bool Remove(Resource resource) {
            return _resourceProducer.Remove(resource);
        }

        public Resource FreeSpace(ResourceType resourceType) {
            return _resourceProducer.FreeSpace(resourceType);
        }

        public List<Resource> Prefabricates {
            get { return _resourceProducer.Prefabricates; }
        }

        public List<Resource> Products {
            get { return _resourceProducer.Products; }
        }

        public IEnumerator Produce() {
            return _resourceProducer.Produce();
        }

        public int ProductionCycleSeconds {
            get { return _resourceProducer.ProductionCycleSeconds; }
        }

        public bool IsProducing() {
            return _resourceProducer.IsProducing();
        }

        public bool IsEnoughResources() {
            return _resourceProducer.IsEnoughResources();
        }
    }
}
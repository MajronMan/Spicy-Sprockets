using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Res;
using UnityEngine;

namespace Assets.Scripts.Buildings.Components {
    /// <summary>
    /// Default implementation of IResourceProduction
    /// </summary>
    sealed class ResourceProducer : MonoBehaviour, IResourceProduction {
        private readonly IResourceStorage _resourceStorage = new LocalStorage();

        private bool _producing = false;
        private int _productionCycleSeconds = 30;

        public List<Resource> Prefabricates { get; private set; }

        public List<Resource> Products { get; private set; }

        public int ProductionCycleSeconds {
            get { return _productionCycleSeconds; }
            private set { _productionCycleSeconds = value; }
        }

        public IEnumerator Produce() {
            if (IsEnoughResources()) {
                _producing = true;
            }

            while (IsEnoughResources()) {
                Prefabricates.ForEach(p => Remove(p));
                yield return new WaitForSeconds(ProductionCycleSeconds);
                Products.ForEach(p => Add(p));
            }

            _producing = false;
        }

        public bool IsProducing() {
            return _producing;
        }

        public bool IsEnoughResources() {
            return Prefabricates.TrueForAll(p => Stored[p.Type] >= p);
        }


        public Dictionary<ResourceType, Resource> Stored {
            get { return _resourceStorage.Stored; }
        }

        public Dictionary<ResourceType, Resource> Capacity {
            get { return _resourceStorage.Capacity; }
        }

        public bool Add(Resource resource) {
            bool added = _resourceStorage.Add(resource);

            if (added) {
                StartCoroutine(Produce());
            }

            return added;
        }

        public bool Remove(Resource resource) {
            return _resourceStorage.Remove(resource);
        }

        public Resource FreeSpace(ResourceType resourceType) {
            return _resourceStorage.FreeSpace(resourceType);
        }
    }
}
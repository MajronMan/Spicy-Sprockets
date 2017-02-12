using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using UnityEngine;

namespace Assets.Scripts.Buildings.Components {
    /// <summary>
    /// Default implementation of IResourceProduction
    /// </summary>
    public sealed class ResourceProduction : MonoBehaviour, IResourceProduction {
        private IResourceStorage _resourceStorage;

        private bool _producing;

        public void Start() {
            _resourceStorage = gameObject.GetComponents<IResourceStorage>().First(c => !ReferenceEquals(c, this));

            //todo inject
            _producing = false;
            var types = Controllers.ConstantData.ResourceTypes;
            var coal = types.Find(t => t.Name == "coal");
            var stone = types.Find(t => t.Name == "stone");
            var metal = types.Find(t => t.Name == "metal");
            Prefabricates = new List<Resource> {
                new Resource(coal, 10),
                new Resource(stone, 10),
            };
            Products = new List<Resource> {
                new Resource(metal, 5),
            };
            ProductionCycleSeconds = 2;
        }

        public List<Resource> Prefabricates { get; private set; }

        public List<Resource> Products { get; private set; }

        public int ProductionCycleSeconds { get; private set; }

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
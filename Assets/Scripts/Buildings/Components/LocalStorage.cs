using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using UnityEngine;

namespace Assets.Scripts.Buildings.Components {
    /// <summary>
    /// Default implementation of IResourceStorage
    /// </summary>
    public sealed class LocalStorage : MonoBehaviour, IResourceStorage {
        public Dictionary<ResourceType, Resource> Stored { get; private set; }
        public Dictionary<ResourceType, Resource> Capacity { get; private set; }

        public void Start() {
            //todo inject those
            Capacity = new Dictionary<ResourceType, Resource>();
            Controllers.ConstantData.ResourceTypes.ForEach(t => Capacity[t] = new Resource(t, 100));
            Stored = new Dictionary<ResourceType, Resource>();
            Controllers.ConstantData.ResourceTypes.ForEach(t => Stored[t] = new Resource(t, 0));
        }

        public bool Add(Resource resource) {
            ResourceType type = resource.Type;

            if (!Capacity.ContainsKey(type) || FreeSpace(type) < resource) {
                return false;
            }

            Stored[type] += resource;
            return true;
        }

        public bool Remove(Resource resource) {
            ResourceType type = resource.Type;

            if (!Capacity.ContainsKey(type) || Stored[type] < resource) {
                return false;
            }

            Stored[type] -= resource;
            return true;
        }

        public Resource FreeSpace(ResourceType resourceType) {
            if (!Capacity.ContainsKey(resourceType) || !Stored.ContainsKey(resourceType)) {
                return new Resource(resourceType, 0);
            }

            return Capacity[resourceType] - Stored[resourceType];
        }
    }
}
using System.Collections.Generic;
using Assets.Scripts.Buildings.Capabilities;
using Assets.Scripts.Res;

namespace Assets.Scripts.Buildings {
    public class ResourceStorage : IResourceStorage {
        public Dictionary<ResourceType, Resource> Stored { get; private set; }
        public Dictionary<ResourceType, Resource> Capacity { get; private set; }

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
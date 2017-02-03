using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// A building which stores collected resources and increases storage limit
    /// </summary>
    public class StorageBuilding : Building, IResourceStorage {
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

        public override void Start() {
            Size = BuildingSize.Small;
            base.Start();
            //increase the storage limit
            Controllers.CurrentInfo.ChangeStorageLimit(100);
        }
    }
}
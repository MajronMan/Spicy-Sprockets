using System.Collections.Generic;
using Assets.Scripts.Buildings.Capabilities;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// A building which stores collected resources and increases storage limit
    /// </summary>
    public class StorageBuilding : Building, IResourceStorage {
        private readonly IResourceStorage _resourceStorage = new ResourceStorage();

        public Dictionary<ResourceType, Resource> Stored {
            get { return _resourceStorage.Stored; }
        }

        public Dictionary<ResourceType, Resource> Capacity {
            get { return _resourceStorage.Capacity; }
        }

        public bool Add(Resource resource) {
            return _resourceStorage.Add(resource);
        }

        public bool Remove(Resource resource) {
            return _resourceStorage.Remove(resource);
        }

        public Resource FreeSpace(ResourceType resourceType) {
            return _resourceStorage.FreeSpace(resourceType);
        }

        public override void Start() {
            Size = BuildingSize.Small;
            base.Start();
            //increase the storage limit
            Controllers.CurrentInfo.ChangeStorageLimit(100);
        }
    }
}
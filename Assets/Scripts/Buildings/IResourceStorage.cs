using System.Collections.Generic;
using Assets.Scripts.Res;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// Represents the ability to store resources
    /// </summary>
    interface IResourceStorage {
        Dictionary<ResourceType, Resource> Stored { get; }
    }
}
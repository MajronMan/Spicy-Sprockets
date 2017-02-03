using System.Collections.Generic;
using Assets.Scripts.Res;

namespace Assets.Scripts.Buildings.Capabilities {
    /// <summary>
    /// Represents the capability to store resources.
    /// To keep storage state consistent, adding and removing resources
    /// should be performed using provided interface functions.
    /// </summary>
    interface IResourceStorage {
        /// <summary>
        /// Resources currently stored in this object
        /// </summary>
        Dictionary<ResourceType, Resource> Stored { get; }

        /// <summary>
        /// Maximum storage capacity for each resource
        /// </summary>
        Dictionary<ResourceType, Resource> Capacity { get; }

        /// <summary>
        /// Add resource to storage if there is enough space, otherwise do nothing
        /// </summary>
        /// <param name="resource">resource to add</param>
        /// <returns>True if there's enough free place inside, false otherwise</returns>
        bool Add(Resource resource);

        /// <summary>
        /// Remove resource from storage if there is enough inside, otherwise do nothing
        /// </summary>
        /// <param name="resource">Resource to remove</param>
        /// <returns>True if there's enough of resource inside, false otherwise</returns>
        bool Remove(Resource resource);

        /// <summary>
        /// Free space left for a given resource
        /// </summary>
        /// <param name="resourceType">ResourceType to find free space for</param>
        /// <returns>Space left for a given resource</returns>
        Resource FreeSpace(ResourceType resourceType);
    }
}
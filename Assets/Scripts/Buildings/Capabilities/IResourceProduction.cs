﻿using System.Collections.Generic;
using Assets.Scripts.Res;

namespace Assets.Scripts.Buildings.Capabilities {
    /// <summary>
    /// Represents the capabililty to produce resources,
    /// i.e. transform one set of resources into antoher
    /// </summary>
    interface IResourceProduction : IResourceStorage {
        /// <summary>
        /// Resources consumed in one production cycle
        /// </summary>
        List<Resource> Prefabricates { get; }

        /// <summary>
        /// Resources produced in one production cycle
        /// </summary>
        List<Resource> Products { get; }

        /// <summary>
        /// Production cycle length in seconds
        /// </summary>
        int ProductionCycleSeconds { get; } // 30

        /// <summary>
        /// Indicates whether this object is during the production cycle
        /// </summary>
        bool IsProducing();

        /// <summary>
        /// Indicates whether this object has enough resources inside to start another production cycle
        /// </summary>
        bool IsEnoughResources();
    }
}
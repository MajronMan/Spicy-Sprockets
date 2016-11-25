using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.ResourcePools;
using UnityEngine;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// General class of buildings that gather resources from environment like coal, wood etc.
    /// </summary>
    [System.Serializable]
    public abstract class GatheringBuilding : Building {
        /// <summary>
        /// Actual resource gathered by this building
        /// </summary>
        public string GatheredResource;

        /// <summary>
        /// Sources from which the resource is gathered
        /// </summary>
        public List<ResourcePool> Sources = new List<ResourcePool>();

        /// <summary>
        /// How far sources may be to be reachable
        /// </summary>
        public float Radius;

        public override void Start() {
            base.Start();
            //Iterate through all sources in game
            foreach (var source in Controllers.CurrentCityController.MapInstance.Sources) {
                // check if the source is in range and yields proper resource
                if (Vector3.Distance(source.transform.position, transform.position) < Radius &&
                    source.Type == GatheredResource) {
                    // if so, remember it
                    Sources.Add(source);
                }
            }
            // don't gather if there are no nearby sources
            if (Sources.Count > 0)
                StartCoroutine("Gather");
        }

        public IEnumerator Gather() {
            while (true) {
                //For each source that is in range, get amount=magnitude/distance of resource
                Controllers.CurrentInfo[GatheredResource] += (int)
                (from source in Sources
                    let distance = Vector3.Distance(source.gameObject.transform.position,
                        gameObject.transform.position)
                    select source.Magnitude / distance).Sum();
                //wait for next turn of gathering
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}
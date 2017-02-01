using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.ResourcePools;
using Assets.Scripts.Utils;
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
        public ResourceType GatheredResource;

        /// <summary>
        /// Pools from which the resource is gathered
        /// </summary>
        public List<ResourcePool> Sources = new List<ResourcePool>();

        /// <summary>
        /// How far pools may be to be reachable
        /// </summary>
        public float Radius;

        /// <summary>
        /// The list of employees this building has
        /// </summary>
        public int CurrentStaff;

        /// <summary>
        /// The maximum of employees this building can hold
        /// </summary>
        public int MaxStaff;

        /// <summary>
        /// Minimum staff, required to keep building working
        /// </summary>
        public int MinStaff;

        //I need it to check if gather is working
        private bool _gatherRunning = false;
        //maybe someone will change it later, for now I think it looks pretty
        private BuildingPanel _panel;

        public override void Start() {
            base.Start();
            //Iterate through all resource pools in game
            foreach (var pool in Controllers.CurrentCityController.MapInstance.Pools) {
                // check if the source is in range and yields proper resource
                if (Vector3.Distance(pool.transform.position, transform.position) < pool.Radius &&
                    pool.Resource == GatheredResource) {
                    // if so, remember it
                    Sources.Add(pool);
                }
            }
            //employing staff
            if (Controllers.CurrentInfo.ThePeople.CheckPossibleEmployment(MinStaff)) {
                Controllers.CurrentInfo.ThePeople.Employ(MinStaff);
                CurrentStaff = MinStaff;
            }

            // checking preconditions for starting gathering
            if (Sources.Count > 0 && CurrentStaff >= MinStaff) {
                StartCoroutine(Gather());
                _gatherRunning = true;
            }
        }

        //will gather only if manned
        public void Update() {
            if (CurrentStaff < MinStaff) {
                StopCoroutine(Gather());
                _gatherRunning = false;
            }
            if (!_gatherRunning)
                if (CurrentStaff >= MinStaff) {
                    StartCoroutine(Gather());
                    _gatherRunning = true;
                }
        }

        //used to hire and fire
        public void ManageStaff(int newStaff) {
            if (newStaff <= MaxStaff) {
                if (newStaff < CurrentStaff) {
                    Controllers.CurrentInfo.ThePeople.Fire(CurrentStaff - newStaff);
                    CurrentStaff = newStaff;
                } else {
                    Controllers.CurrentInfo.ThePeople.Employ(newStaff - CurrentStaff);
                    CurrentStaff = newStaff;
                }
            }
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
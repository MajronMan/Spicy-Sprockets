using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Resources;
using Assets.Scripts.Sources_of_Resources;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    /// <summary>
    /// General class of buildings that gather resources from environment like coal, wood etc.
    /// </summary>
    [System.Serializable]
    public abstract class GatheringBuilding : Building
    {
        /// <summary>
        /// Actual resource gathered by this building
        /// </summary>
        public string GatheredResource;
        /// <summary>
        /// Sources from which the resource is gathered
        /// </summary>
        public List<Source> Sources= new List<Source>();
        /// <summary>
        /// How far sources may be to be reachable
        /// </summary>
        public float Radius;
        /// <summary>
        /// The list of employees this building has
        /// </summary>
        public int CurrentStaff;
        /// <summary>
        /// The maximum of emplyees this building can hold
        /// </summary>
        public int MaxStaff;
        /// <summary>
        /// Minimum staff, required to keep building working
        /// </summary>
        public int MinStaff;
        private Population ThePeople;
        //I need it to check if gather is working
        private bool GatherRunning = false;
        //maybe someone will change it later, for now I think it looks pretty
        private BuildingPanel panel;

        public override void Start()
        {
            base.Start();
            //Iterate through all sources in game
            foreach (var source in Controllers.CurrentCityController.MapInstance.Sources)     
            {
                // check if the source is in range and yields proper resource
                if (Vector3.Distance(source.transform.position, transform.position) < Radius && source.MyResource == GatheredResource)
                {
                    // if so, remember it
                    Sources.Add(source);
                }
            }
            //employing staff
            ThePeople = Controllers.CurrentInfo.ThePeople;
            if(Controllers.CurrentInfo.ThePeople.CheckPossibleEmployment(MinStaff))
            {
                Controllers.CurrentInfo.ThePeople.Employ(MinStaff);
                CurrentStaff = MinStaff;
            }

            // don't gather if there are no nearby sources
            if (Sources.Count > 0 && CurrentStaff>=MinStaff)
            {
                StartCoroutine("Gather");
                GatherRunning = true;
            }
        }

        //will gather only if manned
        public void Update()
        {
            if (CurrentStaff < MinStaff)
            {
                StopCoroutine("Gather");
                GatherRunning = false;
            }
            if(!GatherRunning)
                if (CurrentStaff >= MinStaff)
                {
                    StartCoroutine("Gather");
                    GatherRunning = true;
                }
        }

        //used to hire and fire
        public void ManageStaff(int newStaff)
        {
            if (newStaff <= MaxStaff)
            {
                if(newStaff < CurrentStaff)
                {
                    Controllers.CurrentInfo.ThePeople.Fire(CurrentStaff - newStaff);
                    CurrentStaff = newStaff;
                }
                else
                {
                    Controllers.CurrentInfo.ThePeople.Employ(newStaff - CurrentStaff);
                    CurrentStaff = newStaff;
                }
            }

        }

        public IEnumerator Gather()
        {
            while (true)
            {
                //For each source that is in range, get amount=magnitude/distance of resource
                Controllers.CurrentInfo[GatheredResource] += (int) 
                    (from source in Sources let distance = Vector3.Distance(source.gameObject.transform.position, 
                    gameObject.transform.position) select source.Magnitude/distance).Sum();
                //wait for next turn of gathering
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}

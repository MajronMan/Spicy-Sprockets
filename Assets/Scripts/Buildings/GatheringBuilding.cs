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
    [System.Serializable]
    public abstract class GatheringBuilding : Building
    {
        public string GatheredResource;
        public List<Source> Sources= new List<Source>();
        public float Radius;

        public override void Start()
        {
            base.Start();
   
            foreach (var source in Controllers.CurrentCityController.Sources)
            {
                if (Vector3.Distance(source.transform.position, transform.position) < Radius && source.MyResource == GatheredResource)
                {
                    Sources.Add(source);
                }
            }
            if(Sources.Count > 0)
                StartCoroutine("Gather");
        }

        public IEnumerator Gather()
        {
            while (true)
            {
                //makes me look like a true hax0r
                Controllers.CurrentInfo[GatheredResource] += (int) 
                    (from source in Sources let distance = Vector3.Distance(source.gameObject.transform.position, 
                    gameObject.transform.position) select source.Magnitude/distance).Sum();
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}

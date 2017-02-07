using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Science;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Game_Controllers {

    public class ScienceController : MonoBehaviour {

        public List<ScienceBranch> Branches = new List<ScienceBranch>();
        public int SciencePoints;
       
        public void Awake() {
            foreach (var s in Enum.GetValues(typeof(ScienceBranches)))
            {
                var branch = Util.NewMonoBehaviour<ScienceBranch>(s.ToString());
                Branches.Insert((int) s, branch);
                branch.transform.SetParent(transform);
            }
        }
    }
}

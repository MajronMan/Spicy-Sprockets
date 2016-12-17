using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Game_Controllers {

    public class ScienceController : MonoBehaviour {

        public Dictionary<string, ScienceBranch> Branches = new Dictionary<string, ScienceBranch>();

        public void Start() {
            //load Branches
        }
    }
}

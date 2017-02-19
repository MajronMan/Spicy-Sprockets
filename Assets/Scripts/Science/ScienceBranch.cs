using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Science {

    public class ScienceBranch: MonoBehaviour
    {
        private bool _financed;
        public List<ScienceArea> Areas = new List<ScienceArea>();

        public void Start() {
            //load Areas
        }

        public void setFinanced(bool value)
        {
            _financed = value;
            Debug.Log(name + ": " + _financed);
            foreach (var scienceArea in Areas)
            {
                scienceArea.Financing = _financed? 100:0;
            }
        }
    }
}

using System.Collections;
using Assets.Scripts.Game_Controllers;
using UnityEngine;

namespace Assets.Scripts.Science {

    public class ScienceArea : MonoBehaviour {
        public int Scientists;
        public int Financing;
        public int TimeFromLastDiscover;
        public int DiscoverDifficulty;
        public int WorkingPeriod;
        private ScienceArea _parent;
        private ScienceBranch _branch;
        
        public void Start() {

            StartCoroutine(Work());
        }

        private IEnumerator Work()
        {
            while (true)
            {
                TimeFromLastDiscover++;
                Controllers.CurrentInfo.MyMoney -= Financing;

                if (Chance() > new System.Random().NextDouble())
                {
                    //discover sth
                    TimeFromLastDiscover = 0;

                }
                yield return new WaitForSeconds(WorkingPeriod);
            }
        }

        private double Chance ()
        {
            return (double)(100 * Scientists + 10 * Financing + TimeFromLastDiscover) / (double)DiscoverDifficulty; //random factors
        }

    }
}

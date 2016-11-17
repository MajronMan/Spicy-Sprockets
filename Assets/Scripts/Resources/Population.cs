using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using UnityEngine;

namespace Assets.Scripts.Resources
{
    /// <summary>
    /// People living in a certain city
    /// </summary>
    public class Population : MonoBehaviour {
        public int Number = 100;
        //There is no actual class Statistics, so I'm making a mock for real employment check
        public int employed = 0;
        // Those are just stubs for actual statistics
        public float Hygiene = 0.1f;
        public Dictionary<string, float> Religions = new Dictionary<string, float>();
        public Dictionary<string, float> Cultures = new Dictionary<string, float>();
        public Dictionary<string, float> Education = new Dictionary<string, float>();
        public int[] Age = new int[100];
        //TODO: class Statistic working like a Dictionary<string, float> which values add up to 1.0f (100%)

        public void Start(){
            StartCoroutine ("Grow");
            Religions.Add ("Hinduism", 1.0f);
            Cultures.Add ("Hindu", 1.0f);
        }

        /// <summary>
        /// Increase the population in a regular manner
        /// </summary>
        public IEnumerator Grow(){
            while (true)
            {
                var growing = Number/20;
                var space = Controllers.CurrentInfo.GetPopulationLimit() - Number;
                if (space > growing)
                    Number += growing;
                else
                    Number += space;
                yield return new WaitForSeconds(1);
            }
        }

        public void Employ(int workers)
        {
            employed += workers;
        }

        //returns true if there are enough workers for basic tasks
        public bool CheckEmployment(int potentialWorkers)
        {
            if (employed + potentialWorkers > Number)
                return false;
            return true;
        }
    }
}

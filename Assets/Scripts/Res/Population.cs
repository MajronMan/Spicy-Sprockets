using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using UnityEngine;

namespace Assets.Scripts.Res {
    /// <summary>
    /// People living in a certain city
    /// </summary>
    public class Population : MonoBehaviour, ICountable {
        public int Amount {
            get { return _number; }
        }

        private int _number = 100;
        // Those are just stubs for actual statistics
        public float Hygiene = 0.1f;
        public Dictionary<string, float> Religions = new Dictionary<string, float>();
        public Dictionary<string, float> Cultures = new Dictionary<string, float>();
        public Dictionary<string, float> Education = new Dictionary<string, float>();
        public int[] Age = new int[100];
        //TODO: class Statistic working like a Dictionary<string, float> which values add up to 1.0f (100%)

        public void Start() {
            StartCoroutine("Grow");
            Religions.Add("Hinduism", 1.0f);
            Cultures.Add("Hindu", 1.0f);
        }

        /// <summary>
        /// Increase the population in a regular manner
        /// </summary>
        public IEnumerator Grow() {
            while (true) {
                var growing = _number / 20;
                var space = Controllers.CurrentInfo.GetPopulationLimit() - _number;
                if (space > growing)
                    _number += growing;
                else
                    _number += space;
                yield return new WaitForSeconds(1);
            }
        }
    }
}
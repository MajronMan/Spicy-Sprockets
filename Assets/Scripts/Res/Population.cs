using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using UnityEngine;

namespace Assets.Scripts.Res {
    public delegate void PopulationStateChangedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// People living in a certain city
    /// </summary>
    public class Population : MonoBehaviour, ICountable {
        public int Amount {
            get { return _number; }
            private set { _number = value; }
        }

        public event PopulationStateChangedEventHandler Changed;

        private int _number = 100;

        //There is no actual class Statistics, so I'm making a mock for real employment check
        private int _employed = 0;

        // Those are just stubs for actual statistics
        public float Hygiene = 0.1f;
        public Dictionary<string, float> Religions = new Dictionary<string, float>();
        public Dictionary<string, float> Cultures = new Dictionary<string, float>();
        public Dictionary<string, float> Education = new Dictionary<string, float>();
        public int[] Age = new int[100];
        //TODO: class Statistic working like a Dictionary<string, float> which values add up to 1.0f (100%)

        public void Start() {
            StartCoroutine(Grow());
            Religions.Add("Hinduism", 1.0f);
            Cultures.Add("Hindu", 1.0f);
        }

        public virtual void OnPopulationStateChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        /// <summary>
        /// Increase the population in a regular manner
        /// </summary>
        public IEnumerator Grow() {
            while (true) {
                var growing = Amount / 20;
                var space = Controllers.CurrentInfo.GetPopulationLimit() - Amount;
                if (space > growing)
                    Amount += growing;
                else
                    Amount += space;
                OnPopulationStateChanged(EventArgs.Empty);
                yield return new WaitForSeconds(1);
            }
        }

        public void Employ(int workers) {
            if (_employed + workers <= Amount)
                _employed += workers;
        }

        public void Fire(int workers) {
            if (_employed >= workers)
                _employed -= workers;
        }

        //returns true if there are enough workers for basic tasks
        public bool CheckPossibleEmployment(int potentialWorkers) {
            if (_employed + potentialWorkers > Amount)
                return false;
            return true;
        }

        public int CheckEmployment() {
            return _employed;
        }
    }
}
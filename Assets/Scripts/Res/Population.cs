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
        public int Employed { get; private set; }

        // Those are just stubs for actual statistics
        public float Hygiene = 0.1f;
        public Dictionary<string, float> Religions = new Dictionary<string, float>();
        public Dictionary<string, float> Cultures = new Dictionary<string, float>();
        public Dictionary<string, float> Education = new Dictionary<string, float>();
        public int[] Age = new int[100];
        //TODO: class Statistic working like a Dictionary<string, float> which values add up to 1.0f (100%)

        public void Start() {
            Employed = 0;
            StartCoroutine(Grow());
            Religions.Add("Hinduism", 1.0f);
            Cultures.Add("Hindu", 1.0f);
        }

        public virtual void OnPopulationStateChanged(EventArgs e) {
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

        public bool Employ(int employees) {
            if (!CanEmploy(employees)) return false;
            Employed += employees;
            return true;
        }

        //returns true if there are enough employees for basic tasks
        public bool CanEmploy(int potentialEmployees) {
            var afterEmployed = Employed + potentialEmployees;
            return (0 <= afterEmployed
                    && afterEmployed <= Amount);
        }
    }
}
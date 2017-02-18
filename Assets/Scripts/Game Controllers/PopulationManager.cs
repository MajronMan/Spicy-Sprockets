using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Res;
using UnityEngine;

namespace Assets.Scripts.Game_Controllers
{
    public delegate void PopulationStateChangedEventHandler(object sender, EventArgs e);
    public class PopulationManager: MonoBehaviour
    {
        public event PopulationStateChangedEventHandler Changed;
        public virtual void OnPopulationStateChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }
        private Population _population = new Population();

        public int Amount {get { return _population.Amount; }}

        //There is no actual class Statistics, so I'm making a mock for real employment check
        public int Employed = 0;

        // Those are just stubs for actual statistics
        public float Hygiene = 0.1f;
        public Dictionary<string, float> Religions = new Dictionary<string, float>();
        public Dictionary<string, float> Cultures = new Dictionary<string, float>();
        public Dictionary<string, float> Education = new Dictionary<string, float>();
        public int[] Age = new int[100];
        //TODO: class Statistic working like a Dictionary<string, float> which values add up to 1.0f (100%)


        public void Start()
        {
            StartCoroutine(Grow());
            Religions.Add("Hinduism", 1.0f);
            Cultures.Add("Hindu", 1.0f);
        }

        /// <summary>
        /// Increase the population in a regular manner
        /// </summary>
        public IEnumerator Grow()
        {
            while (true)
            {
                var growing = Amount / 20;
                var space = Controllers.CurrentInfo.GetPopulationLimit() - Amount;
                var change = space < growing ? space : growing;
                
                _population.Add(change);
                OnPopulationStateChanged(EventArgs.Empty);

                yield return new WaitForSeconds(1);
            }
        }

        public void Employ(int workers)
        {
            if (Employed + workers <= Amount)
                Employed += workers;
        }

        public void Fire(int workers)
        {
            if (Employed >= workers)
                Employed -= workers;
        }

        //returns true if there are enough workers for basic tasks
        public bool CheckPossibleEmployment(int potentialWorkers)
        {
            return Employed + potentialWorkers <= Amount;
        }

        public int CheckEmployment()
        {
            return Employed;
        }
    }
}

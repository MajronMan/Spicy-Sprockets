using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    /// <summary>
    /// Dictionary(string,float) with values sumed up to 1
    /// </summary>
    public class Statistics
    {
        private Dictionary<string, float> statisticsData = new Dictionary<string, float>();

        /// <summary>
        /// constructor changing Dinctionary into Statistics
        /// </summary>
        /// <param name="data"></param>
        Statistics(Dictionary<string,float> data)
        {
            statisticsData = data;
            Standarize();
        }
        /// <summary>
        /// Ensure that values sum up to 1
        /// </summary>
        private void Standarize()
        {
            float sum = 0;
            foreach (KeyValuePair<string, float> el in statisticsData)
                sum += el.Value;

            foreach (KeyValuePair<string, float> el in statisticsData)
                statisticsData[el.Key] = el.Value * 100 / sum;
        }
        /// <summary>
        /// Add new key to statistics
        /// </summary>
        /// <param name="key">new key name</param>
        /// <param name="part">final part represented by new key</param>
        public void Add (string key, float part)
        {
            if (statisticsData.Count == 0)
                part = 1;

            foreach (KeyValuePair<string, float> el in statisticsData)
                statisticsData[el.Key] = el.Value * (100- part) / 100;

            statisticsData.Add(key, part);
            Standarize();
        }
        /// <summary>
        /// Remove key from statistics
        /// </summary>
        /// <param name="key">key to be removed</param>
        public void Remove (string key)
        {
            statisticsData.Remove(key);
            Standarize();
        }
        /// <summary>
        /// Change part of some key into other
        /// </summary>
        /// <param name="key1">key to decrese (existing)</param>
        /// <param name="key2">key to increase</param>
        /// <param name="value">procentage points to be moved</param>
        public void Change(string key1, string key2, float value) 
        {
            if (statisticsData.ContainsKey(key1))
            {
                if(! statisticsData.ContainsKey(key2))
                    statisticsData.Add(key2, 0);

                if (statisticsData[key1] > value)
                {
                    statisticsData[key2] += value;
                    statisticsData[key1] -= value;
                }
                else
                {
                    statisticsData[key2] += statisticsData[key1];
                    statisticsData[key1] = 0;
                }
            }

        }
        /// <summary>
        /// Multiply the amount of stuff represented by the key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="factor">the multiplication factor</param>
        public void Multiply (string key, float factor)
        {
            if (statisticsData.ContainsKey(key))
            {
                statisticsData[key] *= factor;
                Standarize();
            }
        }

        public float this[string key]
        {
            get { return statisticsData[key]; }
        }

    }
}

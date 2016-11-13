using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    public class Statistic
    {
        private Dictionary<string, float> statisticData = new Dictionary<string, float>();

        Statistic(Dictionary<string,float> data)
        {
            statisticData = data;
            Standarize();
        }

        private void Standarize()
        {
            float sum = 0;
            foreach (KeyValuePair<string, float> el in statisticData)
                sum += el.Value;

            foreach (KeyValuePair<string, float> el in statisticData)
                statisticData[el.Key] = el.Value * 100 / sum;
        }

        public void Add (string key, float part) //final part represented by new key
        {
            if (statisticData.Count == 0)
                part = 1;

            foreach (KeyValuePair<string, float> el in statisticData)
                statisticData[el.Key] = el.Value * (100- part) / 100;

            statisticData.Add(key, part);
            Standarize();
        }

        public void Remove (string key)
        {
            statisticData.Remove(key);
            Standarize();
        }

        public void Change(string key1, string key2, float value) //when a part of some type changes into the other
        {
            if (statisticData.ContainsKey(key1) && statisticData.ContainsKey(key2))
            {
                statisticData[key1] -= value;
                statisticData[key2] += value;
            }

        }

        public void Multiply (string key, float factor) // when multiplies the amount of one type of stuff
        {
            if (statisticData.ContainsKey(key))
            {
                statisticData[key] *= factor;
                Standarize();
            }
        }

        public float this[string key]
        {
            get { return statisticData[key]; }
        }

    }
}

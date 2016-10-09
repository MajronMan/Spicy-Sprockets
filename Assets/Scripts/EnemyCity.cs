using System.Collections.Generic;
using Assets.Scripts.Buildings;
using Assets.Scripts.Resources;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyCity : MonoBehaviour {
        public Dictionary<string, Resource> Resources;
        public Dictionary<string, Resource> Needs;
        public int Wealth;
        public List<Building> Buildings;
        //This is just a stub
    }
}

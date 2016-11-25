using System.Collections.Generic;
using Assets.Scripts.Buildings;
using Assets.Scripts.Res;
using UnityEngine;

namespace Assets.Scripts {
    public class EnemyCity : MonoBehaviour {
        public Dictionary<ResourceType, Resource> Resources;
        public HashSet<ResourceType> Needs;
        public int Wealth;
        public List<Building> Buildings;
        //This is just a stub
    }
}
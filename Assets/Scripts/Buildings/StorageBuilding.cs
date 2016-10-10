using System.Collections.Generic;
using Assets.Scripts.Resources;
using Assets.Scripts.Utils;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public  class StorageBuilding : Building
    {
        public Dictionary<string, Resource> Storage;

        public override void Start()
        {
            MySize = BuildingSize.Small;
            base.Start();
        }
    }
}

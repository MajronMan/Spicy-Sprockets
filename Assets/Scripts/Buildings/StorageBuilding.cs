using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Resources;
using Assets.Scripts.Utils;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    /// <summary>
    /// A building which stores collected resources and increases storage limit
    /// </summary>
    public  class StorageBuilding : Building
    {
        /// <summary>
        /// Dictionary holding resources present in the storage
        /// </summary>
        public Dictionary<string, Resource> Storage;

        public override void Start()
        {
            MySize = BuildingSize.Small;
            base.Start();
            //increase the storage limit
            Controllers.CurrentInfo.ChangeStorageLimit(100);
        }
    }
}

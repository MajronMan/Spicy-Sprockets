using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// A building which stores collected resources and increases storage limit
    /// </summary>
    public class StorageBuilding : Building {
        /// <summary>
        /// Dictionary holding resources present in the storage
        /// </summary>
        public Dictionary<ResourceType, Commodity> Storage;

        public override void Start() {
            Size = BuildingSize.Small;
            base.Start();
            //increase the storage limit
            Controllers.CurrentInfo.ChangeStorageLimit(100);
        }
    }
}
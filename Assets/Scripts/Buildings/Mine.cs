using Assets.Scripts.Sources_of_Resources;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    /// <summary>
    /// Traditional silesian restaurant
    /// </summary>
    public class Mine : GatheringBuilding
    {
        public override void Start()
        {
            Radius = 1000;
            GatheredResource = "coal";
            MySize = BuildingSize.Big;
            base.Start();
        }
    }
}

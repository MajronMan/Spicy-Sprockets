using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// Traditional silesian restaurant
    /// </summary>
    public class Mine : GatheringBuilding {
        public override void Start() {
            Radius = 1000;

            GatheredResource = Controllers.ConstantData.ResourceTypes.Find((type => type.Name == "coal"));
            Size = BuildingSize.Big;
            MaxStaff = 50;
            MinStaff = 10;
            base.Start();
        }
    }
}
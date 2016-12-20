using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    public class Quarry : GatheringBuilding {
        public override void Start() {
            Radius = 1000;
            GatheredResource = Controllers.ConstantData.ResourceTypes.Find((type => type.Name == "stone"));
            Size = BuildingSize.Big;
            base.Start();
        }
    }
}
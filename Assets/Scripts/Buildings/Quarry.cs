using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    public class Quarry : GatheringBuilding {
        public override void Start() {
            Radius = 1000;
            GatheredResource = "stone";
            MySize = BuildingSize.Big;
            base.Start();
        }
    }
}
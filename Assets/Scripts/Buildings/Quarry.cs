using Assets.Scripts.Res;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    public class Quarry : GatheringBuilding {
        public override void Start() {
            Radius = 1000;
            GatheredResource = new ResourceType("temporary_solution", 1, 2, 3); //"stone";
            MySize = BuildingSize.Big;
            base.Start();
        }
    }
}
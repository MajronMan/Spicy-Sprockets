using Assets.Scripts.Res;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// Traditional silesian restaurant
    /// </summary>
    public class Mine : GatheringBuilding {
        public override void Start() {
            Radius = 1000;
            GatheredResource = new ResourceType("temporary_solution", 1, 2, 3); //"coal";
            MySize = BuildingSize.Big;
            base.Start();
        }
    }
}
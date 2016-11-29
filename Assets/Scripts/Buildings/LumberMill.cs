using Assets.Scripts.Res;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// Building that gathers wood
    /// </summary>
    public class LumberMill : GatheringBuilding {
        public override void Start() {
            Radius = 1000;
            GatheredResource = new ResourceType("temporary_solution", 1, 2, 3); //wood
            MySize = BuildingSize.Big;
            base.Start();
        }
    }
}
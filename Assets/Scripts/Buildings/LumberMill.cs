using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// Building that gathers wood
    /// </summary>
    public class LumberMill : GatheringBuilding {
        public override void Start() {
            Radius = 1000;
            GatheredResource = "wood";
            MySize = BuildingSize.Big;
            base.Start();
        }
    }
}
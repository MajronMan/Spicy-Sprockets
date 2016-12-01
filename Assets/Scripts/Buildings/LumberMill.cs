using Assets.Scripts.Res;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// Building that gathers wood
    /// </summary>
    public class LumberMill : GatheringBuilding {
        public override void Start() {
            GatheredResource = new ResourceType("temporary_solution", 1, 2, 3); //wood
            Size = BuildingSize.Big;
            base.Start();
        }
    }
}
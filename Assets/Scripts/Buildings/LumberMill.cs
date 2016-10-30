using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings
{
    public class LumberMill: GatheringBuilding
    {
        public override void Start()
        {
            GatheredResource = "wood";
            MySize = BuildingSize.Big;
            base.Start();
        }
    }
}

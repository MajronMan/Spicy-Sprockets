using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings
{
    /// <summary>
    /// Building that gathers wood
    /// </summary>
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

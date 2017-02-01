using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// Building that gathers wood
    /// </summary>
    public class LumberMill : GatheringBuilding {
        public override void Start()
        {
            GatheredResource = Controllers.ConstantData.ResourceTypes.Find((type => type.Name == "wood"));
            Size = BuildingSize.Big;
            base.Start();
        }
    }
}
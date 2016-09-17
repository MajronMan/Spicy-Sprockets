using Assets.Scripts.Resources;

namespace Assets.Scripts.Buildings
{
    [System.Serializable]
    public abstract class GatheringBuilding : Building
    {
        public float GatheringRadius;
        public Resource Resource;
    }
}

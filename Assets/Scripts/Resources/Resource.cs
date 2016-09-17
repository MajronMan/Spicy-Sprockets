using UnityEngine;

namespace Assets.Scripts.Resources
{
    [System.Serializable]
    public class Resource : MonoBehaviour
    {
        protected int MassPerUnit;
        protected int VolumePerUnit;
        protected int DefaultCostPerUnit;
        protected int Quantity;
        protected ResourceQuality Quality;
    
    
        public Resource(ResourceType.Type type, int quantity, ResourceQuality quality)
        {
            LoadProperties(type);
            this.Quantity = quantity;
            this.Quality = quality;
        }
    
        public ResourceQuality GetQuality()
        {
            return Quality;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        private void LoadProperties(ResourceType.Type type)
        {
            switch (type)
            {
                case ResourceType.Type.Coal:
                    MassPerUnit = ResourceType.Coal.MassPerUnit;
                    VolumePerUnit = ResourceType.Coal.VolumePerUnit;
                    DefaultCostPerUnit = ResourceType.Coal.DefaultCostPerUnit;
                    name = ResourceType.Coal.Name;
                    break;
                default:
                    MassPerUnit = 2137;
                    VolumePerUnit = 410;
                    DefaultCostPerUnit = 15;
                    name = "yomama";
                    break;

            }
        }
    }
}

namespace Assets.Scripts.Resources
{
    [System.Serializable]
    public class Resource
    {
		private string type;
        private int massPerUnit;
		private int volumePerUnit;
        private int defaultPricePerUnit;

        private int quantity;
        private ResourceQuality quality;
    
    
        public Resource(int quantity, ResourceQuality quality)
        {
            this.quantity = quantity;
            this.quality = quality;
        }
    
        public ResourceQuality GetQuality()
        {
            return quality;
        }

        public int GetQuantity()
        {
            return quantity;
        }
    
        public static Resource operator +(Resource basicRes, int addedQuantity)
        {
            basicRes.quantity += addedQuantity;
            return basicRes;
        }

        public static Resource operator -(Resource basicRes, int subtractedQuantity)
        {
            basicRes.quantity -= subtractedQuantity;
            return basicRes;
        }

        public static Resource operator ++(Resource basicRes)
        {
            basicRes.quantity++;
            return basicRes;
        }

        public static Resource operator --(Resource basicRes)
        {
            basicRes.quantity--;
            return basicRes;
        }

//        private void LoadProperties(ResourceType.Type type)
//        {
//            switch (type)
//            {
//                case ResourceType.Type.Coal:
//                    massPerUnit = ResourceType.Coal.MassPerUnit;
//                    volumePerUnit = ResourceType.Coal.VolumePerUnit;
//                    defaultCostPerUnit = ResourceType.Coal.DefaultCostPerUnit;
//                    name = ResourceType.Coal.Name;
//                    break;
//                case ResourceType.Type.Food:
//                    break;
//                case ResourceType.Type.Metal:
//                    break;
//                case ResourceType.Type.Wood:
//                    break;
//                case ResourceType.Type.Mineral:
//                    break;
//                case ResourceType.Type.Stone:
//                    break;
//                default:
//                    massPerUnit = 2137;
//                    volumePerUnit = 410;
//                    defaultCostPerUnit = 15;
//                    name = "yomama";
//                    break;
//
//            }
//        }
    }
}

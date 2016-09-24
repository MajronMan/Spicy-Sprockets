using UnityEngine;

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
        private Quality quality;
   
    
		public Resource(string type, int quantity, Quality quality, Info info)
        {
			this.type = type;
			var data = info.ResourceTypes.GetData (type);
			int.TryParse(data ["mass"], out this.massPerUnit);
			int.TryParse(data ["volume"], out this.volumePerUnit);
			int.TryParse(data ["price"], out this.defaultPricePerUnit);
            this.quantity = quantity;
            this.quality = quality;
        }
    
        public Quality GetQuality()
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

		public override string ToString(){
			return quantity.ToString() + " of " + quality.ToString() + " " + type;
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

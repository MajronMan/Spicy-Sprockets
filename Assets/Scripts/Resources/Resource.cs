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
		private Info info;
        private int quantity;
        private Quality quality;
   
    
		public Resource(string type, int quantity, Quality quality, Info info)
        {
			this.type = type;
			this.info = info;
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

	    public Resource Divide(int newQuantity)
	    {
	        if(newQuantity > quantity)
	        {
	            Debug.Log("Cant subtract");
	            return this;
	        }

	        Resource newRes = new Resource(type, newQuantity, quality, info);
	        quantity -= newQuantity;
	        return newRes;
	    }

	    public Resource Fuse(Resource newRes)
	    {
	        quantity = newRes.quantity;
	        //trzeba pozniej zmienic zeby quality jakos wplywalo
	        return this;
	    }
	}
}

using Assets.Scripts.Game_Controllers;
using UnityEngine;

namespace Assets.Scripts.Resources
{
    [System.Serializable]
    public class Resource
    {
		private readonly string _type;
        private readonly int _massPerUnit;
		private readonly int _volumePerUnit;
        private readonly int _defaultPricePerUnit;
        private int _quantity;
    
		public Resource(string type, int quantity)
        {
			_type = type;
            //load constant values from world data
			var resourceTypes = Controllers.ConstantData.ResourceTypes[type];
			int.TryParse(resourceTypes ["mass"], out _massPerUnit);
			int.TryParse(resourceTypes ["volume"], out _volumePerUnit);
			int.TryParse(resourceTypes ["price"], out _defaultPricePerUnit);
            _quantity = quantity;
        }

        public int GetQuantity()
        {
            return _quantity;
        }
            
        public static Resource operator +(Resource basicRes, int addedQuantity)
        {
            return new Resource(basicRes._type, basicRes._quantity + addedQuantity);
        }

        public static Resource operator +(Resource self, Resource other)
        {
            if (other._type == self._type)
                return new Resource(self._type, self._quantity + other._quantity);
            //else
            Debug.Log("Types don't match");
            return self;
        }

        public static Resource operator -(Resource basicRes, int subtractedQuantity)
        {
            if (basicRes._quantity < subtractedQuantity)
            {
                Debug.Log("Cannot substract");
                return basicRes;
            }
            return new Resource(basicRes._type, basicRes._quantity - subtractedQuantity);
        }

        public static Resource operator -(Resource self, Resource other)
        {
            if (self._quantity < other._quantity)
            {
                Debug.Log("Cannot substract");
                return self;
            }
            if (other._type != self._type)
            {
                Debug.Log("Types don't match");
                return self;
            }

            return new Resource(self._type, self._quantity - other._quantity);
            
        }

        public static Resource operator ++(Resource basicRes)
        {
            basicRes._quantity++;
            return basicRes;
        }

        public static Resource operator --(Resource basicRes)
        {
            basicRes._quantity--;
            return basicRes;
        }

		public override string ToString(){
			return _quantity.ToString() + " of " + _type;
		}
	}
}

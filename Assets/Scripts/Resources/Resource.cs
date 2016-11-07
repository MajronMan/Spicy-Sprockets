using Assets.Scripts.Game_Controllers;
using UnityEngine;

namespace Assets.Scripts.Resources
{
    //luknw will change it so I don't need to write documentation here
    [System.Serializable]
    public class Resource
    {
		public readonly string MyType;
        private int _massPerUnit;
		private int _volumePerUnit;
        private int _defaultPricePerUnit;
        private int _quantity;
    
		public Resource(string type, int quantity)
        {
			MyType = type;
            _quantity = quantity;
            _massPerUnit = -1;
            _volumePerUnit = -1;
            _defaultPricePerUnit = -1;
    }

        public int GetQuantity()
        {
            return _quantity;
        }

        public int GetVolume()
        {
            if (_volumePerUnit == -1)
            {
                LoadData();
            }
            return _quantity*_volumePerUnit;
        }

        public int GetMass()
        {
            if (_massPerUnit == -1)
            { 
                LoadData();
            }
            return _quantity * _massPerUnit;
        }

        public static bool operator >(Resource self, Resource other)
        {
            return self.MyType == other.MyType && self._quantity > other._quantity;
        }

        public static bool operator <(Resource self, Resource other)
        {
            return self.MyType == other.MyType && self._quantity < other._quantity;
        }

        public static bool operator >=(Resource self, Resource other)
        {
            return self.MyType == other.MyType && self._quantity >= other._quantity;
        }

        public static bool operator <=(Resource self, Resource other)
        {
            return self.MyType == other.MyType && self._quantity <= other._quantity;
        }

        public static Resource operator +(Resource basicRes, int addedQuantity)
        {
            return new Resource(basicRes.MyType, basicRes._quantity + addedQuantity);
        }

        public static Resource operator +(Resource self, Resource other)
        {
            if (other.MyType == self.MyType)
                return new Resource(self.MyType, self._quantity + other._quantity);
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
            return new Resource(basicRes.MyType, basicRes._quantity - subtractedQuantity);
        }

        public static Resource operator -(Resource self, Resource other)
        {
            if (self._quantity < other._quantity)
            {
                Debug.Log("Cannot substract");
                return self;
            }
            if (other.MyType != self.MyType)
            {
                Debug.Log("Types don't match");
                return self;
            }

            return new Resource(self.MyType, self._quantity - other._quantity);
            
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
			return _quantity.ToString() + " of " + MyType;
		}

        //be lazy, load data only when needed
        private void LoadData()
        {
            //load constant values from world data
            var resourceTypes = Controllers.ConstantData.ResourceTypes[MyType];
            int.TryParse(resourceTypes["mass"], out _massPerUnit);
            int.TryParse(resourceTypes["volume"], out _volumePerUnit);
            int.TryParse(resourceTypes["price"], out _defaultPricePerUnit);
        }
	}
}

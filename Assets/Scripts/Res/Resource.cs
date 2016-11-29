using UnityEngine.Assertions;

namespace Assets.Scripts.Res {
    /// <summary>
    /// <para>
    /// *Non-negative* <c>Amount</c> of resource of some <c>Type</c>.
    /// Operations using <c>int</c>s are provided, but they act
    /// more like a convenient way of casting, so use them wisely.
    /// </para>
    /// <para>
    /// It's an immutable struct (value type), to prevent
    /// checking for null references.
    /// </para>
    /// </summary>
    public struct Resource : ICountable {
        private ResourceType _type;
        private int _amount;

        public ResourceType Type {
            get { return _type; }
        }

        public int Amount {
            get { return _amount; }
        }

        public string Name {
            get { return _type.Name; }
        }

        public int Mass {
            get { return Amount * _type.Mass; }
        }

        public int Volume {
            get { return Amount * _type.Volume; }
        }

        public int DefaultPrice {
            get { return Amount * _type.DefaultPrice; }
        }

        public Resource(ResourceType type, int amount) {
            Assert.IsNotNull(type);
            //The amount of resource HAS TO BE non-negative per class contract.
            Assert.IsTrue(amount >= 0);
            _type = type;
            _amount = amount;
        }

        public static Resource operator +(Resource a, Resource b) {
            Assert.AreEqual(a._type, b._type);
            return new Resource(a._type, a.Amount + b.Amount);
        }

        public static Resource operator -(Resource a, Resource b) {
            Assert.AreEqual(a._type, b._type);
            //This should already be tested in client code with comparison operators.
            Assert.IsTrue(a.Amount >= b.Amount);
            return new Resource(a._type, a.Amount - b.Amount);
        }

        public static bool operator ==(Resource a, Resource b) {
            Assert.AreEqual(a._type, b._type);
            return a.Amount == b.Amount;
        }

        public static bool operator !=(Resource a, Resource b) {
            Assert.AreEqual(a._type, b._type);
            return a.Amount != b.Amount;
        }

        public static bool operator >(Resource a, Resource b) {
            Assert.AreEqual(a._type, b._type);
            return a.Amount > b.Amount;
        }

        public static bool operator <(Resource resource, Resource b) {
            Assert.AreEqual(resource._type, b._type);
            return resource.Amount < b.Amount;
        }

        public static bool operator >=(Resource a, Resource b) {
            Assert.AreEqual(a._type, b._type);
            return a.Amount >= b.Amount;
        }

        public static bool operator <=(Resource a, Resource b) {
            Assert.AreEqual(a._type, b._type);
            return a.Amount <= b.Amount;
        }

        public static Resource operator +(Resource resource, int resourceAmount) {
            return resource + new Resource(resource._type, resourceAmount);
        }

        public static Resource operator -(Resource resource, int resourceAmount) {
            return resource - new Resource(resource._type, resourceAmount);
        }


        public static bool operator ==(Resource resource, int resourceAmount) {
            return resource.Amount == resourceAmount;
        }

        public static bool operator !=(Resource resource, int resourceAmount) {
            return resource.Amount != resourceAmount;
        }

        public static bool operator >(Resource resource, int resourceAmount) {
            return resource.Amount > resourceAmount;
        }

        public static bool operator <(Resource resource, int resourceAmount) {
            return resource.Amount < resourceAmount;
        }

        public static bool operator >=(Resource resource, int resourceAmount) {
            return resource.Amount >= resourceAmount;
        }

        public static bool operator <=(Resource resource, int resourceAmount) {
            return resource.Amount <= resourceAmount;
        }

        public override string ToString() {
            return Amount + " of " + _type;
        }
    }
}
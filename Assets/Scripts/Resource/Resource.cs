using UnityEngine.Assertions;

namespace Assets.Scripts.Resource {
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
    public struct Resource {
        public readonly ResourceType Type;
        public readonly int Amount;

        public int Mass {
            get { return Amount * Type.Mass; }
        }

        public int Volume {
            get { return Amount * Type.Volume; }
        }

        public int DefaultPrice {
            get { return Amount * Type.DefaultPrice; }
        }

        public Resource(ResourceType type, int amount) {
            Assert.IsNotNull(type);
            //The amount of resource HAS TO BE non-negative per class contract.
            Assert.IsTrue(amount >= 0);
            Type = type;
            Amount = amount;
        }

        public static Resource operator +(Resource a, Resource b) {
            Assert.AreEqual(a.Type, b.Type);
            return new Resource(a.Type, a.Amount + b.Amount);
        }

        public static Resource operator -(Resource a, Resource b) {
            Assert.AreEqual(a.Type, b.Type);
            //This should already be tested in client code with comparison operators.
            Assert.IsTrue(a.Amount >= b.Amount);
            return new Resource(a.Type, a.Amount - b.Amount);
        }

        public static bool operator ==(Resource a, Resource b) {
            Assert.AreEqual(a.Type, b.Type);
            return a.Amount == b.Amount;
        }

        public static bool operator !=(Resource a, Resource b) {
            Assert.AreEqual(a.Type, b.Type);
            return a.Amount != b.Amount;
        }

        public static bool operator >(Resource a, Resource b) {
            Assert.AreEqual(a.Type, b.Type);
            return a.Amount > b.Amount;
        }

        public static bool operator <(Resource resource, Resource b) {
            Assert.AreEqual(resource.Type, b.Type);
            return resource.Amount < b.Amount;
        }

        public static bool operator >=(Resource a, Resource b) {
            Assert.AreEqual(a.Type, b.Type);
            return a.Amount >= b.Amount;
        }

        public static bool operator <=(Resource a, Resource b) {
            Assert.AreEqual(a.Type, b.Type);
            return a.Amount <= b.Amount;
        }

        public static Resource operator +(Resource resource, int resourceAmount) {
            return resource + new Resource(resource.Type, resourceAmount);
        }

        public static Resource operator -(Resource resource, int resourceAmount) {
            return resource - new Resource(resource.Type, resourceAmount);
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
            return Amount + " of " + Type;
        }
    }
}
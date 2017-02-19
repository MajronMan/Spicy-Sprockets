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
    public class Commodity : TypedResource<ResourceType>
    {
        public string Name
        {
            get { return MyType.Name; }
        }

        public int Mass
        {
            get { return Amount*MyType.Mass; }
        }

        public int Volume
        {
            get { return Amount*MyType.Volume; }
        }

        public int DefaultPrice
        {
            get { return Amount*MyType.DefaultPrice; }
        }

        public Commodity(ResourceType type, int amount)
        {
            Assert.IsNotNull(type);
            //The amount of resource HAS TO BE non-negative per class contract.
            Assert.IsTrue(amount >= 0);
            MyType = type;
            _amount = amount;
        }
    }
}
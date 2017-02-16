using System;
using Newtonsoft.Json;
using UnityEngine.Assertions;

namespace Assets.Scripts.Res
{
    public class TypelessResource: ICountable
    {
        protected int _amount;
        public int Amount { get { return _amount; } protected set { _amount = value; } }

        public TypelessResource()
        {
            Amount = 0;
        }

        public TypelessResource(int amount)
        {
            Amount = amount;
        }

        public bool Equals(TypelessResource other)
        {
            return Amount == other.Amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TypelessResource) obj);
        }

        public override int GetHashCode()
        {
            return Amount;
        }

        public virtual void Add(int amount) 
        {
            Assert.IsTrue(amount >= 0);
            Amount += amount;
        }

        public virtual void Add<T>(T other) where T : TypelessResource
        {
            Amount += other.Amount;
        }

        public virtual void Sub(int amount) 
        {
            Assert.IsTrue(Amount > amount);
            Amount -= amount;
            var t = new TypelessResource();
        }

        public virtual void Sub<T>(T other) where T : TypelessResource
        {
            Assert.IsTrue(Amount > other.Amount);
            Amount -= other.Amount;
        }

        /// <summary>
        /// Check if this resource has smaller amount than other
        /// </summary>
        public virtual bool Lt<T> (T other) where T : TypelessResource
        {
            return Amount < other.Amount;
        }

        public override string ToString()
        {
            return Amount + " with no type";
        }
    }
}

using Newtonsoft.Json;
using UnityEngine.Assertions;

namespace Assets.Scripts.Res
{
    public class TypedResource<T> : TypelessResource, ITypeable<T>
    {
        protected T _myType;
        public T MyType { get { return _myType; } protected set { _myType = value; } }

        public TypedResource(int amount, T myType)
        {
            Amount = amount;
            MyType = myType;
        }

        protected TypedResource()
        {
            Amount = 0;
            MyType = default(T);
        }

        public bool Equals(TypedResource<T> other)
        {
            return Equals(MyType, other.MyType) && Amount == other.Amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            var resource = obj as TypedResource<T>;
            return resource != null && (resource == this);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((MyType != null ? MyType.GetHashCode() : 0) * 397) ^ Amount;
            }
        }

        public new void Add(int amount)
        {
            // why do I have to write it?
            base.Add(amount);
        }

        public new void Add<T1>(T1 other) where T1 : TypedResource<T>
        {
            Assert.IsTrue(MyType.Equals(other.MyType));
            Amount += other.Amount;
        }

        public new void Sub(int amount)
        {
            // resharper is OK with this, but why?
            base.Sub(amount);
        }

        public new void Sub<T1>(T1 other) where T1 : TypedResource<T>
        {
            Assert.IsTrue(CompareTypes(other));
            //This should already be tested in client code with comparison operators.
            Assert.IsTrue(Amount >= other.Amount);
            Amount -= other.Amount;
            var t = new TypedResource<T>();
        }

        public new bool Lt<T1>(T1 other) where T1: TypedResource<T>
        {
            Assert.IsTrue(CompareTypes(other));
            return base.Lt(other);
        }

        public bool CompareTypes(TypedResource<T> b)
        {
            return MyType.Equals(b.MyType);
        }
    }
}

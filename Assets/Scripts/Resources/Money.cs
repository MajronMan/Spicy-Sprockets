using UnityEngine;

namespace Assets.Scripts.Resources
{
    public class Money {

        private int _amount;

        public Money(int amount = 10000)
        {
            _amount = amount;
        }

        public int GetAmount()
        {
            return _amount;
        }
        
        public static Money operator + (Money current, int added)
        {
            return new Money(current._amount + added);
        }

        //stack overflow told me that p += a is just syntactic sugar for p = p + a in c# so we only have to overload `+`
        public static Money operator +(Money current, Money added)
        {
            return new Money(current._amount + added._amount);
        }

        public static Money operator -(Money current, int subtracted)
        {
            if (subtracted <= current._amount)

                return new Money(current._amount - subtracted);

            current.InsufficientResourcesMessage();
            return current;
        }

        public void MoneyCounter()
        {
            //shows money alongside with other resources. Will implement once they will be visible too
        }

        public void InsufficientResourcesMessage()
        {
            //part of the interface, will be shown, when player will want to spend more money than he has 
        }
    }
}

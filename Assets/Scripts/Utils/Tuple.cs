using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utils
{
    public class Tuple <T1, T2>
    {
        public Tuple(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        public T1 First { get; private set;} 
        public T2 Second { get; private set; }
    }

    public static class Tuple
    {
        public static Tuple<T1, T2> New<T1, T2>(T1 first, T2 second)
        {
            var tuple = new Tuple<T1, T2>(first, second);
            return tuple;
        }
    }
}

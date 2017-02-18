using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Res
{
    /// <summary>
    /// In case you not only want to count stuff but it has a type, too
    /// </summary>
    /// <typeparam name="T">Actual type</typeparam>
    public interface ITypeable<out T>: ICountable
    {
        T MyType { get; }
    }
}

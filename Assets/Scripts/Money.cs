using UnityEngine;
using System.Collections;

public class Money : MonoBehaviour {

    private int amount = 10000;

    public static Money operator + (Money current, int added)
    {
        current.amount += added;
        return current;
    }

    public static Money operator - (Money current, int subtracted)
    {
        if (subtracted <= current.amount)
        {
            current.amount -= subtracted;
            return current;
        }
        else
        {
            current.InsufficientResourcesMessage();
            return current;
        }

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

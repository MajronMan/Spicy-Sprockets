using UnityEngine;
using System.Collections;

public class Coal : Resource {
    

    // Use this for initialization
    public Coal(int quantity, ResourceQuality quality) : base(quantity, quality)
    {
    }

    //takes batch of coal c
    //if c's quality match quality of this, merges c into this and nullifies c
    public void add(Coal c)
    {
        if (c.quality == quality )
        {
            quantity += c.getQuantity();
            c = null;
        }
    }

    public Coal subtract(int quantity)
    {
        int actualQuantity;
        if (quantity >= this.quantity) actualQuantity = this.quantity;
        else actualQuantity = quantity;
        Coal res=new Coal(actualQuantity, this.quality);
        this.quantity -= actualQuantity;
        return res;
    }
    void Start ()
	{
	    massPerUnit = 2137;
	    volumePerUnit = 410;
	    defaultCostPerUnit = 15;
	    name = "Coal";

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
